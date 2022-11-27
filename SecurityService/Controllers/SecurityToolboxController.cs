using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WH.Common.Dtos;
using WH.Common.SecurityTools;

namespace SecurityService.Controllers
{
    [Route("api/security/toolbox")]
    [ApiController]
    public class SecurityToolboxController : ControllerBase
    {
        private readonly ILogger<SecurityToolboxController> _logger;

        public SecurityToolboxController(ILogger<SecurityToolboxController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("emailcensorship")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<EmailCensorshipResponseDto> CensorEmailWithBadWords([FromBody] EmailCensorshipRequestDto emailCensorshipDto)
        {
            try
            {
                var watch = new Stopwatch();
                watch.Start();

                var text = emailCensorshipDto.EmailText;

                EmailCensorshipResponseDto res = new()
                {
                    HasClassifiedWords = EmailHelpers.CensorClassifiedWords(emailCensorshipDto.ClassifiedWords.ToArray(), ref text),
                    EmailText = text,
                    ElapsedTime = watch.Elapsed
                };

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
