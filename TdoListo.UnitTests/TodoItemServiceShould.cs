using System;
using System.Threading.Tasks;
using Todo_List.Data;
using Todo_List.Models;
using Todo_List.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Todo_List.UnitTests
{
    public class TodoItemServiceShould
    {
        [Fact]
        public async Task AddNewItem()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_AddNewItem").Options;

            // Set up a context (connection to the DB) for writing
            using (var inMemoryContext = new ApplicationDbContext(options))
            {
                var service = new TodoItemService(inMemoryContext);

                var fakeUser = new ApplicationUser
                {
                    Id = "test_fake",
                    UserName = "fake@fake"
                };

                await service.AddItemAsync(new TodoItem { Title = "Test", LastModification = DateTime.Now }, fakeUser);
            }

            // Use a separate context to read the data back from the DB
            using (var inMemoryContext = new ApplicationDbContext(options))
            {
                Assert.Equal(1, await inMemoryContext.Items.CountAsync());
                
                var item = await inMemoryContext.Items.FirstAsync();
                Assert.Equal("test_fake", item.OwnerId);
                Assert.Equal("Test", item.Title);
                Assert.False(item.IsDone);
                Assert.True(item.LastModification.Date == DateTime.Now.Date);
            }
        }
    }
}
