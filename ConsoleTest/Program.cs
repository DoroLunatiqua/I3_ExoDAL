using BLL.Entities;
using BLL.Services;
using Common.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //UserService service = new UserService();
            //service.Delete(Guid.Parse("70941061-ed03-444c-9649-1b9fa8a5503f"));
            //foreach (User u in service.Get())
            //{
            //    if (u.IsDisabled)
            //    {
            //        Console.BackgroundColor = ConsoleColor.DarkRed;
            //        Console.ForegroundColor = ConsoleColor.White;
            //    }
            //    Console.WriteLine($"{u.User_Id} : {u.First_Name} {u.Last_Name} - {u.Email} : {u.Password}");
            //    Console.ResetColor();
            //}

            ServiceProvider serviceProvider = new ServiceCollection()
    .AddScoped<ICocktailRepository<DAL.Entities.Cocktail>, DAL.Services.CocktailService>()
    .AddScoped<BLL.Services.CocktailService>()
    .BuildServiceProvider();
            BLL.Services.CocktailService service = serviceProvider.GetRequiredService<BLL.Services.CocktailService>();

            foreach (Cocktail cocktail in service.Get())
            {
                Console.WriteLine($"{cocktail.Cocktail_id} : {cocktail.Name}");
            }
            

            
        }
    }
}
