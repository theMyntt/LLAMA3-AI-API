using System;
using System.ComponentModel.DataAnnotations;

namespace llama_api.DTOs;

public class PromptDTO
{
    [Required]
    public required string Message { get;set; }
}
