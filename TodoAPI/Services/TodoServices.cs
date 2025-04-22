//Service class that implements methods defined in our TodoAPI interface. 
// We'll use Dependency Injection to inject the ITodoServices interface into the service class, 
// making our code more modular, testable, and maintainable.

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoAPI.AppDataContext;
using TodoAPI.Contracts;
using TodoAPI.Interface;
using TodoAPI.Models;

namespace TodoAPI.Services{
    public class TodoServices : ITodoServices{ //TodoServices class implementing ITodoServices interface with all it's methods

        //properties
        private readonly TodoDbContext _context; //instance of the TodoDbContext class, enabling us to interact with the database
        private readonly ILogger<TodoServices> _logger; //instance of the ILogger class, enabling us to log messages throughout the application
        private readonly IMapper _mapper; //instance of the IMapper class, enabling us to perform object-to-objecet mapping using AutoMapper
        public string errMessage = "An error occured while creating the Todo item";

        //constructor
        public TodoServices(TodoDbContext context, ILogger<TodoServices> logger, IMapper mapper){
            //injecting dependencies(the TodoDbContext, ILogger, and IMapper instances into the TodoServices class)
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        //With these dependencies injected, we're now ready to implement the methods defined in the ITodoServices interface. 
        //We'll begin with the GetAllAsync method in the next section.

        public async Task CreateTodoAsync(CreateTodoRequest request)
        {
            try{
                var todo = _mapper.Map<Todo>(request);//using AutoMapper to convert the CreateTodoRequest object into a todo entity
                todo.CreatedAt = DateTime.UtcNow;//setting the CreatedAt property of the todo entity to the current UTC date and time
                _context.Todos.Add(todo);//Adding the Todo entity to the Todos DbSet in our context
                await _context.SaveChangesAsync();//Saving the changes asynchronously
            }catch(Exception ex){//catching exceptions, logging the error and throwing a new exception with a descriptive message
                _logger.LogError(ex, errMessage);
                throw new Exception(errMessage);
            }
        }//With the CreateTodoAsync method implemented, we can now create new Todo items in our database.

        public Task DeleteTodoAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()//Get all todos from db
        {
            var todo = await _context.Todos.ToListAsync();//Using Entity Framework Core's ToListAsync method to fetch all Todo items from the database
            if(todo == null){
                throw new Exception("No Todo items found");//Throwing an exception if no Todo items are found
            }
            return todo;
        }

        public Task<Todo> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTodoAsync(Guid id, UpdateTodoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}