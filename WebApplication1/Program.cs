using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplication.DataAccess.Abstract;
using MovieApplication.DataAccess.Concrete;
using MovieApplicationBusiness.Abstract;
using MovieApplicationBusiness.Concrete;
using MvApp1.Business.Abstract;
using MvApp1.Business.Concrete;
using MvApp1.DataAccess;
using MvApp1.DataAccess.Abstract;
using MvApp1.DataAccess.Concrete;
using System.Text.Json.Serialization;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),




            ServiceLifetime.Singleton); 
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSingleton<IMovieRepository, MovieRepository>();
            builder.Services.AddSingleton<IMovieService, MovieManager>();
            builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
            builder.Services.AddSingleton<ICategoryService, CategoryManager>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IUserService, UserManager>();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
                options.JsonSerializerOptions.MaxDepth = 32;
            });
            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<ApiBehaviorOptions>(x => { x.SuppressModelStateInvalidFilter=true; });
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