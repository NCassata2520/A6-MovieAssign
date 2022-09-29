using System;
using System.Net.NetworkInformation;
using AbstractExample.Models;
using Class_5.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Class_5;

public class Program
{
    /// <summary>
    /// Entry point for the MainService.  It is unlikely you will need to update this.
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {

        var services = new ServiceCollection();
        Media media = new Show();
        Console.WriteLine("Which media would you like to display?");
        Console.WriteLine("Movie[1]  , Show [2]  , Video [3]");
        var choice = Console.ReadLine();

       

        if (choice == "1")
        {
            media.Display(Movie);
        }
        else if (choice == "2")
        {
            media.Display(Show);
        }
        else if (choice == "3")
        {
            media.Display(Video);
            }
       
        try
        {
            var startup = new Startup();
            var serviceProvider = startup.ConfigureServices();
            var service = serviceProvider.GetService<IMainService>();

            service?.Invoke();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }
    }
}
