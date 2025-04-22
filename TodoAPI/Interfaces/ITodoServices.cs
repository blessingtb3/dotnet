using TodoAPI.Contracts;
using TodoAPI.Models;

namespace TodoAPI.Interface{
    public interface ITodoServices{
        Task<IEnumerable<Todo>> GetAllAsync();//Get all todos from db
        Task<Todo> GetByIdAsync(Guid id);//Get a todo by id from db
        Task CreateTodoAsync(CreateTodoRequest request);//Create todo and add to db
        Task UpdateTodoAsync(Guid id, UpdateTodoRequest request);//Update todo in db
        Task DeleteTodoAsync(Guid id);//Delete todo from db
    }
}

//Now, let's create a service class(Services/TodoServices.cs) that implements these methods. 
// We'll use Dependency Injection to inject the ITodoServices interface into the service class, 
// making our code more modular, testable, and maintainable.