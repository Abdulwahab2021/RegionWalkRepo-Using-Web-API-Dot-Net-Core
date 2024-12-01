using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repositories;

namespace NZWalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }


        //Post/api/Images/Upload
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO request)
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {

                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileDescription = request.FileDescription,
                    FileName = request.FileName
                };

                //User Repository to upload image
                await this.imageRepository.Upload(imageDomainModel);
                    return Ok(imageDomainModel);

            }
            return BadRequest(ModelState);
            

        }
        private void ValidateFileUpload(ImageUploadRequestDTO request)
        {
            var allowedExtension = new string[] { ".jpg", "jpeg", ".png" };
            if (!allowedExtension.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "UnSupported File Extension");
            }
            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size is more than 10 MB Please upload a smaller size file");
            }
        }
    }
}
