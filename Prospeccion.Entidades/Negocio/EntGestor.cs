namespace Prospeccion.Entidades.Negocio;

public partial class EntGestor:EntBase
{
    public int? IdPersona { get; set; }

    public string Usuario { get; set; } = null!;

    public virtual EntPersona? IdPersonaNavigation { get; set; }

    public virtual ICollection<EntGestion> TGestiones { get; set; } = new List<EntGestion>();
}
