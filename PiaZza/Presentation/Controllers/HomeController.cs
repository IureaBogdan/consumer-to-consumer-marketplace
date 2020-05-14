using System.Collections.Generic;
using System.Web.Mvc;
using ViewModels.Offer;
using BusinessLogic.Services.Interfaces;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {

        private readonly IOfferService _offerService;
        public HomeController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public ActionResult Index()
        {
            var allOffers = _offerService.GetOffers();
            var offersToView = new List<OfferListViewModel>();
            foreach (var offer in allOffers)
            {
                offersToView.Add(new OfferListViewModel
                {
                    Id = offer.Id,
                    Price = offer.Price,
                    Title = offer.Title,
                    Date = offer.Date,
                    Location = offer.Location,
                    ImageLink = _offerService.GetFirstImageLinkById(offer.Id)
                });
            }
            return View(offersToView);
        }
        public ActionResult Register()
        {
            return View("Login","Account");
        }
        public ActionResult PageNotFound()
        {
            return PartialView("PageNotFoundPartialView");
        }
    }
}