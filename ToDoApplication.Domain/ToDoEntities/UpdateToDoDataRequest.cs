﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Database.Models;

namespace ToDoApplication.Domain.ToDoEntities
{
    public class UpdateToDoDataRequest
    {
        public ToDo[]? ToDoList {  get; set; }
    }
}
