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
        public ActionResult<RespuestaTransaccionDto> registrarTransaccion(RegistroTransaccionDto transaccion)
        {
            var resultado = _transaccionService.RegistrarTransaccion(transaccion);

            var respuesta = new RespuestaTransaccionDto
            {
                Exito = resultado.Item1, // Suponiendo que devuelve (bool, string)
                Mensaje = resultado.Item2
            };

            return Ok(respuesta);

        }

        [HttpGet("{numero}/{desdeFecha}/{hastaFecha}")]
        public ActionResult<List<Transaccion>> consultarTransaccionPorfecha(string numero, DateOnly desdeFecha,DateOnly hastaFecha)
        {
            return Ok(_transaccionService.listaTransacciones(numero, desdeFecha, hastaFecha));
        }
    }
}
