using Microsoft.EntityFrameworkCore;
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
//TODO

// conf JWT appsettings
//TODO

// CORS
builder.Services.AddCors(politicas =>
{
    politicas.AddPolicy(corsConfiguracion, config =>
    {
        config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// JWT
//TODO

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

app.UseAuthorization();

app.MapControllers();

app.UseCors(corsConfiguracion);

app.Run();
