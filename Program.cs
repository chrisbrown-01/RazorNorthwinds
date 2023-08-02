using MediatR;
using Microsoft.EntityFrameworkCore;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Behaviours;

// TODO: update Details/Index/etc. titles in pages to be relevant to their specific page
// TODO: README notes that this project is simply for experimenting with EF Core, Mediatr and GraphQL. Therefore no features that I would otherwise normally include such as table result pagination/sorting/filtering, overposting protections, decimal precisions in webpage renders, etc.
// TODO: delete unused classes and DbSets
// TODO: find better use for notification
// TODO: simple .txt log file
// TODO: order create --> include products (order details)
// TODO: improve year input field to be all inline
// TODO: delete privacy page, include main pages in nav bar at top

namespace RazorNorthwinds
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<NorthwindsDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<NorthwindsDbRepo>();

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}