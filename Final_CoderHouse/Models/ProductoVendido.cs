using System.Security.Cryptography;

namespace Final_CoderHouse.Models
{
    public class ProductoVendido
    {
        public ProductoVendido() 
        {
            this.Id = 0;
            this.IdProducto = 0;
            this.Stock = 0;
            this.IdVenta = 0;
        }

        public ProductoVendido(long id, long idProducto, int stock, long idVenta)
        {
            this.Id = id;
            this.IdProducto = idProducto;
            this.Stock = stock;
            this.IdVenta = idVenta;
        }

        public long Id { get; set; }
        public long IdProducto { get; set; }
        public int Stock { get; set; }
        public long IdVenta { get; set; }

        // Método para visualizar el valor de los atributos
        public void verAtributos()
        {
            Console.WriteLine("\nProductoVendido:" +
                                "\n   id = " + Id.ToString() +
                                "\n   idProducto = " + IdProducto.ToString() +
                                "\n   stock = " + Stock.ToString() +
                                "\n   idVenta = " + IdVenta.ToString() +
                                "\n");
        }


    }
}
