using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ViewModels.Offer;

namespace DataAccess.Repositories
{
    public class OfferRepository
    {
        private readonly PiazzaDbContext _dbContext;
        private OfferImageRepository _offerImageRepository;
        public OfferRepository(PiazzaDbContext dbContext)
        {
            _dbContext = dbContext;
            _offerImageRepository = new OfferImageRepository(_dbContext);
        }
        public IQueryable<Offer> Query()
        {
            return this._dbContext.Offers.Include(offer=>offer.Account).AsQueryable();
        }
        public List<Offer> GetAccountOffersById(Guid id)
        {
            return _dbContext.Offers
                .Include(imgList => imgList.OfferImages)
                .Where(accId => accId.AccountId == id)
                .ToList();
        }
        public Offer GetOfferById(Guid id)
        {
            return _dbContext.Offers
                        .Include(imgList => imgList.OfferImages)
                        .Where(offer => offer.Id == id)
                        .FirstOrDefault();
        }
        public void Add(Offer offer)
        {
            _offerImageRepository.AddListOfferImages(offer.OfferImages);
            _dbContext.Offers.Add(offer);
        }
        public void Edit(AccountOfferEditViewModel model)
        {
            var offerToEdit = GetOfferById(model.Id);
            offerToEdit.Date = DateTime.Now;
            offerToEdit.Location = model.Location;
            offerToEdit.Title = model.Title;
            offerToEdit.Category = model.Category;
            offerToEdit.Subcategory = model.Subcategory;
            offerToEdit.Price = model.Price;
            offerToEdit.Description = model.Description;
        }
        public void DeleteById(Guid id)
        {
            _dbContext.Offers.Remove(GetOfferById(id));
        }
        public List<Offer> GetOffers()
        {
            return _dbContext.Offers.ToList();
        }
    }
}
