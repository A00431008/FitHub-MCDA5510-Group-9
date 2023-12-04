using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FitHub.Data;
using FitHub.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookingContext") ?? throw new InvalidOperationException("Connection string 'BookingContext' not found.")));
builder.Services.AddDbContext<AmenityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AmenityContext") ?? throw new InvalidOperationException("Connection string 'AmenityContext' not found.")));
builder.Services.AddDbContext<SwimmingPoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SwimmingPoolContext") ?? throw new InvalidOperationException("Connection string 'SwimmingPoolContext' not found.")));
builder.Services.AddDbContext<SpaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpaContext") ?? throw new InvalidOperationException("Connection string 'SpaContext' not found.")));
builder.Services.AddDbContext<SaunaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SaunaContext") ?? throw new InvalidOperationException("Connection string 'SaunaContext' not found.")));

// Register the SwimmingPool service
builder.Services.AddScoped<SwimmingPool>();

// Register the Spa service
builder.Services.AddScoped<Spa>();

// Register the Sauna service
builder.Services.AddScoped<Sauna>();

// Register the Booking service
builder.Services.AddScoped<Booking>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.Run();
