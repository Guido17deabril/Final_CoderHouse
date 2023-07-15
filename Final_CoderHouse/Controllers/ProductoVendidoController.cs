using Final_CoderHouse.Models;
using Final_CoderHouse.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_CoderHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "TraerProductosVendidos")]
        public List<ProductoVendido> TraerProductosVendidosXIdUsuario(long idUsuario)
        {
            return ADO_ProductoVendido.TraerProductosVendidosXIdUsuario(idUsuario);
        }

    }
}
