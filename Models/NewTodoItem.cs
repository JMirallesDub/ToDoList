using System;
using System.ComponentModel.DataAnnotations;

namespace Todo_List.Models
{
    public class NewTodoItem
    {
        [Required]
        public string Title { get; set; }
    }
}
