using Emailer.Models;
using Emailer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Emailer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("SendMail")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest mailRequest)
        {
            try
            {
                await _mailService.SendEmailAsync(mailRequest);
                return Ok();
            }
            catch (System.Exception err)
            {

                throw err;
            }
        }
    }
}
