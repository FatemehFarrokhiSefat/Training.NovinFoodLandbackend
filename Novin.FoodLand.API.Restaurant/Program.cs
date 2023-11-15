using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Novin.Foodland.Core.Entities;
using Novin.Foodland.Infrastructure.Data;
using Novin.Foodland.Infrastructure.Security;
using Novin.FoodLand.API.Restaurant.DTOs;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);

var app = builder.Build();

SecurityServices.UseServices(app);

app.MapPost("/createrequest",async (NovinFoodlandDB db,ClaimsPrincipal user, RestaurantRequestDto restaurantRequest) =>
{
    var restaurant = new Restaurant
    {
        Title = restaurantRequest.Title ?? "",
        Address = restaurantRequest.Address ?? "",
        ApprovedTime=null,
        ApprovedUsername=null,
        CreationTime=DateTime.Now,
        IsActive=false,
        IsApproved=false,
        OwnerUsername=user.Claims.FirstOrDefault(m=> m.Type=="Username")?.Value??""
    };
    await db.Restaurants.AddAsync(restaurant);
    await db.SaveChangesAsync();

}).RequireAuthorization();

app.MapPost("/myrequestlist", async (NovinFoodlandDB db , ClaimsPrincipal user) =>
{
    var username= user.Claims.FirstOrDefault(m=>m.Type =="Username")?.Value; 
    return Results.Ok(db
        .Restaurants
        .Where(m=>m.IsApproved==false && m.OwnerUsername==username)
        .ToList());
}).RequireAuthorization();

app.MapPost("/requestlist", async (NovinFoodlandDB db , ClaimsPrincipal user) =>
{
    if(user.Claims.FirstOrDefault(m=>m.Type=="Type")?.Value!= "AdminSystem")
    {
        return Results.Unauthorized();
    }
    return Results.Ok(db.Restaurants
        .Where(r=>r.IsApproved==false)
        .ToList());  
}).RequireAuthorization();

app.MapGet("/requestcount", async (NovinFoodlandDB db) =>
{
    return Results.Ok(new
    { 
        Count =await db.Restaurants.CountAsync(r=>r.IsApproved==false)
    });
});
app.Run();
