using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoApp.Core.Models
{
    public class TodoTask
    {
        //[BindNever]
        public long Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
