
using TaskTracker.Application;
using TaskTracker.Infrastructure;

namespace TaskTracker.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddApi(builder.Configuration).AddInfrastructureServices(builder.Configuration).AddApplication();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("AllowSpecificOrigins");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseMiddleware<TokenMiddleware>();


            app.MapControllers();

            app.Run();
        }
    }
}
