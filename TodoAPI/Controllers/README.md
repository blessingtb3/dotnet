# Controllers
In ASP.NET Core, controllers are responsible for handling incoming HTTP requests and sending responses. They serve as the entry point for our API, defining the routes and actions that clients can interact with.

# Todo Controller class
- The TodoController class inherits from ControllerBase, a base class provided by ASP.NET Core for creating controllers. We've also added a route prefix of api/[controller] to the controller, which will be used as the base route for all actions in the controller.