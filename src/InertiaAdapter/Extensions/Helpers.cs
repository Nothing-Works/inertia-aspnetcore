using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InertiaAdapter.Extensions
{
    public static class Helpers
    {
        internal static T NotNull<T>([NotNull] this T? value) where T : class =>
            value ?? throw new ArgumentNullException(nameof(value));

        internal static object Value([NotNull] this object? obj, string propertyName) =>
            obj?.GetType().GetProperty(propertyName)?.GetValue(obj, null) ??
            throw new NullReferenceException();

        public static bool IsInertiaRequest(this HttpRequest? request) =>
            bool.TryParse(request.NotNull().Headers["X-Inertia"], out _);

        public static bool IsInertiaRequest(this HttpContext? hc) =>
            bool.TryParse(hc.NotNull().Request.Headers["X-Inertia"], out _);

        public static bool IsInertiaRequest(this ActionContext? ac) =>
            bool.TryParse(ac.NotNull().HttpContext.Request.Headers["X-Inertia"], out _);
    }
}
