namespace Prospeccion.Dto.Request;

public partial class EntPersonaDtoRequest
{

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public DateTime FechaNacimiento { get; set; } = new DateTime(2000, 1, 1);

    public string? NombreCompleto { get; set; } = string.Empty;

    public string? Domicilio { get; set; }

    public string? Telefono { get; set; }

}
