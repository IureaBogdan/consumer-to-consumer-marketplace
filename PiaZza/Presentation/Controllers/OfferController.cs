using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModels.Offer;

namespace Presentation.Controllers
{

    public class OfferController : Controller
    {
        private readonly OfferService _offerService;
        public OfferController()
        {
            _offerService = new OfferService();
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }
        public ActionResult ViewOffer(Nullable<Guid> Id)
        {
            try
            {
                var id = new Guid(Id.ToString());
                var offer = _offerService.GetOfferById(id);
                var account = _offerService.GetSellerByOfferId(id);
                var offerImages = new List<string>();
                foreach (var imageObject in offer.OfferImages)
                {
                    offerImages.Add(imageObject.ImageLink);
                }
                var offerDetailed = new OfferDetailsViewModel
                {
                    Id = offer.Id,
                    Title = offer.Title,
                    Description = offer.Description,
                    Location = offer.Location,
                    Price = offer.Price,
                    Date = offer.Date,
                    SellerEmail = account.Email,
                    SellerName = account.FirstName + " " + account.LastName,
                    SellerPhoneNumber = account.PhoneNumber,
                    Images = offerImages
                };
                return View(offerDetailed);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}