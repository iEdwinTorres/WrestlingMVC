using Microsoft.EntityFrameworkCore;
using WrestlingMVC.Data;
using WrestlingMVC.Services.Championships;
using WrestlingMVC.Services.Promotions;
using WrestlingMVC.Services.Wrestlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WrestlingDbContext>(options => options.UseSqlServer(
	 builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddScoped<IChampionshipService, ChampionshipService>();
builder.Services.AddScoped<IPromotionService, PromotionService>();
builder.Services.AddScoped<IWrestlerService, WrestlerService>();

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
