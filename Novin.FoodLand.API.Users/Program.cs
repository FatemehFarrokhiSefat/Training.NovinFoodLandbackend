using Novin.Foodland.Infrastructure.Data;
using Novin.Foodland.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);

var app = builder.Build();

SecurityServices.UseServices(app);

app.MapPost("/list", async (NovinFoodlandDB db) =>
{
    return Results.Ok(db.ApplicationUsers
        .ToList());
});

app.Run();
