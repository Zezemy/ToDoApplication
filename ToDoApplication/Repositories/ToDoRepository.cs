using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ToDoApplication.Controllers;
using ToDoApplication.Database.Models;
using ToDoApplication.Domain.ToDoEntities;

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

        public void UpdateAll(ToDo[] toDos)
        {
            foreach (var todo in toDos)
            {
                var toDoInDb = context.ToDos.Where(x => x.Id == todo.Id).FirstOrDefault();
                if (toDoInDb != null)
                {
                    toDoInDb.Title = todo.Title;
                    toDoInDb.Description = todo.Description;
                    toDoInDb.CreatedBy = todo.CreatedBy;
                    toDoInDb.CreateDate = todo.CreateDate;
                }
                context.SaveChanges();
            }
        }

        public void DeleteToDos(long[] idList)
        {
            foreach (var id in idList)
            {
                var toDoInDb = context.ToDos.Where(x => x.Id == id).FirstOrDefault();
                if (toDoInDb != null)
                {
                    context.ToDos.Remove(toDoInDb);
                }
                context.SaveChanges();
            }
        }
    }
}
