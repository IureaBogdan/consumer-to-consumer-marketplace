﻿using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels.Offer;

namespace BusinessLogic.Services
{
    public class OfferService
    {
        private OfferRepository _offerRepository;
        private AccountRepository _accountRepository;
        private OfferImageRepository _offerImageRepository;
        private UnitOfWork _unitOfWork;

        public OfferService()
        {
            var dbContext = new PiazzaDbContext();
            _accountRepository = new AccountRepository(dbContext);
            _offerRepository = new OfferRepository(dbContext);
            _offerImageRepository = new OfferImageRepository(dbContext);
            _unitOfWork = new UnitOfWork(dbContext);
        }

        public List<Offer> GetAccountOffersById(Guid id)
        {
            _offerRepository = new OfferRepository(new PiazzaDbContext());
            return _offerRepository.GetAccountOffersById(id);
        }
        public Guid AddOffer(Guid accountId, AccountOfferAddViewModel addOffer)
        {
            var offerEntry = new Offer
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now.Date,
                AccountId = accountId,
                Title = addOffer.Title,
                Description = addOffer.Description,
                Category = addOffer.Category,
                Subcategory = addOffer.Subcategory,
                Location = addOffer.Location,
                Price = addOffer.Price,
                Account = _accountRepository.GetAccountById(accountId),
            };
            _offerRepository.Add(offerEntry);
            return offerEntry.Id;
        }
        
        public Offer GetOfferById(Guid id)
        {
            return _offerRepository.GetOfferById(id);
        }
        public List<OfferImage> GetOffersImagesById(Guid id)
        {
            return _offerImageRepository.GetOfferImagesById(id);
        }
        public OfferImage GetOfferImageById(Guid id)
        {
            return _offerImageRepository.Query()
                .Where(offerImage => offerImage.OfferImageId == id)
                .FirstOrDefault();
        }

        public string GetFirstImageLinkById(Guid id)
        {
            var images = GetOffersImagesById(id);
            if (images.Count > 0)
                return images[0].ImageLink;
            else
                return "";
        }
        public bool EditOffer(AccountOfferEditViewModel model)
        {
            if (model.Id != null)
            {
                _offerRepository.Edit(model);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteOffer(Guid id)
        {
            if (id != null)
            {
                _offerRepository.DeleteById(id);
                _unitOfWork.Commit();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DeleteOfferImage(Guid id)
        {
            _offerImageRepository.Delete(_offerImageRepository.GetById(id));
        }
        public List<Offer> GetOffers()
        {
            return _offerRepository.GetOffers();
        }
        public List<Offer> GetOffersByCategory(string category)
        {
            return _offerRepository.Query()
                .Where(offer=>offer.Category==category)
                .ToList();
        }
        public List<Offer> GetOffersBySubcategory(string category, string subcategory)
        {
            return _offerRepository.Query()
                .Where(offer => offer.Category == category 
                                &&offer.Subcategory==subcategory)
                .ToList();
        }
        public List<Offer> GetOffersBySearchString(string searchString)
        {
            return _offerRepository.Query()
                .Where(offer => offer.Title.Contains(searchString) 
                        || offer.Description.Contains(searchString))
                .ToList();
        }
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public Account GetSellerByOfferId(Guid id)
        {
            var offer = GetOfferById(id);
            return _accountRepository.GetAccountById(offer.AccountId);
        }
        public void AddOfferImages(ICollection<OfferImage> offerImageCollection)
        {
            _offerImageRepository.AddListOfferImages(offerImageCollection);
        }

        public void AddOfferImage(OfferImage offerImage)
        {
            _offerImageRepository.AddOfferImage(offerImage);
        }
    }
}
