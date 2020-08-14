# Inertia.js ASP.NET Core Adapter

Visit [inertiajs.com](https://inertiajs.com/) to learn more.

# Prerequisite

1. Latest SDK [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1).
2. Create `ASP.NET Core Web App (Model-View-Controller) mvc` project.

# Install

one of the following options.

1. Package Manager: `PM> Install-Package INERTIAJS.ASPNETCORE.ADAPTER`
2. .NET CLI: `dotnet add package INERTIAJS.ASPNETCORE.ADAPTER`

# Usage

1. SETUP `Startup.cs`

```csharp
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInertia();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //...
            app.UseInertia();
            //...
        }
```

2. Controller

```csharp
        public IActionResult Index()
        {
            //your js component file name.
            var componentName = "Welcome";
            //return whatever you want.
            var data = new { Id = 1 };
            //return Inertia Result.
            return Inertia.Render(componentName, data);
        }
```

3. View `App.cshtml`

```html
@using InertiaAdapter
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Inertia</title>
  </head>
  <body>
    @Inertia.Html(Model)

    <!-- reference your js file. -->
    <script src="/js/app.js"></script>
  </body>
</html>
```

4. Compile your assets. This is really your choice, choose whatever option you are comfortable with. (maybe I should add sample project for Vue).

# Examples
* [React](https://github.com/imrandyk/inertia-aspnetcore-react-example)