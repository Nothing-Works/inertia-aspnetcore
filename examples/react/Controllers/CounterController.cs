using InertiaAdapter;
using Microsoft.AspNetCore.Mvc;

namespace react.Controllers
{
    public class CounterController : Controller
    {
        public CounterController()
        {
        }

        public IActionResult Index()
        {
            //your js component file name.
            var componentName = "Counter";
            //return whatever you want.
            var data = new { initialValue = 0 };
            //return Inertia Result.
            return Inertia.Render(componentName, data);
        }
    }
}
