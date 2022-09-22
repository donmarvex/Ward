using RoyalKiddiesWard.Data.Models;
using Microsoft.EntityFrameworkCore;
using RoyalKiddiesWard.Data;

namespace RoyalKiddiesWard.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
           builder.Services.AddDbContext<RoyalKiddiesWardDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("RoyalKiddiesWardConnection")),
             ServiceLifetime.Scoped);
         

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