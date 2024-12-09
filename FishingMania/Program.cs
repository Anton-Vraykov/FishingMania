using FishingMania.Data;
using FishingMania.Data.Interface;
using FishingMania.Services.Data.Interface_and_services.Admin;
using FishingMania.Services.Data.Interface_and_services.Cars;
using FishingMania.Services.Data.Interface_and_services.Events;
using FishingMania.Services.Data.Interface_and_services.Hotels;
using FishingMania.Services.Data.Models.FishingPlaceModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static FishingMania.Common.ValidationConstant;


namespace FishingMania
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            string adminEmail = builder.Configuration.GetValue<string>("Administrator:Email")!;
            string adminUsername = builder.Configuration.GetValue<string>("Administrator:Username")!;
            string adminPassword = builder.Configuration.GetValue<string>("Administrator:Password")!;
            string adminId = builder.Configuration.GetValue<string>("Administrator:Id")!;
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddScoped<IFishingPlace, FishingPlaceServices>();
            builder.Services.AddScoped<IHotel, HotelServices>();
            builder.Services.AddScoped<ICar, CarServices>();
            builder.Services.AddScoped<IEvent,EventServices>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;

            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            builder.Services.AddControllersWithViews();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
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
                 name: "Areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "Errors",
                pattern: "{controller=Home}/{action=Index}/{statusCode?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            using (var scope = app.Services.CreateScope())
            {
                var roleManager=scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "User" };
                foreach (var role in roles)
                {
                    if(!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                    
                }
            }
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var admId = await userManager.FindByIdAsync(adminId);


                if (admId.Id != null)
                {
                    var user = new IdentityUser();
                    user.Id = adminId;
                    user.Email = adminEmail;
                    user.UserName = adminUsername;
                    await userManager.CreateAsync(user, adminPassword);
                    await userManager.AddToRoleAsync(user, AdminRoleName);
                }
            }
            app.Run();
        }
    }
    
}
