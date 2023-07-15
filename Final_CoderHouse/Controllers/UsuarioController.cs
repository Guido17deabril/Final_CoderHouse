using Final_CoderHouse.Models;
using Final_CoderHouse.Repository;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Controllers.DTOS;

namespace Final_CoderHouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        [HttpGet(Name = "Traer Usuario")]
        public Usuario TraerUsuarioXNombreUsuario(string nombreUsuario)
        {
            return ADO_Usuario.TraerUsuarioXNombreUsuario(nombreUsuario);
        }

        [HttpPut(Name = "Modificar Usuario")]
        public bool ModificarUsuario([FromBody] PutUsuario usuario) 
        {
            try
            {
                Usuario usuarioExistente = new Usuario();
                usuarioExistente = ADO_Usuario.TraerUsuario_conId(usuario.Id);
                if (usuarioExistente.Id <= 0)
                {
                    return false; 
                }
                else
                {
                    return ADO_Usuario.ModificarUsuario(
                    new Usuario
                    {
                        Id = usuario.Id,
                        Nombre = usuario.Nombre,
                        Apellido = usuario.Apellido,
                        NombreUsuario = usuario.NombreUsuario,
                        Contraseña = usuario.Contraseña,
                        Mail = usuario.Mail
                    }
                    );
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost(Name = "Crear Usuario")]
        public bool CrearUsuario([FromBody] PostUsuario usuario) 
        {
            try
            {
                return ADO_Usuario.CrearUsuario(
                    new Usuario
                    {
                        Nombre = usuario.Nombre,
                        Apellido = usuario.Apellido,
                        NombreUsuario = usuario.NombreUsuario,
                        Contraseña = usuario.Contraseña,
                        Mail = usuario.Mail
                    }
                );
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpDelete(Name = "EliminarUsuario")]
        public bool EliminarUsuario([FromBody] long id)
        {
            try
            {
                return ADO_Usuario.EliminarUsuario(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
