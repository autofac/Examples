using Autofac;

namespace AspNetCoreExample;

// ASP.NET Core docs for Autofac are here:
// https://autofac.readthedocs.io/en/latest/integration/aspnetcore.html
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Use extensions from libraries to register services in the
        // collection. These will be automatically added to the
        // Autofac container.
        services.AddControllers();
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        // Add any Autofac modules or registrations.
        // This is called AFTER ConfigureServices so things you
        // register here OVERRIDE things registered in ConfigureServices.
        builder.RegisterModule(new AutofacModule());
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
