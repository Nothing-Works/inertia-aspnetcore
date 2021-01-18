using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Web;
using InertiaAdapter.Interfaces;
using InertiaAdapter.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;

namespace InertiaAdapter.Core
{
    internal class ResultFactory : IResultFactory
    {
        private readonly SharedProps _share = new();

        private string _rootView = "Views/App.cshtml";

        private object? _version;

        public void Share(string key, object obj) => _share.AddOrUpdate(key, obj);

        public void Share(string key, Func<object> func) => _share.AddOrUpdate(key, func);

        public Dictionary<string, object> GetShared() => _share.Value;

        public object GetSharedByKey(string key) => _share.GetValue(key);

        public void SetRootView(string s) => _rootView = s;

        public void Version(string version) => _version = version;

        public void Version(Func<string> version) => _version = version;

        public string? GetVersion() =>
            _version switch
            {
                Func<string> func => func(),
                string s => s,
                _ => null
            };

        public IHtmlContent Html(dynamic model)
        {
            string data = JsonSerializer.Serialize(model,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            data = HttpUtility.HtmlEncode(data);


            return new HtmlString($"<div id=\"app\" data-page=\"{data}\"></div>");
        }

        public IActionResult Render(string component, object controller) =>
            new Result(new Props { Controller = controller, SharedProps = _share.Value }, component, _rootView,
                GetVersion());
    }
}
