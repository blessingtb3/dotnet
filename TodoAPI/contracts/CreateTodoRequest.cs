/*This CreateTodoRequest DTO will define the structure and validation rules for creating a new Todo item.*/

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

public class CreateTodoRequest{
    [Required]
    [StringLength(100)]
    public string Title { get; set; }
    
    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Range(1, 5)]
    public int Priority { get; set; }
}

/*In this DTO, we've defined properties for Title, Description, DueDate, and Priority. 
We've also added validation attributes like [Required], [StringLength], and [Range] 
to enforce certain rules on these properties.*/