using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Context
{
    public class PiazzaDbContext : DbContext
    {
        public PiazzaDbContext()
            : base("Server=DESKTOP-ALIJ609\\SQLEXPRESS;Database=IureaBogdanIulian;Trusted_Connection=True;")
        {}
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {

            //one to many relation 1|Account->N|Offers
            modelBuilder.Entity<Offer>()
                .HasRequired<Account>(offer => offer.Account)
                .WithMany(acc => acc.Offers)
                .HasForeignKey<Guid>(offer=>offer.AccountId);
            //one to many relation 1|Offer->N|OfferImage
            modelBuilder.Entity<OfferImage>()
                .HasRequired<Offer>(offerImage => offerImage.Offer)
                .WithMany(offer => offer.OfferImages)
                .HasForeignKey<Guid>(offerImage => offerImage.OfferId);

        }
        public DbSet<Account> Accounts{ get; set; }
        public DbSet<OfferImage> OfferImages{ get; set; }
        public DbSet<Offer> Offers{ get; set; }
}
}
