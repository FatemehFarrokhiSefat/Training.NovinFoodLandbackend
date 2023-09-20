using Microsoft.EntityFrameworkCore;
using Novin.Foodland.Core.Entities;
using Novin.Foodland.Infrastructure.Data;
using Novin.Foodland.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);

var app = builder.Build();

SecurityServices.UseServices(app);

app.MapPost("/requestlist", async (NovinFoodlandDB db) =>
{
    return Results.Ok(db.Restaurants
        .Where(r=>r.IsApproved==false)
        .ToList());  
});

app.MapGet("/requestcount", async (NovinFoodlandDB db) =>
{
    return Results.Ok(new
    { 
        Count =await db.Restaurants.CountAsync(r=>r.IsApproved==false)
    });
});
app.Run();
