using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels.Offer;

namespace DataAccess.Repositories.Interfaces
{
    public interface IOfferRepository
    {
        void Add(Offer offer);
        void DeleteById(Guid id);
        void Edit(AccountOfferEditViewModel model);
        List<Offer> GetAccountOffersById(Guid id);
        Offer GetOfferById(Guid id);
        List<Offer> GetOffers();
        IQueryable<Offer> Query();
    }
}