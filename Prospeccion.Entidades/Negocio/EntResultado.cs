namespace Prospeccion.Entidades.Negocio;

public partial class EntResultado : EntBase
{
    public string Resultado { get; set; } = null!;

    public virtual ICollection<EntGestion> TGestiones { get; set; } = new List<EntGestion>();
}
