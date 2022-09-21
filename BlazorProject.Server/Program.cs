using BlazorProject.Server.Data;
using BlazorProject.Shared;
using BlazorProject.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//var sharedContext = new SharedContext();
//builder.Services.AddSingleton(_ => sharedContext);
//builder.Services.AddSingleton<IContactService, ContactService>();
//builder.Services.AddSingleton<INoteService, NoteService>();

builder.Services.AddDbContext<SharedContext>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<INoteService, NoteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
