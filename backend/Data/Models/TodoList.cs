using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Text.Json.Serialization;

namespace backend.Data.Models
{
     [Table("todolists")]
     public class TodoList
     { 
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
          [Column("id_todolists")]
          public int TodoListId { get; set; } 

          [Required]
          [MaxLength(255)]
          [Column("judul")]
          public required string Judul { get; set; }

          [Required]
          [MaxLength(255)]
          [Column("description")]
          public required string Description { get; set; }

          // Automatically tracks when the record was created 
          [Required]
          [Column("created_at")]
          public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

          // Automatically tracks the last update of the record 
          [Required]
          [Column("updated_at")]
          public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

          // Updating UpdatedAt automatically whenever record is updated
          public void OnUpdate()
          {
               UpdatedAt = DateTime.UtcNow;
          }
     }
}
