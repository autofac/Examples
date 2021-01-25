using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.UI;
using WebFormsExample.Dependencies;

namespace WebFormsExample
{
    [SuppressMessage("IDE1006", "IDE1006", Justification = "Underscore is required to avoid conflict with reserved keyword 'default'.")]
    public partial class _Default : Page
    {
        // This property will be set for you by the PropertyInjectionModule.
        public IDependency Dependency { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Now you can use the property that was set for you.
            this.DependencyLabel.Text = this.Dependency.InstanceId.ToString();
        }
    }
}