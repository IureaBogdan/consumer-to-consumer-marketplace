using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories.Interfaces
{
    public interface IOfferImageRepository
    {
        void AddListOfferImages(ICollection<OfferImage> images);
        void AddOfferImage(OfferImage image);
        void Delete(OfferImage offerImage);
        OfferImage GetById(Guid id);
        List<OfferImage> GetOfferImagesById(Guid Id);
        IQueryable<OfferImage> Query();
    }
}