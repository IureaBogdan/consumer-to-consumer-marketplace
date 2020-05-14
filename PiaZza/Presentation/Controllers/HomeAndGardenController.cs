using BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModels.Offer;

namespace Presentation.Controllers
{
    public class HomeAndGardenController : Controller
    {
        private readonly IOfferService _offerService;
        public HomeAndGardenController(IOfferService offerService)
        {
            _offerService = offerService;
        }
        public ActionResult Index()
        {
            var allOffers = _offerService.GetOffersByCategory("Home and garden");
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
            var allOffers = _offerService.GetOffersBySubcategory("Home and garden","Others");
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
        public ActionResult Furniture()
        {
            var allOffers = _offerService.GetOffersBySubcategory("Home and garden", "Furniture");
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
        public ActionResult HomeAccessories()
        {
            var allOffers = _offerService.GetOffersBySubcategory("Home and garden", "Home accessories");
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
        public ActionResult GardenTools()
        {
            var allOffers = _offerService.GetOffersBySubcategory("Home and garden", "Garden tools");
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