using Blog.Core.Contracts;
using Blog.Core.Services;
using Blog.Infrastructure;
using Blog.Infrastructure.Data;
using Blog.Infrastructure.Seeding;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var adminName = configuration["AdminProfile:AdministratorName"];
var adminPassword = configuration["AdminProfile:AdministratorPassword"];
var adminRoleName = configuration["AdminRoleName"];
var adminEmail = configuration["AdminEmail"];

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options =>
options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BlogDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.Cookie.Name = "LoggedUser";
    options.LoginPath = "/Identity/Account/Login";
});

builder.Services.AddControllersWithViews()
    .AddCookieTempDataProvider();

//builder.Services.AddSession(options =>
//{
//    options.Cookie.Name = ".BlogLoginTime.Session";
//    options.IdleTimeout = TimeSpan.FromSeconds(100);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;

});

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.ConsentCookie.Name = "Blog_Consent";
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.ConsentCookie.Expiration = TimeSpan.FromMinutes(2);
});

builder.Services.AddAuthentication()
                .AddFacebook(options =>
                {
                    options.AppId = configuration["Authentication:Facebook:AppId"];
                    options.AppSecret = configuration["Authentication:Facebook:AppSecret"];
                });
                

//builder.Services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;


    await Seeder.Initialize(services, adminName,
        adminPassword, adminEmail, adminRoleName);

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app
   .UseHttpsRedirection()
   .UseStaticFiles()
   .UseCookiePolicy()
   .UseRouting()
   .UseAuthentication()
   .UseAuthorization();
//.UseSession();

app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.UseAuthentication(); ;

app.Run();
