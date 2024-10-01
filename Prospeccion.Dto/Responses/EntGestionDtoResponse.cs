namespace Prospeccion.Dto.Responses;

public class EntGestionDtoResponse
{
    public short? IdGestor { get; set; }
    public string? Gestor { get; set; }
    public int? IdPersona { get; set; }
    public string? Persona { get; set; }
    public byte? IdActividad { get; set; }
    public string? Actividad { get; set; }
    public byte? IdResultado { get; set; }
    public string? Resultado { get; set; }
    public DateOnly? Fecha { get; set; }
    public TimeOnly? Hora { get; set; }

}
