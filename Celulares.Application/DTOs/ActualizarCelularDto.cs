using System.ComponentModel.DataAnnotations;

namespace Celulares.Application.DTOs
{
    //Este DTO define los datos que ingresa el usuario y son utilizados para actualizar un celular existente.
    //solamente contiene las propiedades que se pueden actualizar, y se utilizan atributos de validación
    //para asegurar que los datos sean correctos antes de ser procesados por el servicio.
    //Es utilizado por la capa de presentación al recibir datos en el endpoint de actualización (UPDATE)
    public class ActualizarCelularDto
    {
        [Required(ErrorMessage = "La marca es requerida.")]
        public string Marca { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El modelo es requerido.")]
        public string Modelo { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El IMEI es requerido.")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "El IMEI debe tener exactamente 15 caracteres.")]
        public string IMEI { get; set; } = string.Empty;
        
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a cero.")]
        public decimal Precio { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock { get; set; }
    }
}
