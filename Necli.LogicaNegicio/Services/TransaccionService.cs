using Necli.Entidades;
using Necli.LogicaNegicio.Dtos;
using Necli.Persistencia;

namespace Necli.LogicaNegicio.Services
{
    public class TransaccionService
    {
        private readonly TransaccionesRepositorio _transaccionRepositorio = new TransaccionesRepositorio();
        private readonly CuentaRepositorio _cuentaRepositorio = new CuentaRepositorio();
        

        public (bool, string) RegistrarTransaccion(RegistroTransaccionDto transaccionDto)
        {
            var cuentaOrigen = _cuentaRepositorio.ConsultarCuenta(transaccionDto.NumeroCuentaOrigen);
            var cuentaDestino = _cuentaRepositorio.ConsultarCuenta(transaccionDto.NumeroCuentaDestino);

            if (cuentaOrigen != null && cuentaDestino != null)
            {
                if (transaccionDto.Monto > cuentaOrigen.Saldo)
                {
                    return (false, "Saldo Insuficiente");
                }
                else if (transaccionDto.Monto >= 1000.0f && transaccionDto.Monto <= 5000000.0f)
                {

                    var transaccion = new Transaccion
                    {

                        Fecha = transaccionDto.Fecha,
                        Monto = transaccionDto.Monto,
                        NumeroCuentaDestino = transaccionDto.NumeroCuentaDestino,
                        NumeroCuentaOrigen = transaccionDto.NumeroCuentaOrigen,
                        Tipo = transaccionDto.Tipo,


                    };
                    return (_transaccionRepositorio.RegistrarTransaccion(transaccion), "Transaccion exitosa");
                }

            }
            else
            {
                return (false, "La/s cuanta/s no existen");
            }

            return (false, "No se puedo hacer la Transaccion");
        }

        public List<ConsultarTransaccionDto> listaTransacciones(string telefono, DateOnly desdeFecha, DateOnly hastaFecha)
        {

            return _transaccionRepositorio.ConsultarTransaccion(telefono,desdeFecha,hastaFecha).Select(x => new ConsultarTransaccionDto(x.Numero,x.Fecha,x.NumeroCuentaOrigen,x.NumeroCuentaDestino,x.Monto,x.Tipo)).ToList();
        }



    }

}
