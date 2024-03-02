using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Models;
using Serilog;
using Serilog.Events;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(
    options=>options.UseSqlServer(connectionString));
builder.Services.AddIdentity<AppUser,IdentityRole>(
    options =>
    {
        options.Password.RequiredUniqueChars = 1;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireDigit=true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;

    }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

var log = new LoggerConfiguration()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
      .Filter.ByExcluding(logEvent =>
                logEvent.MessageTemplate.Text.Contains("Application started") ||
                logEvent.MessageTemplate.Text.Contains("Hosting environment") ||
                logEvent.MessageTemplate.Text.Contains("Content root path"))
    .CreateLogger();


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
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
