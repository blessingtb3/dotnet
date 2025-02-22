//Models/Todo.cs
using System.ComponentModel.DataAnnotations;

//Todo model with respective attributes and Todo contructor
namespace TodoAPI.Models{

    public class Todo
    {
        //attributes
        [Key] //[Key] tag tells us that Id is the main way to identify each Todo item in our database
        public Guid Id { get; set; } //A special number that makes each Todo item unique
        public string Title { get; set; } //The name of the Todo item
        public string Description { get; set; } //Extra details about the Todo item
        public bool IsComplete { get; set; } //Whether the Todo item is finished or not
        public DateTime DueDate { get; set; } //The date by which the Todo item needs to be done
        public int Priority { get; set; } //How important the Todo item is
        public DateTime CreatedAt { get; set; } //When the Todo item was first made 
        public DateTime UpdatedAt { get; set; } //When the Todo item was last changed

        //constructor
        public Todo (){
            IsComplete = false;//initializing IsComplete as false
        }
    }
}