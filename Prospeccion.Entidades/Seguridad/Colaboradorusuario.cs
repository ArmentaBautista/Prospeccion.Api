namespace Prospeccion.Entidades.Seguridad;

public partial class Colaboradorusuario
{
    public int Id { get; set; }

    public int Idcolaborador { get; set; }

    public string? Usuario { get; set; }

    public string? Clave { get; set; }

    public DateTime? Bloqueadohasta { get; set; }

    public DateTime? Ultimobloqueo { get; set; }

    public int? Intentosfallidos { get; set; }

    public bool Estado { get; set; }

    public DateTime Fechacreacion { get; set; }

    public string Usuariocreacion { get; set; } = null!;

    public DateTime? Fechamodificacion { get; set; }

    public string? Usuariomodificacion { get; set; }

    public virtual ICollection<Colaboradorusuariopermiso> Colaboradorusuariopermisos { get; set; } = new List<Colaboradorusuariopermiso>();

    public virtual Colaborador IdcolaboradorNavigation { get; set; } = null!;
}
