
using Application.Interfaces;
using Application.Interfaces.RateInterface;
using Application.Interfaces.RecipeInterface;
using Application.Interfaces.RecipeMaterialInterface;
using Application.Interfaces.UserInterface;
using Application.Servicess;
using Application.Tools;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Repositories.RateRepositories;
using Persistence.Repositories.RecipeMaterialRepositories;
using Persistence.Repositories.RecipeRepositories;
using Persistence.Repositories.UserRepositories;
using System.Text;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false; //çok tavsiye edilen biþey deðil ama þimdilik güvenliði biraz yumuþattýk.
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = JwtTokenDefaults.ValidAudience,
                    ValidIssuer = JwtTokenDefaults.ValidIssuer,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

            // Add services to the container.

            builder.Services.AddScoped<YemekContext>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IRateRepository), typeof(RateRepository));
            builder.Services.AddScoped(typeof(IRecipeMaterialRepository), typeof(RecipeMaterialRepository));
            builder.Services.AddScoped(typeof(IRecipeRepository), typeof(RecipeRepository));
            builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

            builder.Services.AddSaveApplicationService();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Application.MapperProfiles.MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
