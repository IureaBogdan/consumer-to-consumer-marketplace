using DataAccess.Entities;
using System;
using System.Collections.Generic;
using ViewModels.Offer;

namespace BusinessLogic.Services.Interfaces
{
    public interface IOfferService
    {
        Guid AddOffer(Guid accountId, AccountOfferAddViewModel addOffer);
        void AddOfferImage(OfferImage offerImage);
        void AddOfferImages(ICollection<OfferImage> offerImageCollection);
        bool DeleteOffer(Guid id);
        void DeleteOfferImage(Guid id);
        bool EditOffer(AccountOfferEditViewModel model);
        List<Offer> GetAccountOffersById(Guid id);
        string GetFirstImageLinkById(Guid id);
        Offer GetOfferById(Guid id);
        OfferImage GetOfferImageById(Guid id);
        List<Offer> GetOffers();
        List<Offer> GetOffersByCategory(string category);
        List<Offer> GetOffersBySearchString(string searchString);
        List<Offer> GetOffersBySubcategory(string category, string subcategory);
        List<OfferImage> GetOffersImagesById(Guid id);
        Account GetSellerByOfferId(Guid id);
        void SaveChanges();
    }
}