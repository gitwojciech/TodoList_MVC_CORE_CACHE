using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Models;

namespace TodoApp.Services
{
    public interface ITodoTaskService
    {
        IEnumerable<TodoTask> GetAll();
        TodoTask Add(TodoTask TodoTask);
        bool Remove(int TodoTaskId);
        TodoTask UpdateStatus(int TodoTaskId,bool status);
        bool Save();
    }
}
