using System;
using System.Linq;
using System.Web.Mvc;
using MvcExample.Dependencies;

namespace MvcExample
{
    /// <summary>
    /// Custom view page base class to illustrate view injection.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.WebViewPage" />
    public abstract class CustomViewPage<TModel> : WebViewPage<TModel>
    {
        public IViewDependency Dependency { get; set; }
    }
}
