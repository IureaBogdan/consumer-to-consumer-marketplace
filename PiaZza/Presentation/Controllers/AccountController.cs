using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using ViewModels.Account;
using ViewModels.Offer;

namespace Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly  IOfferService _offerService;

        public AccountController(IAccountService accountService, IOfferService offerService)
        {
            _accountService = accountService;
            _offerService = offerService;
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }
        public ActionResult CreateAccount()
        {
            if (Session["UserID"] == null)
                return View();
            else return RedirectToAction("MyOffers");
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["UserID"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_accountService.CheckAccountByUsernamePassword(model.Username, model.Password))
                {
                    var accountFromDb = _accountService.GetAccountByUsername(model.Username);
                    Session["UserID"] = accountFromDb.AccountId;
                    Session["UserName"] = accountFromDb.UserName;
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.Message = "Credentials not match.";
            return View(model);
        }
        public ActionResult MyOffers()
        {
            if (Session["UserID"] != null)
            {
                var accountOffers = _offerService.GetAccountOffersById(new Guid(Session["UserID"].ToString()));
                List<AccountOfferListViewModel> offerList = new List<AccountOfferListViewModel>();

                for (int i = 0; i < accountOffers.Count; i++)
                {
                    if (accountOffers[i].OfferImages.Count > 0)
                    {
                        offerList.Add(new AccountOfferListViewModel
                        {
                            Title = accountOffers[i].Title,
                            Date = accountOffers[i].Date,
                            Location = accountOffers[i].Location,
                            Id = accountOffers[i].Id,
                            ImageLink=_offerService.GetFirstImageLinkById(accountOffers[i].Id)
                        }); ;
                    }
                    else
                    {
                        offerList.Add(new AccountOfferListViewModel
                        {
                            Title = accountOffers[i].Title,
                            Date = accountOffers[i].Date,
                            Location = accountOffers[i].Location,
                            Id = accountOffers[i].Id

                        });
                    }
                }
                return View(offerList);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult LogOut()
        {
            if (Session["UserID"] != null)
            {
                Session["UserID"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewOffer(AccountOfferAddViewModel model)
        {
            if (Session["UserID"] != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {           
                        Guid offerId = _offerService.AddOffer(new Guid(Session["UserID"].ToString()), model);
                        var offerList = _offerService.GetAccountOffersById(new Guid(Session["UserID"].ToString()));
                        //create a dir for new offer
                        var physicalOfferDirectoryPath = Server.MapPath("~/UserFiles/" + Session["UserID"] + "/Offers/" + offerId.ToString());
                        System.IO.Directory.CreateDirectory(physicalOfferDirectoryPath);
                        //get files uploaded
                        if (Request.Files.Count > 0 && Request.Files[0].ContentLength>0)
                        {
                            var offerImageList = new List<OfferImage>();
                            for (int i = 0; i < Request.Files.Count; i++)
                            {
                                if (Request.Files[i].ContentLength > 0)
                                {
                                    var image = Request.Files[i];
                                    if (image != null
                                        && (image.FileName.Contains(".jpg")
                                        || image.FileName.Contains(".jpeg")
                                        || image.FileName.Contains(".bmp")
                                        || image.FileName.Contains(".png")))
                                    {
                                        var serverFilePath = "~/UserFiles/" + Session["UserID"].ToString() + "/Offers/" + offerId.ToString();
                                        var fileName = Path.GetFileName(image.FileName);

                                        var localPath = Path.Combine(Server.MapPath(serverFilePath), fileName);
                                        image.SaveAs(localPath);
                                        //add a new offer image to offer images list
                                        offerImageList.Add(
                                            new OfferImage
                                            {
                                                OfferImageId = Guid.NewGuid(),
                                                ImageLink = "/UserFiles/" + Session["UserID"].ToString() + "/Offers/" + offerId.ToString() + "/" + fileName,
                                                OfferId = offerId
                                            });
                                    }
                                }
                            }

                            _offerService.AddOfferImages(offerImageList);
                        }
                        //create a default image for offer in case there are no images for offer
                        else
                        {
                            var defaultImage = new OfferImage
                            {
                                OfferImageId = Guid.NewGuid(),
                                OfferId = offerId,
                                ImageLink="/UserFiles/blank-offer.png"
                            };
                            _offerService.AddOfferImage(defaultImage);
                        }
                        _offerService.SaveChanges();
                        return RedirectToAction("MyOffers");
                    }
                    catch (Exception ex)
                    {
                        Console.Out.WriteLine(ex.Message);
                        return View("AddNewOffer");
                    }
                }
                else return View(model);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public ActionResult AddNewOffer()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOffer(AccountOfferEditViewModel model)
        {
            if (Session["UserID"] != null)
            {

                if (ModelState.IsValid)
                {
                    if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                    {
                        var offerImageList = new List<OfferImage>();
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            if (Request.Files[i].ContentLength > 0)
                            {
                                var image = Request.Files[i];
                                if (image != null
                                    && (image.FileName.Contains(".jpg")
                                    || image.FileName.Contains(".jpeg")
                                    || image.FileName.Contains(".bmp")
                                    || image.FileName.Contains(".png")))
                                {
                                    var serverFilePath = "~/UserFiles/" + Session["UserID"].ToString() + "/Offers/" + model.Id.ToString();
                                    var fileName = Path.GetFileName(image.FileName);

                                    var localPath = Path.Combine(Server.MapPath(serverFilePath), fileName);
                                    image.SaveAs(localPath);
                                    //add a new offer image to offer images list
                                    offerImageList.Add(
                                        new OfferImage
                                        {
                                            OfferImageId = Guid.NewGuid(),
                                            ImageLink = "/UserFiles/" + Session["UserID"].ToString() + "/Offers/" + model.Id.ToString() + "/" + fileName,
                                            OfferId = model.Id
                                        });
                                }
                            }
                        }
                        _offerService.AddOfferImages(offerImageList);
                    }
                    if (_offerService.EditOffer(model))
                    {
                        _offerService.SaveChanges();
                        return RedirectToAction("MyOffers");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                    return View(model);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        
        [HttpGet]
        public ActionResult EditOffer(Nullable<Guid> Id)
        {
            if (Session["UserID"] != null && Id!=null)
            {
                var id = (Guid)Id;
                var offer = _offerService.GetOfferById(id);
                var imageDataDictionary = new Dictionary<Guid, string>();
                foreach(var offerImage in offer.OfferImages)
                {
                    imageDataDictionary.Add(offerImage.OfferImageId,offerImage.ImageLink);
                }
                if (offer != null)
                {
                    var offerToEdit = new AccountOfferEditViewModel
                    {
                        Id = offer.Id,
                        Title = offer.Title,
                        Description = offer.Description,
                        Price = offer.Price,
                        Category = offer.Category,
                        Subcategory = offer.Subcategory,
                        Location = offer.Location,
                        ImageDataDictionary=imageDataDictionary
                    };
                    return View(offerToEdit);
                }
                else return RedirectToAction("MyOffers", "Account");
            }
            else return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        public ActionResult DeleteAccountOffer(Guid id)
        {
            if (Session["UserID"] != null)
            {
                try
                {
                    var offer = _offerService.GetOfferById(id);
                    var offerPath = Server.MapPath($"~/UserFiles/{offer.AccountId}/Offers/{id}");
                    if (_offerService.DeleteOffer(id))
                    {
                        var directoryInfo = new System.IO.DirectoryInfo(offerPath);
                        directoryInfo.Delete(true);
                        return RedirectToAction("MyOffers");
                    }
                    else
                    {
                        return RedirectToAction("MyOffers");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Exception = ex.Message;
                    return RedirectToAction("MyOffers");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult MyAccount()
        {
            if (Session["UserID"] != null)
            {
                var account = _accountService.GetAccountByUsername(Session["UserName"].ToString());
                var pass = ViewModels.Modules.Cryptography.Decrypt(account.Password, "password");
                var accountToEdit = new AccountDetailsViewModel
                {
                    Id = account.AccountId,
                    FirstName = account.FirstName,
                    Email = account.Email,
                    LastName = account.LastName,
                    UserName = account.UserName,
                    Adress = account.Adress,
                    ImageLink = account.ImageLink,
                    Password = pass,
                    PhoneNumber = account.PhoneNumber
                };
                return View(accountToEdit);
            }
            else return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult MyAccount(AccountEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var id = new Guid(Session["UserID"].ToString());
                var pass = ViewModels.Modules.Cryptography.Encrypt(model.Password, "password");
                var account= _accountService.GetAccountById(id);

                var imageLink = account.ImageLink;
                //ignore content with 0 length, get only user uploads
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength>0)
                {
                    var image = Request.Files[0];
                    if (image != null
                        &&(image.FileName.Contains(".jpg")
                        || image.FileName.Contains(".jpeg")
                        || image.FileName.Contains(".bmp")
                        || image.FileName.Contains(".png")))
                    {
                        var fileName = Path.GetFileName(image.FileName);
                        var path = Path.Combine(Server.MapPath("~/UserFiles/"+id+"/ProfileImages"), fileName);
                        image.SaveAs(path);
                        imageLink ="/UserFiles/" + id + "/ProfileImages/"+fileName;
                    }
                }
                var accountToEdit = new AccountDetailsViewModel
                {
                    Id = id,
                    ImageLink = imageLink,
                    UserName = Session["UserName"].ToString(),
                    Password = pass,
                    FirstName = model.FirstName,
                    Email = model.Email,
                    LastName = model.LastName,
                    Adress = model.Adress,
                    PhoneNumber = model.PhoneNumber
                };
                if (_accountService.UpdateAccountCredentials(accountToEdit))
                    return RedirectToAction("MyAccount");
                else return View(accountToEdit);
            }
            else
            {
                var id = new Guid(Session["UserID"].ToString());
                var pass = ViewModels.Modules.Cryptography.Encrypt(model.Password, "password");

                var accountToEdit = new AccountDetailsViewModel
                {
                    Id = id,
                    ImageLink = " ",
                    UserName = Session["UserName"].ToString(),
                    Password = pass,
                    FirstName = model.FirstName,
                    Email = model.Email,
                    LastName = model.LastName,
                    Adress = model.Adress,
                    PhoneNumber = model.PhoneNumber
                };
                return View(accountToEdit);
            }
        }
    }

}