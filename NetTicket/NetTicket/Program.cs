using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NetTicket.DependencyInjection;
using NetTicket.Presentation.Menu;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;


try
{
    IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

    Console.Title = Environment.GetEnvironmentVariable("APP_NAME") ?? "NetTicket";

    var services = new ServiceCollection();
    services.AddSingleton<IConfiguration>(configuration);

    services.AddNetTicketData();
    services.AddNetTicketPresentation();
    services.AddNetTicketService();

    var provider =  services.BuildServiceProvider();
    await provider.GetRequiredService<Menu>().Iniciar(); 


}
catch(Exception ex)
{
    Console.WriteLine("Program.cs: " + ex.Message);
}

