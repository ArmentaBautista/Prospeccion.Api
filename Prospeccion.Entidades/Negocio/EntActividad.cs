namespace Prospeccion.Entidades.Negocio;

public class EntActividad:EntBase
{
    public string Actividad { get; set; } = null!;

    
    public virtual ICollection<EntGestion> TGestiones { get; set; } = new List<EntGestion>();
}
