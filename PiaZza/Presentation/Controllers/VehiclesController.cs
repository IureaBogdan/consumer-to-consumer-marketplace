using BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModels.Offer;

namespace Presentation.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IOfferService _offerService;
        public VehiclesController(IOfferService offerService)
        {
            _offerService = offerService;
        }
        public ActionResult Index()
        {
            var allOffers = _offerService.GetOffersByCategory("Vehicles");
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
            var allOffers = _offerService.GetOffersBySubcategory("Vehicles", "Others");
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
        public ActionResult Trucks()
        {
            var allOffers = _offerService.GetOffersBySubcategory("Vehicles", "Trucks");
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
        public ActionResult BigTrucks()
        {
            var allOffers = _offerService.GetOffersBySubcategory("Vehicles", "BIG trucks");
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
        public ActionResult Motorcycles()
        {
            var allOffers = _offerService.GetOffersBySubcategory("Vehicles", "Motorcycles");
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
        public ActionResult Cars()
        {
            var allOffers = _offerService.GetOffersBySubcategory("Vehicles", "Cars");
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