namespace Celulares.Domain.Entities
{
    public class Celular
    {
        public Guid Id { get; private set; }
        public string Marca { get; private set; } = string.Empty;
        public string Modelo { get; private set; } = string.Empty;
        public string IMEI { get; private set; } = string.Empty;
        public decimal Precio { get; private set; }
        public int Stock { get; private set; }
        public DateTime FechaCreacion { get; private set; }

        // Constructores para EF y creación
        protected Celular() { }

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

        public void Actualizar(string marca, string modelo, string imei, decimal precio, int stock)
        {
            SetMarca(marca);
            SetModelo(modelo);
            SetIMEI(imei);
            SetPrecio(precio);
            SetStock(stock);
        }

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
