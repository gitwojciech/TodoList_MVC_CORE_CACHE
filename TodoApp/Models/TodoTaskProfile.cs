using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Models
{
    class TodoTaskProfile : Profile
    {
        public TodoTaskProfile()
        {
            this.CreateMap<TodoTask,TodoTaskViewModel>()
                .ReverseMap();
        }
    }
}
