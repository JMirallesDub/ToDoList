using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo_List.Models;

namespace Todo_List.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync(ApplicationUser user);

        Task<TodoItem[]> GetAllItemsAsync(ApplicationUser user);

        Task<bool> AddItemAsync(TodoItem newItem, ApplicationUser user);
        
        Task<bool> MarkDoneAsync(Guid id, ApplicationUser user);
    }
}
