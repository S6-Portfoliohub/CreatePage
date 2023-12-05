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

        [HttpGet("test")]
        public async Task<ActionResult> test()
        {
            _messageSender.Sendmessage();
            return Ok();
        }
    }
}
