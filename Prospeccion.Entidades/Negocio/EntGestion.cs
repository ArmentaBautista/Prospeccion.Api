namespace Prospeccion.Entidades.Negocio;

public partial class EntGestion : EntBase
{
    public short? IdGestor { get; set; }
    public int? IdPersona { get; set; }

    public byte? IdActividad { get; set; }

    public byte? IdResultado { get; set; }

   public virtual EntActividad? IdActividadNavigation { get; set; }

    public virtual EntGestor? IdGestorNavigation { get; set; }
    public virtual EntPersona? IdPersonaNavigation { get; set; }

    public virtual EntResultado? IdResultadoNavigation { get; set; }
}
