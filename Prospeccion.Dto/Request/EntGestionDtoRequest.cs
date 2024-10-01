using System.ComponentModel.DataAnnotations;
using Prospeccion.Trasversal;

namespace Prospeccion.Dto.Request;

public partial class EntGestionDtoRequest
{
    [Required(ErrorMessage = Constantes.MensajeRequerido)]
    public short? IdGestor { get; set; }
    [Required(ErrorMessage = Constantes.MensajeRequerido)]
    public int? IdPersona { get; set; }
    [Required(ErrorMessage = Constantes.MensajeRequerido)]
    public byte? IdActividad { get; set; }
    [Required(ErrorMessage = Constantes.MensajeRequerido)]
    public byte? IdResultado { get; set; }

}
