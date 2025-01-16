using Microsoft.EntityFrameworkCore;
using NewsApp.Application.Interfaces;
using NewsApp.Infrastructure.Data;
using NewsApp.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<INewsRepository, NewsRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly)); ;


// SQLite for projection
var sqlConnectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING") ??
                          "Data Source=app.db";
                          
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(sqlConnectionString);
    
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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();