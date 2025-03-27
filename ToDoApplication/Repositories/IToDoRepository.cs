using ToDoApplication.Database.Models;

namespace ToDoApplication.Repositories
{
    public interface IToDoRepository
    {
        ToDo[] GetAll();
        void AddAll(ToDo[] toDos);
        void UpdateAll(ToDo[] toDos);
        void DeleteToDos(long[] toDos);
    }
}