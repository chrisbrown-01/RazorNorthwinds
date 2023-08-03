using MediatR;
using Microsoft.EntityFrameworkCore;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Behaviours;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog;
using NuGet.Protocol.Core.Types;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using RazorNorthwinds.GraphQL;

// TODO: README notes that this project is simply for experimenting with EF Core, Mediatr and GraphQL. Therefore no features that I would otherwise normally include such as table result pagination/sorting/filtering, overposting protections, decimal precisions in webpage renders, proper logging and exception handling, etc.
// TODO: try to publish to azure, see if database can be converted to in-database

namespace RazorNorthwinds
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Default sets minimum level to Information
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs.txt")
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .CreateLogger();

            Log.Information("Starting web application");

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog(); // redirect all log events through your Serilog pipeline

            // TODO: create a duplicate dbcontext for sqlite
            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            var connectionString = builder.Configuration.GetConnectionString("SqliteConnection") ?? throw new InvalidOperationException("Connection string 'SqliteConnection' not found.");

            builder.Services.AddDbContext<NorthwindsDbContext>(options =>
                options.UseSqlite(connectionString)
                //options.UseSqlServer(connectionString)
                );

            builder.Services.AddScoped<INorthwindsDbRepo, NorthwindsDbRepo>();

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            builder.Services.AddScoped<GraphQL.Query>();
            builder.Services.AddScoped<GraphQL.Mutation>();
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<GraphQL.Query>()
                .AddMutationType<GraphQL.Mutation>();

            var app = builder.Build();

            app.UseSerilogRequestLogging();

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

            app.MapGraphQL();

            app.Run();
        }
    }
}