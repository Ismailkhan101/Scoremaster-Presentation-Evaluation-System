using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using scoremaster_Presentation.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ScoreMasterDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("myconnectionstring"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ScoreMasterDbContext>();
builder.Services.AddRazorPages();
//builder.Services.AddIdentity< IdentityUser, IdentityRole>().AddEntityFrameworkStores<ScoreMasterDbContext>().
/*builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});*/
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/Index";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.AccessDeniedPath = "/Login/LoginPage";
        //options.Cookie.Expiration = TimeSpan.FromMinutes(1);
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Department.List", policy => policy.RequireClaim("Permission", "Department.List"));
    options.AddPolicy("Department.Create", policy => policy.RequireClaim("Permission", "Department.Create"));
    options.AddPolicy("Event.List", policy => policy.RequireClaim("Permission", "Event.List"));
    options.AddPolicy("Event.Create", policy => policy.RequireClaim("Permission", "Event.Create"));
    options.AddPolicy("Event.Eventactive", policy => policy.RequireClaim("Permission", "Event.Eventactive"));
    options.AddPolicy("Event.EventInactive", policy => policy.RequireClaim("Permission", "Event.EventInactive"));
    options.AddPolicy("Event.Join", policy => policy.RequireClaim("Permission", "Event.Join"));
    options.AddPolicy("ExamianerJoinEvent", policy => policy.RequireClaim("Permission", "ExamianerJoinEvent"));
    options.AddPolicy("ExamianerMembermarking", policy => policy.RequireClaim("Permission", "ExamianerMembermarking"));
    options.AddPolicy("EventResult", policy => policy.RequireClaim("Permission", "EventResult"));
    options.AddPolicy("ExternalUser", policy => policy.RequireClaim("Permission", "ExternalUser"));
    options.AddPolicy("ExternalUserCreate", policy => policy.RequireClaim("Permission", "ExternalUserCreate"));




    //options.AddPolicy("Department.List", policy => policy.RequireClaim("Permission", "Department.List"));

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
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); // Move UseAuthentication before UseAuthorization

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=LoginPage}/{id?}");
});

app.Run();