using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ToDoApplication.Controllers;
using ToDoApplication.Database.Models;

namespace ToDoApplication.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ILogger<ToDoController> logger;
        private readonly ToDoApplicationDbContext context;

        public ToDoRepository(ILogger<ToDoController> logger, ToDoApplicationDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public ToDo[] GetAll()
        {
            return context.ToDos.ToArray();
        }
        public void AddAll(ToDo[] toDos)
        {
            context.ToDos.AddRange(toDos);
            context.SaveChanges();
        }
    }
}
