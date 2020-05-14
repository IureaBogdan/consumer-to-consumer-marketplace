using BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModels.Offer;

namespace Presentation.Controllers
{
    public class SearchController : Controller
    {
        private readonly IOfferService _offerService;
        public SearchController(IOfferService offerService)
        {
            _offerService = offerService;
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