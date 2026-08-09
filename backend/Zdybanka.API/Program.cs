
using Microsoft.EntityFrameworkCore;
using Zdybanka.Data;

namespace Zdybanka.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<ZdybankaContext>(options =>
        {
            options.UseNpgsql(connectionString: builder.Configuration.GetConnectionString("ConnectionString"), x => x.UseNetTopologySuite());
        });

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
