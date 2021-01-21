using System;
using System.Collections.Generic;
using System.Linq;
using InertiaAdapter.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;

namespace InertiaAdapter.Extensions
{
    internal static class ResultExtensions
    {
        internal static IResultFactory ResultFactory(this IApplicationBuilder app) =>
            app.NotNull().ApplicationServices.GetRequiredService<IResultFactory>();

        internal static string ComponentName(this ActionContext? ac) =>
            ac.NotNull().HttpContext.Request.Headers["X-Inertia-Partial-Component"];

        internal static IList<string> Only(this object? obj, IList<string> list) =>
            obj?.GetType().GetProperties().Select(c => c.Name).Intersect(list).ToList() ??
            new List<string>();

        internal static bool IsLazy(this object obj) =>
            obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(Lazy<>);

        internal static void ConfigureResponse(this ActionContext? ac)
        {
            ac.NotNull().HttpContext.Response.Headers.Add("Vary", "Accept");
            ac.NotNull().HttpContext.Response.Headers.Add("X-Inertia", "true");
            ac.NotNull().HttpContext.Response.StatusCode = 200;
        }

        internal static HttpResponse Configure409Response(this HttpContext hc)
        {
            hc.Response.Headers.Add("X-Inertia-Location", hc.RequestedUri());
            hc.Response.StatusCode = 409;

            return hc.Response;
        }

        internal static string RequestedUri(this ActionContext? ac) =>
            Uri.UnescapeDataString(ac.NotNull().HttpContext.Request.GetEncodedPathAndQuery());

        internal static string RequestedUri(this HttpContext? hc) =>
            Uri.UnescapeDataString(hc.NotNull().Request.GetEncodedPathAndQuery());

        internal static ITempDataDictionary TempData(this IApplicationBuilder ab, HttpContext hc) =>
            ab.ApplicationServices.GetService<ITempDataDictionaryFactory>().GetTempData(hc);

        internal static IList<string> GetPartialData(this ActionContext? ac) =>
            ac
                .NotNull()
                .HttpContext
                .Request
                .Headers["X-Inertia-Partial-Data"]
                .FirstOrDefault()?
                .Split(",")
                .Where(c => !string.IsNullOrEmpty(c))
                .ToList() ?? new List<string>();
    }
}
