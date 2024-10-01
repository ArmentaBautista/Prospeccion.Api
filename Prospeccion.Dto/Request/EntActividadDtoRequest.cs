using Prospeccion.Trasversal;
using System.ComponentModel.DataAnnotations;

namespace Prospeccion.Dto.Request;

public class EntActividadDtoRequest
{
    

    [Required(ErrorMessage = Constantes.MensajeRequerido)]
    public string Actividad { get; set; } = string.Empty;

}
