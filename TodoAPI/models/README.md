# What is a model
Before diving into creating models, it's important to know what a model does in .NET CORE. 
- Think of a model as a blueprint for the kind of data our application will work with. 
- It helps us organize and manage this data efficiently.
For our Todo list app, we need a clear picture of what each Todo item looks like. This means deciding on things like names, descriptions, whether it's done or not, deadlines, priorities, and when it was made or changed. By being clear about these details, we can handle and show our Todo items well.



# Todo model:
- Id: A special number that makes each Todo item unique.
- Title: The name of the Todo item.
- Description: Extra details about the Todo item.
- IsComplete: Whether the Todo item is finished or not.
- DueDate: The date by which the Todo item needs to be done.
- Priority: How important the Todo item is.
- CreatedAt and UpdatedAt: When the Todo item was first made and last changed.
The [Key] tag tells us that Id is the main way to identify each Todo item in our database.
By having a clear Todo model, we can easily keep track of and display our Todo items in the best way possible.



# Error Response model:
- This ErrorResponse model will be used to return error messages to the client when an error occurs in our application. It includes a title for the error, massage, and a status code, providing the client with useful information about what went wrong.



# DbSettings
- Designed to encapsulate the connection string for our database.
- Contains a single property, ConnectionString, which will store the actual connection string value.