# Music Albums Library - Task Resolution by Sergi Doce
This repository contains the resolution corresponding to the Music Albums Library task issued by Linkfire as a part of their hiring process. In this README file I describe the structure of the project and the main design decisions behind the software.

The project corresponds to a .NET Core solution that consists of 2 projects. One project corresponds to the music library microservice and the other one is a test project coded using the xUnit framework.

## Building and running the project
To build and run the project, .NET Core 6.0 and its CLI are needed. The steps to build and run the microservice project are the following:
1. Clone the repository, open a console window and navigate to the solution's folder (LibraryMicroservice/)
2. Navigate to the microservice project folder (LibraryMicroservice/LibraryMicroservice)
3. Run the command `dotnet restore` to restore any NuGet packages that might be needed.
4. Run the command `dotnet build` and afterwards `dotnet run` to build and run the project.
5. Open a browser window and navigate to https://localhost:7288/swagger/index.html. There you will find a UI to interact with the microservice's API. If the localhost port is not correct, take a look at the execution log in the console, there you should find the localhost address.

The steps to build and run the test project are the following:
1. Navigate to the test project folder (LibraryMicroservice/LibraryMicroserviceTest) using the console.
2. Run the command `dotnet restore` and `dotnet build`.
3. Run the command `dotnet test` to execute the tests.

You are naturally welcomed to open the solution using Visual Studio 2022 and interact with the project using the IDE.
 

## Software design and software principles behind the architecture
To have good, understandable and re-usable code, its components must be low-coupled to each other. In this task I have achieved this by:

1. Separating the code in different layers, having each one of them a defined responsability.
2. Using the Dependeny Inversion Principle.
3. Using the Dependency Injection design technique.

### Layers 

1. Controller layer, responsible for receiving requests and returning the adequate response.
2. Service layer, responsible for implementing most of the business logic.
3. Repository layer, responsible for communicating with the data provider. In this case because I haven't used a database service, this layer is also the place where I store the data.
4. Gateway layer, responsible for interacting with external API's. In this case with the Spotify API.

The interactions between layers are abstracted behind well defined interfaces to respect the Dependency Inversion Principle. This allows for a much readable and low coupled code, as it allows us to change interface implementations easily without having to change any other components. 

To implement Dependeny Injection, I have used the ASP.NET container that allows to instantiate dependencies that implement defined interfaces when constructing an object. This allows also for a low-coupled code as the classes do not need to know how to instantiate their dependencies in order to use them.

This is a general view, more concrete desing decisions are explained in the code as comments.

