using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Text.Json.Serialization;

namespace backend.Data.Dto
{
    public class CreateUpdateTodoListDto
    { 
        [Required] 
        public required string Judul { get; set; }

        [Required] 
        public required string Description { get; set; } 
    }
}