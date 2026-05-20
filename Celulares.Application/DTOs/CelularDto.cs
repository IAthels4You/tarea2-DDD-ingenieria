namespace Celulares.Application.DTOs
{
    public class CelularDto
    {
        //Este DTO representa la información que se devuelve al cliente cuando se solicita información de un celular (GET).
        //Contiene todas las propiedades del celular que son útiles para identificar y mostrar detalles del celular.
        //Es utilizado por la capa de presentación para enviar datos al cliente en las respuestas de los endpoints.
        //Buena práctica para no exponer directamente las entidades del dominio que pueden contener información sensible o innecesaria para el cliente.
        public Guid Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string IMEI { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
