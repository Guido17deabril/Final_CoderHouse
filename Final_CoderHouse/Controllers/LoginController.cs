using Final_CoderHouse.Models;
using Final_CoderHouse.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Final_CoderHouse.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LoginController : Controller
    {
        [HttpGet(Name = "Inicio Sesion")]
        public Usuario IniciarSesion(string nombre, string contraseña) 
        {
            return ADO_Usuario.IniciarSesion(nombre, contraseña);
        }
    }
}
