using AddressBookMVC.Data;
using AddressBookMVC.Services;
using AddressBookMVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
    options.UseNpgsql(DataUtility.GetConnectionString(builder.Configuration));
    });
builder.Services.AddScoped<IImageService, BasicImageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//unable to post to Horoku
// below code is from startup in .Net5 but have to convert to .Net6 minimal API
public static async Task Main(string[] args)
{
    var host = CreateHostBuilder(args).Build();

    var dbContext = host.Services
                        .CreateScope().ServiceProvider
                        .GetRequiredService<ApplicationDbContext>();

    await dbContext.Database.MigrateAsync();

    host.Run();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
