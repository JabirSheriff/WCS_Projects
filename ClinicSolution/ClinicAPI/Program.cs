using ClinicAPI.Contexts;
using ClinicAPI.Interfaces;
using ClinicAPI.Misc;
using ClinicAPI.Models;
using ClinicAPI.Models.DTOs;
using ClinicAPI.Repositories;
using ClinicAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Log4Net;

namespace ClinicAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Logging.AddLog4Net();

            builder.Services.AddScoped<CustomExceptionFilter>();

            builder.Services.AddDbContext<ClinicContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddTransient<IRepository<int, Patient>, PatientRepository>();
            builder.Services.AddTransient<IRepository<string, User>, UserRepository>();

            builder.Services.AddTransient<IAuthorize<Patient, LoginResponseDto>, PatientService>();
            builder.Services.AddTransient<IPatientService, PatientService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}