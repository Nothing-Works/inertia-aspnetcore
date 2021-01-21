using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;

namespace InertiaAdapter.Interfaces
{
    public interface IResultFactory
    {
        void Share(string key, object obj);

        void Share(string key, Func<object> func);

        IDictionary<string, object> GetShared();

        object GetSharedByKey(string key);

        void SetRootView(string s);

        void Version(string version);

        void Version(Func<string> version);

        string? GetVersion();

        IHtmlContent Html(dynamic model);

        IActionResult Render(string component, object controller);

        IActionResult Location(string url);
    }
}
