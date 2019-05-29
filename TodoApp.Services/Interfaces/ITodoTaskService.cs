using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Core.Models;

namespace TodoApp.Services.Interfaces
{
    public interface ITodoTaskService
    {
        IEnumerable<TodoTask> GetAll();
        TodoTask Add(TodoTask TodoTask);
        bool Remove(int TodoTaskId);
        TodoTask UpdateStatus(int TodoTaskId,bool status);
    }
}
