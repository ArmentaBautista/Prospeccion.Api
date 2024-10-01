using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Prospeccion.Dto.Responses;
using Prospeccion.Repositorios.Interfaces;
using Prospeccion.Servicios.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Galaxy.GestionPedidos.Dto.Request.Usuario;
using Galaxy.GestionPedidos.Dto.Response.Usuario;

namespace Prospeccion.Servicios.Implementaciones;

public class UsuarioServicio : IUsuarioServicio
{
    private IUsuarioRepositorio _repositorio;
    private IMapper _mapper;
    private IConfiguration _configuracion;
    public UsuarioServicio(IUsuarioRepositorio repositorio, IMapper mapper, IConfiguration configuracion)
    {
        _repositorio = repositorio;
        _mapper = mapper;
        _configuracion = configuracion;
    }

    public async Task<RespuestaBaseDto<UsuarioColaboradorDtoResponse>> ObtenerColaboradorPorUsuario(string usuario)
    {
        RespuestaBaseDto<UsuarioColaboradorDtoResponse> respuesta = new();
        try
        {
            var resultado = await _repositorio.ObtenerColaboradorPorUsuario(usuario);
            respuesta.Data = _mapper.Map<UsuarioColaboradorDtoResponse>(resultado);
            respuesta.success = true;
        }
        catch (Exception ex)
        {
            respuesta.success = false;
            respuesta.message = ex.Message;
        }
        return respuesta;
    }


    public async Task<RespuestaBaseDto<UsuarioPermisoDtoReponse>> ListarPermisosPorUsuario(string usuario)
    {
        RespuestaBaseDto<UsuarioPermisoDtoReponse> respuesta = new();
        try
        {
            var resultado = await _repositorio.ListarPermisosPorUsuario(usuario);
            respuesta.Data = _mapper.Map<UsuarioPermisoDtoReponse>(resultado);
            respuesta.success = true;
        }
        catch (Exception ex)
        {
            respuesta.success = false;
            respuesta.message = ex.Message;
        }
        return respuesta;
    }

    public async Task<RespuestaBaseDto<LoginDtoResponse>> AutenticarUsuario(LoginDtoRequest request)
    {
        RespuestaBaseDto<LoginDtoResponse> respuesta = new();
        try
        {
            var jwtSetting = _configuracion.GetSection("JwtSettings");

            var resultado = await _repositorio.AutenticarUsuario(request.Usuario, request.Clave);

            if (resultado is null)
            {
                respuesta.success = false;
                respuesta.message = "Usuario o clave incorrecta";
                return respuesta;
            }

            var fechaExpiracion = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSetting["ExpirationInMinutes"]));

            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, resultado.Colaborador),
                    new Claim(ClaimTypes.Email, resultado.CorreoElectronico),
                    new Claim(ClaimTypes.Expiration, new DateTimeOffset(fechaExpiracion).ToUnixTimeSeconds().ToString())
                };

            var llaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting["SecretKey"]!));
            var credenciales = new SigningCredentials(llaveSimetrica, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credenciales);

            var payload = new JwtPayload(
                jwtSetting["Issuer"],
                jwtSetting["Audience"],
                claims,
                DateTime.Now,
                fechaExpiracion
              );

            var jwtToken = new JwtSecurityToken(header, payload);

            respuesta.Data = new()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                FechaExpiracionToken = fechaExpiracion,
                Colaborador = resultado.Colaborador,
                Rol = resultado.Puesto,
                Usuario = request.Usuario
            };
            respuesta.success = true;
            respuesta.message = "Autenticación exitosa - Token generado correctamente";

        }
        catch (Exception ex)
        {
            respuesta.success = false;
            respuesta.message = ex.Message;
        }
        return respuesta;
    }
}