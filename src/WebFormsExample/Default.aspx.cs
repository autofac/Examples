using System;
using System.Linq;
using System.Web.UI;
using WebFormsExample.Dependencies;

namespace WebFormsExample
{
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