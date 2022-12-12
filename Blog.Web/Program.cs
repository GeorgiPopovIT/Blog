using Blog.Core.Contracts;
using Blog.Core.EmailSender;
using Blog.Core.Models.Emails;
using Blog.Core.Services;
using Blog.Infrastructure;
using Blog.Infrastructure.Data;
using Blog.Infrastructure.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SendGrid.Extensions.DependencyInjection;
using SendGrid.Helpers.Mail;
using System.Configuration;
using System.Globalization;

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
options.SignIn.RequireConfirmedAccount = true)
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
    options.User.RequireUniqueEmail = false;
});

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.ConsentCookie.Name = "Blog_Consent";
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.ConsentCookie.Expiration = TimeSpan.FromMinutes(7);
});

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("bg")
    };

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.SetDefaultCulture("en");
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddControllersWithViews()
    .AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddCookieTempDataProvider();

builder.Services.AddAuthentication()
                .AddFacebook(options =>
{
    options.AppId = configuration["Authentication:Facebook:AppId"];
    options.AppSecret = configuration["Authentication:Facebook:AppSecret"];
});

//builder.Services.AddSendGrid(options =>
//    options.ApiKey = builder.Configuration.GetValue<string>("SendGridApiKey")
//                     ?? throw new Exception("The 'SendGridApiKey' is not configured")
//);

var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();

builder.Services.AddSingleton(emailConfig);

builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IEmailSender, SmtpEmailSender>();

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
   .UseRequestLocalization()
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
app.UseAuthentication();

app.Run();
