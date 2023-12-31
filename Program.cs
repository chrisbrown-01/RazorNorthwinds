using MediatR;
using Microsoft.EntityFrameworkCore;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Behaviours;
using Serilog;
using Serilog.Events;

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

            var useSqlServer = builder.Configuration.GetSection("UseSqlServerDatabase").Value;

            if (useSqlServer == "true")
            {
                var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection") ?? throw new InvalidOperationException("Connection string 'SqlServerConnection' not found.");

                builder.Services.AddDbContext<NorthwindsDbSqlServerContext>(options =>
                    options.UseSqlServer(connectionString));

                builder.Services.AddScoped<INorthwindsDbRepo, NorthwindsDbSqlServerRepo>();
            }
            else
            {
                var connectionString = builder.Configuration.GetConnectionString("SqliteConnection") ?? throw new InvalidOperationException("Connection string 'SqliteConnection' not found.");

                builder.Services.AddDbContext<NorthwindsDbSqliteContext>(options =>
                    options.UseSqlite(connectionString));

                builder.Services.AddScoped<INorthwindsDbRepo, NorthwindsDbSqliteRepo>();
            }

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