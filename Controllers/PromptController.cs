using llama_api.DTOs;
using llama_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace llama_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptController : ControllerBase
    {
        [HttpPost("prompt")]
        [Tags("Send a Message")]
        public async Task<IActionResult> Message([FromBody] PromptDTO dto) 
        {
            var message = await LlamaRequest.Prompt(dto.Message);
            return Ok(new PromptDTO { Message = message });
        }
    }
}
