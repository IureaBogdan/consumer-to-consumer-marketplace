using System;
using System.Web.Http;
using ViewModels.Account;
using BusinessLogic.Services;
using System.Linq;
namespace Presentation.Controllers.API
{
    public class AccountController : ApiController
    {
        private readonly AccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult CreateAccount([FromBody]AccountCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool matchUsername = false;
                    var accounts = _accountService.GetAccounts();
                    foreach (var account in accounts)
                    {
                        if (account.UserName.ToLower() == model.UserName.ToLower())
                        {
                            matchUsername = true;
                        }
                    }
                    if (!matchUsername)
                    {
                        model.ImageLink = "/UserFiles/blank-profile.png";
                        Guid id = _accountService.RegisterAccount(model);
                        string uri = $"{Request.RequestUri}/{id}";

                        //create a directory for the new user 
                        var mappedPathProfileImage = System.Web.Hosting.HostingEnvironment.MapPath("~/UserFiles/"+id.ToString()+"/ProfileImages");
                        System.IO.Directory.CreateDirectory(mappedPathProfileImage);
                        var mappedPathOffers= System.Web.Hosting.HostingEnvironment.MapPath("~/UserFiles/" + id.ToString() + "/Offers");
                        System.IO.Directory.CreateDirectory(mappedPathOffers);
                        AccountCreateViewModel accountDeatailsViewModel = new AccountCreateViewModel
                        {
                            FirstName = model.FirstName,
                            Email = model.Email,
                            LastName = model.LastName,
                            UserName = model.UserName,
                            Adress = model.Adress,
                            ImageLink= model.ImageLink
                        };
                        return Created(uri, accountDeatailsViewModel);
                    }
                    else
                    {
                        return Conflict();
                    }
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
            else
            {
                var errorMessages = string.Join(" <br /> ", this.ModelState.Values
                                        .SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage));
                return Json(new { HasError = true, ErrorMessages = errorMessages });
            }
        }
    }
}