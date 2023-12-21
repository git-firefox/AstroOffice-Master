using AstroOfficeWeb.Shared.Models;
using AstroShared.Utilities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AstroOfficeWeb.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        // POST api/<FileController>
        [HttpPost]
        public IActionResult SaveProductImages(List<IFormFile> files)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "media", "images");

            foreach (var file in files)
            {
                var guid = Guid.NewGuid();
                var extension = Path.GetExtension(file.FileName.ToLower());
                var filePath = Path.Combine(uploadPath, guid + extension);
                using var stream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(stream);
            }

            var response = new ApiResponse<string>()
            {
                Message = "Saved"
            };

            return Ok(response);
        }

        // PUT api/<FileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
