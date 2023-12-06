using CreatePage.Models;
using MessagingLayer;
using Microsoft.AspNetCore.Mvc;

namespace CreatePage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateController : ControllerBase
    {
        private readonly MessageSender _messageSender;

        public CreateController()
        {
            _messageSender = new MessageSender();
        }

        [HttpPost("test")]
        public async Task<ActionResult> test(ProjectViewModel project)
        {
            _messageSender.CreateProjectmessage(new() { UserID = project.UserID, Description = project.Description, Name = project.Name, Img = project.Img });
            return Ok();
        }
    }
}
