using BitirmeProjesi.DataContext;
using BitirmeProjesi.Models;
using BitirmeProjesi.TcpServer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        policy.RequireRole("Muhendis");
    });
    options.AddPolicy("RequireDepocu", policy =>
    {
        policy.RequireRole("Depocu");
    });
    options.AddPolicy("RequireMuhasebeci", policy =>
    {
        policy.RequireRole("Muhasebeci");
    });
    options.AddPolicy("RequirePuantor", policy =>
    {
        policy.RequireRole("Puantor");
    });
    //hem admin veya admin asistaný eriþebileceði yerler
    options.AddPolicy("RequireAdminOrMuhasebeci", policy =>
    {
        policy.RequireRole("Admin", "Muhasebeci");
    });
    //permission1 ve permission2 eriþebiliyor
    options.AddPolicy("RequireAdminOrMuhendis", policy =>
    {
        policy.RequireRole("Admin", "Muhendis");
    });
    options.AddPolicy("RequireAdminOrDepocuOrMuhendis", policy =>
    {
        policy.RequireRole("Admin", "Depocu","Muhendis");
    });
    options.AddPolicy("RequireAdminOrMuhasebeciOrPuantör", policy =>
    {
        policy.RequireRole("Admin", "Puantor","Muhasebeci");
    });
    options.AddPolicy("RequireAdminOrMuhasebeciOrPuantörOrMuhendis", policy =>
    {
        policy.RequireRole("Admin", "Puantor", "Muhasebeci","Muhendis");
    });
});

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddMvcOptions(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
}).AddDataAnnotationsLocalization();
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
