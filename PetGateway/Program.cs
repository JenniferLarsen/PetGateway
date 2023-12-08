using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetGateway.Models;
using PetGateway.Repository;

var builder = WebApplication.CreateBuilder(args);


//Add DI
builder.Services.AddTransient<IPetGatewayRepository, PetGatewayRepository>();

// MUST BE CALLED before AddControllersWithViews
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add EF Core DI
builder.Services.AddDbContext<GatewayContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PetGateway_db")));


//Add Identity Middleware
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
})
    .AddEntityFrameworkStores<GatewayContext>()
    .AddDefaultTokenProviders();


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

app.UseAuthentication();
app.UseAuthorization();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    await ConfigureIdentity.CreateAdminUserAsync(scope.ServiceProvider);
}

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "pet",
    pattern: "{controller=Pet}/{action=Index}/{ownerId?}");




app.Run();
