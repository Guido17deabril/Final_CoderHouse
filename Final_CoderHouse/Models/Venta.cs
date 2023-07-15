using System.Security.Cryptography;

namespace Final_CoderHouse.Models
{
    public class Venta
    {
        //Constructor sin parametros
        public Venta() 
        {
            this.Id = 0;
            this.Comentarios = String.Empty;
            this.CantidadVentas = 0;
        }

        //Constructor con parametros
        public Venta(int id, string comentarios, int cantidadVentas)
        {
            this.Id = id;
            this.Comentarios = comentarios;
            this.CantidadVentas = cantidadVentas;
        }

        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int CantidadVentas { get; set; }

        // Método para visualizar el valor de los atributos
        public void verAtributos()
        {
            Console.WriteLine("\nVenta:" +
                                "\n   id = " + Id.ToString() +
                                "\n   comentarios = " + Comentarios +
                                "\n   cantidad de ventas = " + CantidadVentas.ToString() +
                                "\n");
        }

    }
}
