using System.Security.Cryptography;

namespace Final_CoderHouse.Models
{
    public class Usuario
    {
        public Usuario() 
        {
            this.Id = 0;
            this.Nombre = String.Empty;
            this.Apellido = String.Empty;
            this.NombreUsuario = String.Empty;
            this.Contraseña = String.Empty;
            this.Mail = String.Empty;
        }

        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string contraseña, string mail)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NombreUsuario = nombreUsuario;
            this.Contraseña = contraseña;
            this.Mail = mail;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }

        // Método para visualizar el valor de los atributos
        public void verAtributos()
        {
            Console.WriteLine("\nUsuario" +
                                "\n   id = " + Id.ToString() +
                                "\n   nombre = " + Nombre +
                                "\n   apellido = " + Apellido +
                                "\n   nombreUsuario = " + NombreUsuario +
                                "\n   constraseña = " + Contraseña +
                                "\n   mail = " + Mail +
                                "\n");
        }

    }
}
