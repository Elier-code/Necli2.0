using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Necli.Entidades;
using Necli.LogicaNegicio.Dtos;
using Necli.LogicaNegicio.Services;

namespace Necli.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        private readonly TransaccionService _transaccionService = new();

        [HttpPost]
        public ActionResult<bool> registrarTransaccion(RegistroTransaccionDto transaccion)
        {

            return Ok(_transaccionService.RegistrarTransaccion(transaccion));

        }

        [HttpGet("{numero}/{desdeFecha}/{hastaFecha}")]
        public ActionResult<List<Transaccion>> consultarTransaccionPorfecha(string numero, DateOnly desdeFecha,DateOnly hastaFecha)
        {
            return Ok(_transaccionService.listaTransacciones(numero, desdeFecha, hastaFecha));
        }
    }
}
