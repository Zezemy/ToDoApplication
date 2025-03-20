using ToDoApplication.Database.Models;

namespace ToDoApplication.Repositories
{
    public interface IToDoRepository
    {
        void AddAll(ToDo[] toDos);
        ToDo[] GetAll();
    }
}