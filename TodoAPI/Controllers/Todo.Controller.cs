//Todo.Controller.cs 
//responsible for handling incoming HTTP requests and sending responses. 
//serving as the entry point for our API, defining the routes and actions that clients can interact with.

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using TodoAPI.Contracts;
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

        //Implementing CreateTodoAsync method to handle the creation of new Todo items in our db
        [HttpPost]
        public async Task<IActionResult> CreateTodoAsync(CreateTodoRequest request){

            if(!ModelState.IsValid){//checeking if the request model is valid
                return BadRequest(ModelState);//returning a bad request response with the model state errors
            }

            try{
                await _todoServices.CreateTodoAsync(request);//calling CreateTodoAsync method from the ITodoServices interface to create a new Todo item in the db
                return Ok(new { message = "Blog post successfully created"});//returning a success response for the creation of a todo item
            }catch(Exception ex){
                return StatusCode(500, new { message = "An error occurred while creating the blog post", error = ex.Message});
            }//returning a server error response if an exception occurs while creating the todo item
        }

        //Implementing GetTodosAsync method to handle the retrieval of all Todo items in our db
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(){
            try{
                var todo = await _todoServices.GetAllAsync();//calling GetAllAsync method from the ITodoServices interface to fetch all Todo items from the db
                if(todo == null){
                    return Ok(new { message = "No todo items found"});//returning a success response if no todo items are found
                }
                return Ok(new { message = "Successfully retrieved all blog posts", data = todo});//returning a success response for the retrieval of all todo items
            }catch(Exception ex){
                return StatusCode(500, new { message = "An error occurred while retrieving all Todo items posts", error = ex.Message});//returning a 500 internal server error with an error message if an error occurs during the retrieval process
            }
        }
    }
}