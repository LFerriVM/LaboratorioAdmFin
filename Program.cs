using admfin.Services;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        Console.WriteLine("Running");
        var menuService = serviceProvider.GetService<MenuService>();
        menuService.MenuBalanco();
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ItensService>();
        services.AddScoped<MenuService>();
    }
}
