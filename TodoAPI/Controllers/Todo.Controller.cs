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

//Now that we have implemented the controller, we can test the API using tools like Postman or Swagger UI.
//.NET 8 includes a built-in Swagger UI. 
// This feature allows us to interact with our API endpoints directly from a web browser. 
// To access the Swagger UI, run your application then open your browser and navigate to https://localhost:5086/swagger/index.html. 
// You should see a page with the swagger UI, however it will not work until you make your connection string and migrations.:
//Also , install all relevant nugget packages found in our csproj file
/*
    <PackageReference Include="AutoMapper" Version="13.0.1" />
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.2" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.2" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="9.0.2" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.2" /> 
    <PackageReference Include="Microsoft.OpenApi" Version="1.6.22" />
    <PackageReference Include="Swashbuckle.AspNetCore.Swagger" Version="7.2.0" />
    <PackageReference Include="Swashbuckle.AspNetCore.SwaggerGen" Version="7.2.0" />
    <PackageReference Include="Swashbuckle.AspNetCore.SwaggerUI" Version="7.2.0" />
*/
//To create the database and apply the migrations, run the following commands in the terminal:
//dotnet ef migrations add InitialCreate --output-dir Data/Migrations
//dotnet ef database update
//This will create the database and apply the migrations, allowing you to interact with the API using the Swagger UI.
//You can now test the API by creating and retrieving Todo items using the Swagger UI or Postman.
//This is a basic example of how to create a RESTful API using ASP.NET Core and Entity Framework Core.
//You can further enhance the API by adding more features like authentication, authorization, and validation.
//You can also explore other features of ASP.NET Core and Entity Framework Core to build more complex and robust applications.