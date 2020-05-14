using BusinessLogic.Services.Interfaces;
using System;
using System.Web.Http;

namespace Presentation.Controllers.API
{
    public class OfferController : ApiController
    {
        private readonly IOfferService _offerService;
        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                var offerImage = _offerService.GetOfferImageById(id);
                var serverImagePath = "~"+offerImage.ImageLink;

                _offerService.DeleteOfferImage(id);
                _offerService.SaveChanges();

                //remove it from local storage
                var mappedImagePath = System.Web.Hosting.HostingEnvironment
                                        .MapPath(serverImagePath);
                //prevent deleting global default image
                if (!serverImagePath.Contains("blank-offer.png")) {
                    System.IO.File.Delete(mappedImagePath);
                }
                return Ok();
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }
    }
}