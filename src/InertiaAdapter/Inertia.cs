using System;
using System.Collections.Generic;
using InertiaAdapter.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;

namespace InertiaAdapter
{
    public static class Inertia
    {
        private static IResultFactory s_factory = new NullFactory();

        public static void Init(IResultFactory factory) => s_factory = factory;

        public static IActionResult Render(string component, object controller) =>
            s_factory.Render(component, controller);

        public static IActionResult Location(string url) => s_factory.Location(url);

        public static string? GetVersion() => s_factory.GetVersion();

        public static void SetRootView(string s) => s_factory.SetRootView(s);

        public static void Version(string s) => s_factory.Version(s);

        public static void Version(Func<string> s) => s_factory.Version(s);

        public static IHtmlContent Html(dynamic m) => s_factory.Html(m);

        public static void Share(string key, object obj) => s_factory.Share(key, obj);

        public static void Share(string key, Func<object> func) => s_factory.Share(key, func);

        public static IDictionary<string, object> GetShared() => s_factory.GetShared();

        public static object GetSharedByKey(string key) => s_factory.GetSharedByKey(key);
    }
}
