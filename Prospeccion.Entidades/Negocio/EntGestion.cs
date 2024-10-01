namespace Prospeccion.Entidades.Negocio;

public partial class EntGestion : EntBase
{
    public int? IdGestor { get; set; }
    public int? IdPersona { get; set; }

    public int? IdActividad { get; set; }

    public int? IdResultado { get; set; }

   public virtual EntActividad? IdActividadNavigation { get; set; }

    public virtual EntGestor? IdGestorNavigation { get; set; }
    public virtual EntPersona? IdPersonaNavigation { get; set; }

    public virtual EntResultado? IdResultadoNavigation { get; set; }
}
