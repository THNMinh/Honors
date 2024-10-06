
using Microsoft.EntityFrameworkCore;
using VietKoiShow.Models;
using VietKoiShow.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VietKoiShow
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            builder.Services.AddDbContext<VietKoiExpoContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("KoiShow"));
            });

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddScoped<IKoiFishRepository, KoiFishRepository>();

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
//Data Source=MSI\\MSSQL2022EXPRESS;Initial Catalog=VietKoiExpo;Integrated Security=True;Trust Server Certificate=True
//dotnet ef dbcontext scaffold "Data Source = .\MSSQL2022EXPRESS; Initial Catalog = VietKoiExpo; Persist Security Info=True; User ID = sa; Password = 12345; Encrypt = False" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models
//Data Source = MSI\\MSSQL2022EXPRESS; Initial Catalog = VietKoiExpo; Persist Security Info=True; User ID = sa; Password = 12345; Encrypt = False