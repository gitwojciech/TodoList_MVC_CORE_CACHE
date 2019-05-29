using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        readonly List<TodoTask> _todoTasks;
        const string sessionKey = "ToDoList";
        readonly IHttpContextAccessor _contextAccessor;

        public TodoTaskService(IHttpContextAccessor contextAccessor)
        {

            this._contextAccessor = contextAccessor;

            //Initialize
            var value = contextAccessor.HttpContext.Session.GetString(sessionKey);
            if (string.IsNullOrEmpty(value))
            {
                _todoTasks = new List<TodoTask>();
                var serialisedDate = JsonConvert.SerializeObject(_todoTasks);
                contextAccessor.HttpContext.Session.SetString(sessionKey, serialisedDate);
            }
            else
            {
                _todoTasks = JsonConvert.DeserializeObject<List<TodoTask>>(value);
            }
        }


        public TodoTask Add(TodoTask TodoTask)
        {
            if (TodoTask != null)
            {
                _todoTasks.Add(TodoTask);
                TodoTask.Id = _todoTasks.Max(r => r.Id) + 1;
                TodoTask.Status = false;
            }
            return TodoTask;
        }

        public IEnumerable<TodoTask> GetAll()
        {
            return _todoTasks;
        }


        public bool Remove(int TodoTaskId)
        {
            TodoTask todoTask = _todoTasks.SingleOrDefault(r => r.Id == TodoTaskId);
            if (todoTask != null)
            {
                _todoTasks.Remove(todoTask);
            }

            if (_todoTasks.SingleOrDefault(r => r.Id == TodoTaskId) != null)
            {
                return false;
            }

            return true;

        }

        public TodoTask UpdateStatus(int TodoTaskId,bool status)
        {
            TodoTask task = _todoTasks.SingleOrDefault(r => r.Id == TodoTaskId);
            if (task != null)
            {
                task.Status = status;
            }
            return task;
        }

        public bool Save()
        {
            _contextAccessor.HttpContext.Session.SetString(sessionKey, JsonConvert.SerializeObject(_todoTasks));
            return true;
        }
    }
}
