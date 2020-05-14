using DataAccess.Context;
using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OfferImageRepository
    {
        private readonly PiazzaDbContext _dbContext;
        public OfferImageRepository(PiazzaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<OfferImage> Query()
        {
            return this._dbContext.OfferImages.AsQueryable();
        }
        public void AddListOfferImages(ICollection<OfferImage> images)
        {
            foreach(var image in images)
            {
                _dbContext.OfferImages.Add(image);
            }
        }
        public void AddOfferImage(OfferImage image)
        {
            _dbContext.OfferImages.Add(image);
        }
        public List<OfferImage> GetOfferImagesById(Guid Id)
        {
            return _dbContext.OfferImages.Where(offer => offer.OfferId == Id).ToList();
        }
        public void Delete(OfferImage offerImage)
        {
            _dbContext.OfferImages.Remove(offerImage);
        }
        public OfferImage GetById(Guid id) {
            return _dbContext.OfferImages
                .Where(offerImage => offerImage.OfferImageId == id)
                .FirstOrDefault();
        }
    }
}
