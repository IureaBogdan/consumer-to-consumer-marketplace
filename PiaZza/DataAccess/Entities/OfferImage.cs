using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class OfferImage
    {
        #region Properties
        public Guid OfferImageId { get; set; }
        public string ImageLink { get; set; }
        #endregion

        #region Foreign Keys
        public Guid OfferId { get; set; }
        #endregion

        #region [ Navigation Properties ]
        public virtual Offer Offer { get; set; }
        #endregion
    }
}
