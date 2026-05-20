using Autofac;
using Autofac.Extensions.DependencyInjection;
using AspNetCoreNoStartupExample;

// This example shows how to use Autofac with the minimal hosting model
// (no Startup class). Everything is configured inline in Program.cs.
// Compare with the AspNetCoreExample which uses a Startup class.

var builder = WebApplication.CreateBuilder(args);

// Use Autofac as the service provider factory. This replaces the
// default Microsoft DI container with Autofac.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// ConfigureContainer gives you a strongly-typed ContainerBuilder.
// This is called AFTER ConfigureServices, so registrations here
// override those from ConfigureServices.
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacModule());
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
