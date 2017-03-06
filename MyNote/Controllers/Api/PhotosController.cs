using MyNote.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;

namespace MyNote.Controllers.Api
{
    //[Authorize]
    public class PhotosController : ApiController
    {
        private readonly IPhotosService _photosService;

        public PhotosController(IPhotosService photosService)
        {
            _photosService = photosService;
        }

        [HttpPost]
        [Route("Photos/UploadPhoto/")]
        public HttpResponseMessage UploadPhoto()
        {
            var fileUpload = HttpContext.Current.Request.Files[0];

            string photoname = _photosService.UploadImageToTempDirAndReturPhotoname(fileUpload);

            var success = new HttpResponseMessage(HttpStatusCode.OK);
            success.Content = new StringContent(photoname, System.Text.Encoding.UTF8);
            return success;
        }

        [Route("Photos/Get/{photoId}")]
        public HttpResponseMessage GetPhoto(int photoId)
        {
            byte[] photo = _photosService.GetPhotoData(photoId);
            HttpResponseMessage response = new HttpResponseMessage();

            if (photo == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }

            response.StatusCode = HttpStatusCode.OK;
            response.Content = new ByteArrayContent(photo);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            return response;
        }
    }
}
