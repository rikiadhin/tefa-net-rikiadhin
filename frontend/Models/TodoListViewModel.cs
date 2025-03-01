using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class TodoList
    {  
        public int TodoListId { get; set; }

        [Required] 
        [DisplayName("Title")]
        public required string Judul { get; set; }

        [Required] 
        [DisplayName("Description")]
        public required string Description { get; set; }
 
        [Required] 
        [DisplayName("Date Created")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
 
        [Required] 
        [DisplayName("Last Modified")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}