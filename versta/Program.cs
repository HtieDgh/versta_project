
namespace versta
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ///////////////////////////////////////////////////////////////////////////
            //venv
            builder.Configuration
                .AddJsonFile("./.venv/config.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();
            // wwwroot static files are turned on
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
