using Application.Interfaces.RecipeInterface;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace YemekWebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.
            //builder.Services.AddScoped<YemekContext>();
            //builder.Services.AddScoped(typeof(IRecipeRepository), typeof(RecipeRepository));


            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
                {
                    opt.LoginPath = "/Login/Index/";
                    opt.LogoutPath = "/login/LogOut";
                    opt.AccessDeniedPath = "/Pages/AccessDenied/"; // bu sayfay� olusturup tasarl�caks�n daha.
                    opt.Cookie.SameSite = SameSiteMode.Strict;
                    opt.Cookie.HttpOnly = true;
                    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                    opt.Cookie.Name = "YemekUygulamasiJwt";
                });




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //baz� fotolar�n cash den gelmesini sa�lamak i�in buran�n i�erisine birtak�m �eyler yapabiliyoruz. ara�t�r. hoca anlatt� hafta7
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");


            //area kullan�m� i�in
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapDefaultControllerRoute();
            });


            app.Run();
        }
    }
}
