using System;
using System.Collections.Generic;
using InertiaAdapter.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;

namespace InertiaAdapter
{
    public static class Inertia
    {
        private static IResultFactory _factory = new NullFactory();

        public static void Init(IResultFactory factory) => _factory = factory;

        public static IActionResult Render(string component, object controller) =>
            _factory.Render(component, controller);

        public static IActionResult Location(string url) => _factory.Location(url);

        public static string? GetVersion() => _factory.GetVersion();

        public static void SetRootView(string s) => _factory.SetRootView(s);

        public static void Version(string s) => _factory.Version(s);

        public static void Version(Func<string> s) => _factory.Version(s);

        public static IHtmlContent Html(dynamic m) => _factory.Html(m);

        public static void Share(string key, object obj) => _factory.Share(key, obj);

        public static void Share(string key, Func<object> func) => _factory.Share(key, func);

        public static IDictionary<string, object> GetShared() => _factory.GetShared();

        public static object GetSharedByKey(string key) => _factory.GetSharedByKey(key);
    }
}
