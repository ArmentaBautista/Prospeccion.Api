namespace Prospeccion.Dto.Request;

public partial class EntPersonaDtoRequest
{

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string? Domicilio { get; set; }

    public string? Telefono { get; set; }

}
