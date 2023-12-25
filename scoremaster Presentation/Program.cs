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

    options.AddPolicy("Department.Create", policy => policy.RequireClaim("Permission","Department.Create"));

    options.AddPolicy("Event.List", policy => policy.RequireClaim("Permission", "Event.List"));

    options.AddPolicy("Event.Create", policy => policy.RequireClaim("Permission", "Event.Create"));

    options.AddPolicy("Event.Join", policy => policy.RequireClaim("Permission", "Event.Join"));

    options.AddPolicy("ExternalUser.List", policy => policy.RequireClaim("Permission", "ExternalUser.List"));

    options.AddPolicy("ExternalUser.Create", policy => policy.RequireClaim("Permission", "ExternalUser.Create"));

    options.AddPolicy("Group.List", policy => policy.RequireClaim("Permission", "Group.List"));

    options.AddPolicy("Group.Create", policy => policy.RequireClaim("Permission", "Group.Create"));

    options.AddPolicy("IndividualMember.Create", policy => policy.RequireClaim("Permission", "IndividualMember.Create"));

    options.AddPolicy("Member.List", policy => policy.RequireClaim("Permission", "Member.List"));

    options.AddPolicy("Home.Index", policy => policy.RequireClaim("Permission", "Home.Index"));

    options.AddPolicy("Mark.List", policy => policy.RequireClaim("Permission", "Mark.List"));

    options.AddPolicy("Marks.Create", policy => policy.RequireClaim("Permission", "Marks.Create"));

    options.AddPolicy("Users.List", policy => policy.RequireClaim("Permission", "Users.List"));

    options.AddPolicy("Users.Create", policy => policy.RequireClaim("Permission", "Users.Create"));

    options.AddPolicy("Event.Update", policy => policy.RequireClaim("Permission", "Event.Update"));
    options.AddPolicy("Event.ExamianerJoinEvent", policy => policy.RequireClaim("Permission", "Event.ExamianerJoinEvent"));

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