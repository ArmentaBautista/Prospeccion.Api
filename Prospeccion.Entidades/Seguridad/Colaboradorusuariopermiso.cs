namespace Prospeccion.Entidades.Seguridad;

public partial class Colaboradorusuariopermiso
{
    public int Id { get; set; }

    public int Idcolaboradorusuario { get; set; }

    public int Idpermiso { get; set; }

    public bool Estado { get; set; }

    public DateTime Fechacreacion { get; set; }

    public string Usuariocreacion { get; set; } = null!;

    public DateTime? Fechamodificacion { get; set; }

    public string? Usuariomodificacion { get; set; }

    public virtual Colaboradorusuario IdcolaboradorusuarioNavigation { get; set; } = null!;

    public virtual Permiso IdpermisoNavigation { get; set; } = null!;
}
