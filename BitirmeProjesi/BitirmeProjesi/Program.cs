using BitirmeProjesi.DataContext;
using BitirmeProjesi.Models;
using BitirmeProjesi.TcpServer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<BitirmeProjesiDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BitirmeProjesiConnectionString")));

builder.Services.AddTransient<BitirmeProjesi.TcpServer.TcpServer>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

builder.Services.AddControllersWithViews();

//yetki ayarlama
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy =>
    {
        policy.RequireRole("Admin");
    });
    options.AddPolicy("RequireAdminAssistantRole", policy =>
    {
        policy.RequireRole("AdminAssistant");
    });
    options.AddPolicy("RequirePermission1", policy =>
    {
        policy.RequireRole("Permission1");
    });
    options.AddPolicy("RequirePermission2", policy =>
    {
        policy.RequireRole("Permission2");
    });
    //hem admin veya admin asistaný eriþebileceði yerler
    options.AddPolicy("RequireAdminOrAdminAssistant", policy =>
    {
        policy.RequireRole("Admin", "AdminAssistant");
    });
    //permission1 ve permission2 eriþebiliyor
    options.AddPolicy("RequirePermission1AndPermission2", policy =>
    {
        policy.RequireRole("Permission1", "Permission2");
    });
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<BitirmeProjesiDbContext>();
    SeedAdminUser(dbContext);
}
static void SeedAdminUser(BitirmeProjesiDbContext context)
{
    if (!context.Users.Any(u => u.Role == "Admin"))
    {
        var adminUser = new User
        {
            Username = "admin",
            Password = "admin123", // You should hash passwords in a real scenario
            Role = "Admin",
            IsLoggedIn = false
        };

        context.Users.Add(adminUser);
        context.SaveChanges();
    }
}

app.Run();
