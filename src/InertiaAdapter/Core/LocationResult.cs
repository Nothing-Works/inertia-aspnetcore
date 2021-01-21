using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InertiaAdapter.Core
{
    internal class LocationResult : IActionResult
    {
        private readonly string _url;

        public LocationResult(string url) => _url = url;

        public async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Inertia-Location", _url);
            await new StatusCodeResult((int)HttpStatusCode.Conflict).ExecuteResultAsync(context);
        }
    }
}
