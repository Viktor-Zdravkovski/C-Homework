using BurgerShop.DataAccess;
using BurgerShop.DataAccess.Implementations;
using BurgerShop.DataAccess.Interfaces;
using BurgerShop.Domain;
using BurgerShop.Services;
using BurgerShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();


string connectionString = builder.Configuration.GetConnectionString("BurgerAppConnectionString");

builder.Services.AddDbContext<BurgerShopDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IBurgerService, BurgerService>(); // neam veze shto e ova / barav na net i so chatGpt se machev
builder.Services.AddScoped<IRepository<Burger>, BurgerRepository>(); // isto

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
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

//app.MapRazorPages();

app.Run();
