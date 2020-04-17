Problem when running migrations that has it's startup-projekt and data models in seperate locations, you need to specify that when you run the migrations.


```
Your startup project 'API' doesn't reference Microsoft.EntityFrameworkCore.Design. This package is required for the Entity Framework Core Tools to work. Ensure your startup project is correct, install the package, and try again.
```

My command was composed as this:

```
dotnet ef migrations add 'initial' --project ./src/Persistence --startup-project ./src/API/
```

The same goes to the database creation. It also needs to go trhough the startup project to run it and create the database during RunTime. It's kind of obvious because that is the place for the connection to the database and holds all info like the connectionstring etc...

```
dotnet ef database update --project ./src/Persistence --startup-project ./src/API/
```

**Options for the migrations:**
```
Target project and startup project

The commands refer to a project and a startup project.

The project is also known as the target project because it's where the commands add or remove files. By default, the project in the current directory is the target project. You can specify a different project as target project by using the --project option.

The startup project is the one that the tools build and run. The tools have to execute application code at design time to get information about the project, such as the database connection string and the configuration of the model. By default, the project in the current directory is the startup project. You can specify a different project as startup project by using the --startup-project option.

The startup project and target project are often the same project. A typical scenario where they are separate projects is when:

    The EF Core context and entity classes are in a .NET Core class library.
    A .NET Core console app or web app references the class library.

It's also possible to put migrations code in a class library separate from the EF Core context.
```
