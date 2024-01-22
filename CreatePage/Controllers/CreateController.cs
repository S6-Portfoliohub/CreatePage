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

        public CreateController(MessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        [HttpPost("project")]
        public async Task<ActionResult> Project(ProjectViewModel project)
        {
            _messageSender.CreateProjectmessage(new() { UserID = project.UserID, Description = project.Description, Name = project.Name, Img = project.Img });
            return Ok();
        }

        [HttpDelete("project/{id}")]
        public async Task<ActionResult> Project(string id)
        {
            _messageSender.DeleteProjectMessage(id);
            return Ok();
        }
    }
}
