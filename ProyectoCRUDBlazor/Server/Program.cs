using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using ProyectoCRUDBlazor.Server.Data;
using ProyectoCRUDBlazor.Server.Core.Service;
using ProyectoCRUDBlazor.Server.Core.Service.Interface;
using ProyectoCRUDBlazor.Server.Core.Repository.Interface;
using ProyectoCRUDBlazor.Server.Core.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var devConnection = builder.Configuration.GetConnectionString("DevConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(devConnection)
);

//agrego el servicio de club
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
