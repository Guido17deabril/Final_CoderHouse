using System.Security.Cryptography;

namespace Final_CoderHouse.Models
{
    public class Producto
    {
        public Producto() 
        {
            this.Id = 0;
            this.Descripciones = String.Empty;
            this.Costo = 0.0;
            this.PrecioVenta = 0.0;
            this.Stock = 0;
            this.IdUsuario = 0;
        }

        public Producto(long id, string descripciones, double costo, double precioVenta, int stock, long idUsuario)
        {
            this.Id = id;
            this.Descripciones = descripciones;
            this.Costo = costo;
            this.PrecioVenta = precioVenta;
            this.Stock = stock;
            this.IdUsuario = idUsuario;
        }

        public long Id { get; set; }
        public string Descripciones { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public long IdUsuario { get; set; }


        // Método para visualizar el valor de los atributos 
        public void verAtributos()
        {
            Console.WriteLine("\nProducto:" +
                                "\n   id = " + Id.ToString() +
                                "\n   descripcion = " + Descripciones +
                                "\n   costo = " + Costo.ToString() +
                                "\n   precioVenta = " + PrecioVenta.ToString() +
                                "\n   stock = " + Stock.ToString() +
                                "\n   idUsuario = " + IdUsuario.ToString() +
                                "\n");
        }
    }
}
