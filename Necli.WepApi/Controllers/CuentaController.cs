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

    [HttpGet("ConsultarCuenta")]
    public ActionResult<ConsultaCuentaDto> ConsultarCuenta([FromQuery] string telefono)
    {
        
        var cuenta = _cuentaService.ConsultarCuenta(telefono);

        if (cuenta == null)
        {

            return NotFound("La cuenta no ha sido encontrada");

        }

        return Ok(cuenta);

    }

    [HttpGet("ConsultarUsuario")]
    public ActionResult<ConsultaCuentaDto> ConsultarUsuario([FromQuery] int id)
    {

        var cuenta = _cuentaService.ConsultarUsuario(id);

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

    [HttpPut]
    public ActionResult<bool> ActualizarUsuario(ActualizarCuentaDto cuentaDto)
    {

        bool actualizado = _cuentaService.ActualizarCuenta(cuentaDto);

        if (actualizado)
        {
            return Ok("Cuenta actualizada correctamente.");
        }
        else
        {
            return NotFound("La cuenta no existe.");
        }

        
    }



}
