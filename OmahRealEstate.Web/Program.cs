
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OmahRealEstate.Web.Data;
using OmahRealEstate.Web.Data.Entities;
using OmahRealEstate.Web.Data.Repositories;
using OmahRealEstate.Web.Data.Repositories.Interfaces;
using OmahRealEstate.Web.Helpers;

namespace OmahRealEstate.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddIdentity<User, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequiredUniqueChars = 0;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequiredLength = 6;

            }).AddEntityFrameworkStores<DataContext>();

            
            builder.Services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<SeedDb>();
            builder.Services.AddScoped<IUserHelper, UserHelper>();
            builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
            builder.Services.AddScoped<IPropertyListingRepository, PropertyListingRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<SeedDb>();
                seeder.SeedAsync().Wait();
            }


            app.Run();
        }

    }
}
