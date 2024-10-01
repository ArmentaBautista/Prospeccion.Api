namespace Prospeccion.Entidades.Negocio;

public partial class EntPersona:EntBase
{
    
    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public DateTime FechaNacimiento { get; set; } = new DateTime(2000, 1, 1);

    public string NombreCompleto { get; set; } = null!;

    public string? Domicilio { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<EntGestor> TGestores { get; set; } = new List<EntGestor>();
    public virtual ICollection<EntGestion> TGestiones { get; set; } = new List<EntGestion>();
}
