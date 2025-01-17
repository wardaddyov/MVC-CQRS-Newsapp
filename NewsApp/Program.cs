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

// Apply database migrations automatically
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DataContext>();
        context.Database.Migrate(); // Apply all pending migrations
    }
    catch (Exception ex)
    {
        // Log the exception (use a proper logging library for production)
        Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
        throw; // Optionally re-throw the exception if necessary
    }
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=News}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();