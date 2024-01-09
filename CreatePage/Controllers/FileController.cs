using FileUploadLayer;
using Microsoft.AspNetCore.Mvc;

namespace CreatePage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly FileDAO _fileDAO;
        public FileController(FileDAO fileDAO)
        {
            _fileDAO = fileDAO;
        }

        [HttpPost("upload")]
        public async Task<ActionResult> UploadFile()
        {
            _fileDAO.UploadFile();
            return Ok();
        }
    }
}
