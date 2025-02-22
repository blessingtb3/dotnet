//Todo.Controller.cs 
//responsible for handling incoming HTTP requests and sending responses. 
//serving as the entry point for our API, defining the routes and actions that clients can interact with.

using Microsoft.AspNetCore.Mvc;
using TodoAPI.Interface;

namespace TodoAPI.Controllers{
    [ApiController ]
    [Route("api/[controller]")]//adding a route prefix to the controller which will be used as the base route for all the actions in the controller
    public class TodoController : ControllerBase{//TodoController class inherits from ControllerBase, Base class from ASP.NET Core for creating controllers

        //properties/fields
        private readonly ITodoServices _todoServices;

        //constructor
        public TodoController(ITodoServices todoServices){
            _todoServices = todoServices;
        }
    }
}