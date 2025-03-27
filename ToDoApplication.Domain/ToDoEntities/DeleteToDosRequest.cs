using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Database.Models;

namespace ToDoApplication.Domain.ToDoEntities
{
    public class DeleteToDosRequest
    {
        public long[] ToDoList {  get; set; }
    }
}
