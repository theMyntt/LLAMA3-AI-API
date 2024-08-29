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
        private readonly LlamaRequest _service = new();
        
        [HttpPost]
        [Tags("Send a Message")]
        public async Task<IActionResult> Message([FromBody] PromptDTO dto) 
        {
            
            try 
            {
                var message = await _service.Prompt(dto.Message);
                return Ok(new PromptDTO { Message = message });
            } 
            catch (InvalidDataException) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new {
                    message = "API KEY is not set"
                });
            }
        }
    }
}
