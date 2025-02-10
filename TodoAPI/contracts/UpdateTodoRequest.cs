// This UpdateTodoRequest DTO will define the structure and validation rules for updating an existing Todo item.

using System.ComponentModel.DataAnnotations;

public class UpdateTodoRequest{

    [StringLength(100)]
    public string Title { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    public bool? IsComplete { get; set; }

    public DateTime? DueDate { get; set; }

    [Range(1, 5)]
    public int? Priority { get; set; }


    public UpdateTodoRequest(){
        IsComplete = false;
    }
}


/*In this DTO, we've defined properties for Title, Description, IsComplete, DueDate, and Priority. 
The IsComplete property is nullable, which means it can be set to null if not provided. 
We've also added validation attributes like [StringLength] and [Range] to enforce certain rules on these properties.*/