using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels.Offer;

namespace Presentation.Controllers
{
    public class SearchController : Controller
    {
        private readonly OfferService _offerService;
        // GET: Search
        public SearchController()
        {
            _offerService = new OfferService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Results(string searchString)
        {

            var offers = _offerService.GetOffersBySearchString(searchString);
            var offersToView = new List<OfferListViewModel>();
            foreach (var offer in offers)
            {
                offersToView.Add(new OfferListViewModel
                {
                    AcountId = offer.AccountId,
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