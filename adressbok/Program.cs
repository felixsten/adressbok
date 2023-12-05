// See https://aka.ms/new-console-template for more information
using adressbok.Models;
using adressbok.Services;

var menuService = new MenuService();

menuService.ShowMainMenu();

Console.ReadKey();
