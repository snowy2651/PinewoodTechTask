using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PinewoodApi.Data;

namespace PinewoodApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<PinewoodApiContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("PinewoodApiContext") ?? throw new InvalidOperationException("Connection string 'PinewoodApiContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
