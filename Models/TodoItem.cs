using System;
using System.ComponentModel.DataAnnotations;

namespace Todo_List.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string OwnerId { get; set; }
        
        public bool IsDone { get; set; }

        public DateTime LastModification { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
