using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;

namespace InertiaAdapter.Interfaces
{
    internal class NullFactory : IResultFactory
    {
        public void Share(string key, object obj) => throw new NotImplementedException();

        public void Share(string key, Func<object> func) => throw new NotImplementedException();

        public IDictionary<string, object> GetShared() => throw new NotImplementedException();

        public object GetSharedByKey(string key) => throw new NotImplementedException();

        public void SetRootView(string s) => throw new NotImplementedException();

        public void Version(string version) => throw new NotImplementedException();

        public void Version(Func<string> version) => throw new NotImplementedException();

        public string GetVersion() => throw new NotImplementedException();

        public IHtmlContent Html(dynamic model) => throw new NotImplementedException();

        public IActionResult Render(string component, object controller) => throw new NotImplementedException();

        public IActionResult Location(string url) => throw new NotImplementedException();
    }
}
