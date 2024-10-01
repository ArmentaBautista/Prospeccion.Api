namespace Prospeccion.Entidades.Seguridad;

public partial class Permiso
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public DateTime Fechacreacion { get; set; }

    public string Usuariocreacion { get; set; } = null!;

    public DateTime? Fechamodificacion { get; set; }

    public string? Usuariomodificacion { get; set; }

    public virtual ICollection<Colaboradorusuariopermiso> Colaboradorusuariopermisos { get; set; } = new List<Colaboradorusuariopermiso>();
}
