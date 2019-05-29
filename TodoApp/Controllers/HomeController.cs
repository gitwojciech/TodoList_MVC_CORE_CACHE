using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoTaskService _todoTaskService;
        private readonly IMapper _mapper;

        [TempData]
        public string ErrorMessage { get; set; }

        public HomeController(ITodoTaskService todoTaskService,IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _todoTaskService = todoTaskService;
            this._mapper = mapper;
        }

        public IActionResult Index()
        {

            var homeViewModel = new HomeViewModel()
            {
                TodoTasks = _todoTaskService.GetAll(),
                TodoTaskViewModel = _mapper.Map<TodoTaskViewModel>(new TodoTask())
            };
            return View(homeViewModel);

        }

        [HttpPost]
        public IActionResult Create(TodoTaskViewModel todoTaskViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData[nameof(ErrorMessage)] = "Please provide new task name";
            }
            else
            {
                var newTodoTask = _todoTaskService.Add(_mapper.Map<TodoTask>(todoTaskViewModel));
                if (newTodoTask == null || !_todoTaskService.Save())
                {
                    TempData[nameof(ErrorMessage)] = "New task creation failed";
                }

                
            }
            return PartialView("_TodoTaskList", _todoTaskService.GetAll());
        }


        //[HttpPost]
        public IActionResult Delete(int todoTaskId)
        {
            if (!_todoTaskService.Remove(todoTaskId) || !_todoTaskService.Save())
            {
                TempData[nameof(ErrorMessage)] = "Delete task failed";
            }
            ;

            return PartialView("_TodoTaskList", _todoTaskService.GetAll());
        }

        public void  CheckBoxAction(int todoTaskId, bool status)
        {
            _todoTaskService.UpdateStatus(todoTaskId,status);
            _todoTaskService.Save();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
