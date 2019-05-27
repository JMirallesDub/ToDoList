using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo_List.Data;
using Todo_List.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Todo_List.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(TodoItem newItem, ApplicationUser user)
        {
            newItem.Id = Guid.NewGuid();
            newItem.OwnerId = user.Id;
            newItem.IsDone = false;
            newItem.LastModification = DateTime.Now;

            _context.Items.Add(newItem);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        //JMiralles
        //I created the next two method because from the specifications I didn't know if I have to show the completed task or not.
        public async Task<TodoItem[]> GetAllItemsAsync(ApplicationUser user)
        {
            return await _context.Items
                .Where(x => x.OwnerId == user.Id)
                .ToArrayAsync();
        }


        public async Task<TodoItem[]> GetIncompleteItemsAsync(ApplicationUser user)
        {
            return await _context.Items
                .Where(x => x.IsDone == false && x.OwnerId == user.Id)
                .ToArrayAsync();
        }

        public async Task<bool> MarkDoneAsync(Guid id, ApplicationUser user)
        {
            var item = await _context.Items
                .Where(x => x.Id == id && x.OwnerId == user.Id)
                .SingleOrDefaultAsync();

            if (item == null) return false;

            item.IsDone = item.IsDone ? false : true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }
    }
}
