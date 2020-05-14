using BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModels.Offer;

namespace Presentation.Controllers
{
    public class PetsController : Controller
    {
        private readonly IOfferService _offerService;
        public PetsController(IOfferService offerService)
        {
            _offerService = offerService;
        }
        public ActionResult Index()
        {
            var allOffers = _offerService.GetOffersByCategory("Pets");
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

        public ActionResult Pets()
        {
            var allOffers = _offerService.GetOffersBySubcategory("Pets", "Pets");
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
        public ActionResult Food()
        {
            var allOffers = _offerService.GetOffersBySubcategory("Pets", "Pet food");

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
        public ActionResult Others()
        {
            var allOffers = _offerService.GetOffersBySubcategory("Pets", "Others");
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
    }
}