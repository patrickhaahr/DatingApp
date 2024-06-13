using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public FileController(IConfiguration configuration) => _configuration = configuration;

        [HttpPost("upload")]
        public async Task<ActionResult> Upload()
        {
            var file = Request.Form.Files[0];
            var uploadFolder = _configuration.GetValue<string>("UploadFolder");
            var filePath = Path.Combine(uploadFolder, file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok();
        }
    }
}
