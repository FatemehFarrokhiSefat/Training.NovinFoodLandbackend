using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Novin.Foodland.Core.Entities;
using Novin.Foodland.Core.Enums;
using Novin.Foodland.Infrastructure.Data;
using Novin.Foodland.Infrastructure.Security;
using Novin.FoodLand.API.Security.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);

var app = builder.Build();

SecurityServices.UseServices(app);



app.MapPost("/signup", async (NovinFoodlandDB db, ApplicationUser user) =>
{
    var rg = new Random();
    user.VerificationCode = rg .Next(100000,999999).ToString();
    //send sms
    await db.ApplicationUsers.AddAsync(user);
    await db.SaveChangesAsync();
    return Results.Ok();
});


app.MapPost("/signin", async (NovinFoodlandDB db, LoginDTo login) =>
{
    Thread.Sleep(3000);
    var result = await db.ApplicationUsers.FirstOrDefaultAsync(a => a.Type != ApplicationUserType.AdminSystem && a.Verified==true && a.Username == login.Username && a.Password == login.Password);
    if (result == null)
    {
        return Results.Ok(new LoginResultsDTo
        {
            Message = "نام کاربری یا کلمه عبور صحیح نیست",
            IsOk = false
        });
    }
    var claims = new[]
{
        new Claim("Type",result.Type.ToString()),
        new Claim("Username",result.Username.ToString()),
    };
       var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""));
       var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
       var token = new JwtSecurityToken(
           builder.Configuration["Jwt:Issuer"],
           builder.Configuration["Jwt:Audience"],
           claims,
           expires: DateTime.UtcNow.AddDays(1),
           signingCredentials: signIn);
    return Results.Ok(new LoginResultsDTo
    {
        Type= result.Type.ToString(),
        Message = "خوش امدید",
        IsOk = true,
        Token = new JwtSecurityTokenHandler().WriteToken(token),
    });
});

app.MapPost("/adminsignin", async (NovinFoodlandDB db, LoginDTo login) =>
{
    if (!db.ApplicationUsers.Any())
    {
        await db.ApplicationUsers.AddAsync(new ApplicationUser
        {
            Email = "fatemeh@gmail.com",
            Fullname = "مدیریت سامانه",
            Password = "admin",
            Username = "admin",
            Type = ApplicationUserType.AdminSystem,
            Verified = true
        });
        await db.SaveChangesAsync();
    }
    var result = await db.ApplicationUsers.FirstOrDefaultAsync(a => a.Type==ApplicationUserType.AdminSystem && a.Verified == true && a.Username == login.Username && a.Password == login.Password);
    if (result == null)
    {
        return Results.Ok(new LoginResultsDTo
        {
            Message = "نام کاربری یا کلمه عبور صحیح نیست",
            IsOk = false
        });
    }
    var claims = new[]
{
        new Claim("Type",result.Type.ToString()),
        new Claim("Username",result.Username.ToString()),
    };
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""));
    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        builder.Configuration["Jwt:Issuer"],
        builder.Configuration["Jwt:Audience"],
        claims,
        expires: DateTime.UtcNow.AddDays(1),
        signingCredentials: signIn);
    return Results.Ok(new LoginResultsDTo
    {
        Type = result.Type.ToString(),
        Message = "خوش امدید",
        IsOk = true,
        Token = new JwtSecurityTokenHandler().WriteToken(token),
    });
});
app.Run();
