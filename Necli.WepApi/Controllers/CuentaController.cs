using Microsoft.AspNetCore.Mvc;
using Necli.LogicaNegicio.Dtos;
using Necli.LogicaNegicio.Services;
using Necli.Persistencia;
namespace Necli.WepApi.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class CuentaController : Controller
{

    private readonly CuentaRepositorio _cuentaRepositorio;
    private readonly CuentaService _cuentaService = new();

    [HttpPost]
    public ActionResult<bool> RegistrarCuenta(RegistroCuentaDto cuenta)
    {

        return Ok(_cuentaService.RegistrarCuenta(cuenta));

    }

    [HttpGet]
    public ActionResult<ConsultaCuentaDto> ConsultarCuenta(int Telefono)
    {

        var cuenta = _cuentaService.ConsultarCuenta(Telefono);

        if (cuenta == null)
        {

            return NotFound("La cuenta no ha sido encontrada");

        }

        return Ok(cuenta);

    }

    [HttpDelete("{Telefono}")]
    public ActionResult<bool> EliminarCuenta(int Telefono)
    {

        var eliminado = _cuentaRepositorio.EliminarCuenta(Telefono);

        if (!eliminado)
        {
            return NotFound("La cuenta no ha sido encontrada");
        }

        return NoContent();
    }
}
