using Microsoft.AspNetCore.Mvc;
using Necli.Entidades;
using Necli.LogicaNegicio.Dtos;
using Necli.LogicaNegicio.Services;
using Necli.Persistencia;
namespace Necli.WepApi.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class CuentaController : Controller
{

    private readonly CuentaRepositorio _cuentaRepositorio= new();
    private readonly CuentaService _cuentaService = new();

    [HttpPost]
    public ActionResult<bool> RegistrarCuenta(RegistroCuentaDto cuenta)
    {

        return Ok(_cuentaService.RegistrarCuenta(cuenta));

    }

    [HttpGet("{telefono}")]
    public ActionResult<ConsultaCuentaDto> ConsultarCuenta(string telefono)
    {
        
        var cuenta = _cuentaService.ConsultarCuenta(telefono);

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

    [HttpGet]

    public ActionResult<List<Cuenta>> ListarCuentas()
    {
        
        return Ok(_cuentaService.ListarVehiculos());
    }
}
