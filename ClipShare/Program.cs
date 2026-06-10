using ClipShare.Core.Entities;
using ClipShare.DataAccess.Data;
using ClipShare.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.AddApplicationServices();               // Add application services to the container.
builder.AddAuthenticationServices();            // Add authentication services to the container.

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

app.UseAuthentication();            // Enable authentication middleware to process authentication for incoming requests.
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

await InitializeContextAsync();
app.Run();

async Task InitializeContextAsync()
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    try 
    {
        var context = scope.ServiceProvider.GetService<Context>();
        var userManager = scope.ServiceProvider.GetService<UserManager<AppUser>>();
        var roleManager = scope.ServiceProvider.GetService<RoleManager<AppRole>>();
        // var photoService = scope.ServiceProvider.GetService<IPhotoService>();
        // var webHostEnvironemt = scope.ServiceProvider.GetService<IWebHostEnvironment>();
        await ContextInitializer.InitializeAsync(context, userManager, roleManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetService<ILogger<Program>>();
        logger.LogError(ex, "An error occured while migrating the databse");
    }
}
