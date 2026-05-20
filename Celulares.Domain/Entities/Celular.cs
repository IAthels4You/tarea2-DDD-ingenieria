namespace Celulares.Domain.Entities
{
    public class Celular
    {
        // La clase Celular representa la entidad principal del dominio
        //se trabaja a nivel de DDD con entidades que representan los objetos del mundo real, en este caso un celular.
        //Se implementa aquí toda la lógica de negocio relacionada con el celular, como validaciones y reglas de negocio,
        //asegurando que la entidad siempre esté en un estado válido.
        //se puede observar que las propiedades tienen setters privados,
        //lo que significa que solo se pueden modificar a través de métodos específicos (como el constructor o el método Actualizar),
        public Guid Id { get; private set; }
        public string Marca { get; private set; } = string.Empty;
        public string Modelo { get; private set; } = string.Empty;
        public string IMEI { get; private set; } = string.Empty;
        public decimal Precio { get; private set; }
        public int Stock { get; private set; }
        public DateTime FechaCreacion { get; private set; }

        // Constructores para EF y creación
        protected Celular() { }

        //Aqui se implementa el constructor que se utiliza para crear un nuevo celular, y se realizan las validaciones necesarias para asegurar que los datos sean correctos.
        //básicamente el celular se valida a si mismo al momento de ser creado, asegurando que siempre esté en un estado válido desde el principio.
        public Celular(string marca, string modelo, string imei, decimal precio, int stock)
        {
            SetMarca(marca);
            SetModelo(modelo);
            SetIMEI(imei);
            SetPrecio(precio);
            SetStock(stock);
            Id = Guid.NewGuid();
            FechaCreacion = DateTime.UtcNow;
        }

        //este método es importante porque es el reflejo del uso de DDD
        //ya que en lugar de tener un método genérico para actualizar el celular, se implementa un método específico que recibe los datos necesarios para actualizar el celular,
        //y se realizan las validaciones necesarias para asegurar que se cumplan las reglas de negocio al actualizar el celular.
        public void Actualizar(string marca, string modelo, string imei, decimal precio, int stock)
        {
            SetMarca(marca);
            SetModelo(modelo);
            SetIMEI(imei);
            SetPrecio(precio);
            SetStock(stock);
        }

        //En otro ejemplo se podrían ver métodos específicos para cada operación relacionada con el celular,
        //como "Vender", "Reabastecer", etc., cada uno con su propia lógica de negocio.
        //En este caso la lógica de venta podría ser algo como: "Si el stock es mayor a cero, reducir el stock en uno y registrar la venta".
        //la cuestión es que la gestión y cambios en el estado del celular se maneja a través de métodos específicos que reflejan las operaciones del mundo real
        //las otras capas simplemente se encargan de la parte técnica de cómo se reciben los datos (DTOs) y cómo se almacenan (repositorios),
        //pero la lógica de negocio se mantiene dentro de la entidad.
        private void SetMarca(string marca)
        {
            if (string.IsNullOrWhiteSpace(marca)) throw new ArgumentException("La marca es requerida.", nameof(marca));
            Marca = marca;
        }

        private void SetModelo(string modelo)
        {
            if (string.IsNullOrWhiteSpace(modelo)) throw new ArgumentException("El modelo es requerido.", nameof(modelo));
            Modelo = modelo;
        }

        private void SetIMEI(string imei)
        {
            if (string.IsNullOrWhiteSpace(imei) || imei.Length != 15) throw new ArgumentException("El IMEI debe tener exactamente 15 caracteres.", nameof(imei));
            IMEI = imei;
        }

        private void SetPrecio(decimal precio)
        {
            if (precio <= 0) throw new ArgumentException("El precio debe ser mayor a cero.", nameof(precio));
            Precio = precio;
        }

        private void SetStock(int stock)
        {
            if (stock < 0) throw new ArgumentException("El stock no puede ser negativo.", nameof(stock));
            Stock = stock;
        }
    }
}
