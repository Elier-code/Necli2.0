using Necli.Entidades;
using Necli.LogicaNegicio.Dtos;
using Necli.Persistencia;

namespace Necli.LogicaNegicio.Services;

public class CuentaService
{

    private readonly CuentaRepositorio _cuentaRepositorio = new CuentaRepositorio();

    public bool RegistrarCuenta(RegistroCuentaDto cuentaDto)
    {

        var cuenta = new Cuenta
        {

            Id = cuentaDto.Id,
            Contraseña = cuentaDto.Contraseña,
            Nombres = cuentaDto.Nombres,
            Apellidos = cuentaDto.Apellidos,
            Email = cuentaDto.Email,
            NumeroTelefono = cuentaDto.NumeroTelefono,
            Saldo = cuentaDto.Saldo,
            FechaCreacion = DateTime.Now

        };

        return _cuentaRepositorio.RegistarCuenta(cuenta);

    }

    public ConsultaCuentaDto ConsultarCuenta(int Telefono)
    {

        var cuenta = _cuentaRepositorio.ConsultarCuenta(Telefono);

        return new ConsultaCuentaDto(cuenta.Id, cuenta.Contraseña, cuenta.Nombres, cuenta.Apellidos, cuenta.Email, cuenta.NumeroTelefono, cuenta.Saldo, cuenta.FechaCreacion);

    }

    public ConsultaUsuarioDto ConsultarUsuario(int Telefono)
    {

        var cuenta = _cuentaRepositorio.ConsultarCuenta(Telefono);

        return new ConsultaUsuarioDto(cuenta.Id, cuenta.Nombres, cuenta.Apellidos, cuenta.Email, cuenta.NumeroTelefono);

    }

}
