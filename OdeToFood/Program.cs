using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;


var builder = WebApplication.CreateBuilder(args);

//Add DbContext
builder.Services.AddDbContext<OdeToFoodDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();
//solo per development e tests
//builder.Services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();

builder.Services.AddScoped<IRestaurantData, SqlRestaurantData>();

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

app.MapRazorPages();

app.Run();
