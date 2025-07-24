using AutoMapper;
using Eag.Jwt.Core.Application.Interfaces;
using Eag.Jwt.Core.Application.Mappings;
using Eag.Jwt.Infrastructure.Tools;
using Eag.Jwt.Persistance.Context;
using Eag.Jwt.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<JwtContext>(opt =>
{
    opt.UseSqlServer("server=MSI; database=EagJwt_Vt; Integrated Security=True;");
});

builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>
    {
        new CategoryProfile(),
        new ProductProfile(),
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
