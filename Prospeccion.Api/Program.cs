using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Prospeccion.AccesoDatos;
using Prospeccion.Repositorios;
using Prospeccion.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string corsConfiguracion = "JCA";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProspeccionContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BdProspectacion"));
});
// context pg
builder.Services.AddDbContext<SeguridadDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("BdSeguridad"));
});

// conf JWT appsettings
var jwtSetting = builder.Configuration.GetSection("JwtSettings");


// CORS
builder.Services.AddCors(politicas =>
{
    politicas.AddPolicy(corsConfiguracion, config =>
    {
        config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// JWT
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSetting["Issuer"],
            ValidAudience = jwtSetting["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting["SecretKey"]!))
        };
    });

// Mid, Serv, Rep
builder.Services.AddAutoMapper(config => PerfilesMapperExtension.AddPerfilesMapper(config));
builder.Services.AddServicios();
builder.Services.AddRepositorios();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors(corsConfiguracion);

app.Run();
