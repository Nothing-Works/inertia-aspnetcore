using InertiaAdapter;
using Microsoft.AspNetCore.Mvc;

namespace react.Controllers
{
    public class AppController : Controller
    {
        public AppController()
        {
        }

        public IActionResult Index()
        {
            //your js component file name.
            var componentName = "Welcome";
            //return whatever you want.
            var data = new { Id = 1 };
            //return Inertia Result.
            return Inertia.Render(componentName, data);
        }
    }
}
