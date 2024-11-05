using BattleShips.Models;
using BattleShips.Services;
using Blazored.Toast;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Register the Field service
builder.Services.AddScoped<Field>(sp => new Field("GameField", 10, 10));

// Register IShipFactory implementations
builder.Services.AddScoped<IShipFactory, GermanShipFactory>(); // Or SovietShipFactory based on your requirements

// Register FacadeGameService after all dependencies have been registered
builder.Services.AddScoped<FacadeGameService>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast();
builder.Services.AddSingleton<RoomService>();
builder.Services.AddScoped<UserState>();
builder.Services.AddSignalR();

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

try
{
    var testResultsPath = Path.Combine(app.Environment.ContentRootPath + "..\\", "BattleShipsTestingProject", "TestResults");
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(testResultsPath),
        RequestPath = "/BattleShipsTestingProject/TestResults"
    });
}
catch{ }

app.UseRouting();

app.MapBlazorHub();

app.MapHub<RoomHub>("/roomHub");
app.MapFallbackToPage("/_Host");


app.Run();
