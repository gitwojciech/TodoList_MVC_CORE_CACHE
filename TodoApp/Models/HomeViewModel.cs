using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Models
{
    public class HomeViewModel
    {
        public IEnumerable<TodoTask> TodoTasks { get; set; }
        public TodoTaskViewModel TodoTaskViewModel { get; set; }
    }
}
