using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public class Startup {
    public void ConfigureServices(IServiceCollection services) {
        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app) {
        app.UseMvcWithDefaultRoute();
    }
}

namespace ConsoleApplication {
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
            
            string connectionString = "server=localhost;userid=ryan;pwd=0797;database=netcoremvc;sslmode=none;";
            
            // Create a book instance and save the entity to the database
            var entry = new Books() { Name = "The Book", Author = "John Winston" };
            
            using (var context = BooksContextFactory.Create(connectionString))
            {
                context.Add(entry);
                context.SaveChanges();
            }

            Console.WriteLine($"Book was saved in the database with id: {entry.Id}");

            builder.Run();
        }
    }
}