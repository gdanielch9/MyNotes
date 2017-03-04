using MyNote.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public void UploadPhoto()
        {
            var fileUpload = HttpContext.Current.Request.Files[0];

            _photosService.UploadImageToTempDir(fileUpload);
        }
    }
}
