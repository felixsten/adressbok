
using adressbok.Models;
using adressbok.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{

    services.AddSingleton<MenuService>();
    services.AddSingleton<CustomerService>();
    services.AddSingleton<FileService>();

}).Build();

builder.Start();
Console.Clear();

var menuService = builder.Services.GetRequiredService<MenuService>();
menuService.ShowMainMenu();



