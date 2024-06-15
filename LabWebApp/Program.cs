using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;
using LabWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Retrieve the connection string from user secrets
var connectionString = app.Configuration["ConnectionStrings:DefaultConnection"];

// Check if the connection string is null or empty
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Missing connection string. Check your user secrets configuration.");
}

// Register the ApplicationDbContext with MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

app.Run();
