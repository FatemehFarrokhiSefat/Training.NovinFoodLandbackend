using Novin.Foodland.Infrastructure.Data;
using Novin.Foodland.Infrastructure.Security;
using Novin.Foodland.Infrastructure.UI;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);

var app = builder.Build();

SecurityServices.UseServices(app);

app.MapPost("/list", async (NovinFoodlandDB db) =>
{
    return Results.Ok(db.ApplicationUsers
        .ToList());
});

app.MapPost("/alist", async (NovinFoodlandDB db,ListRequestDTO listRequest) =>
{
    return Results.Ok(db.ApplicationUsers
        .ToList());
});

app.Run();
