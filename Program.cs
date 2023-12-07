using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FitHub.Data;
using FitHub.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GymDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GymDbContext") ?? throw new InvalidOperationException("Connection string 'GymDbContext' not found.")));

// Register the capacity validation service
builder.Services.AddScoped<AmenityManagementService>();

// Register the gym service
builder.Services.AddScoped<GymDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    AmenitySeedData.Initialize(services);
    MembershipDetailSeedData.Initialize(services);
}

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