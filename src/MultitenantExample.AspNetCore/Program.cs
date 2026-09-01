namespace MultitenantExample.AspNetCore;

public static class Program
{
    public static void Main(string[] args)
    {
        // AutofacMultitenantServiceProviderFactory takes the method that turns the
        // built application container into a MultitenantContainer, which is where
        // per-tenant overrides live.
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(
                new AutofacMultitenantServiceProviderFactory(MultitenantContainerSetup.ConfigureMultitenantContainer))
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            .Build()
            .Run();
    }
}
