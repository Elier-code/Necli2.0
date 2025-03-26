using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Necli.LogicaNegicio.Dtos
{
    public record ConsultarTransaccionDto(
        int numero,
        DateOnly Fecha,
        string NumeroCuentaOrigen,
        string NumeroCuentaDestino,
        float Monto,
        string Tipo


        );
}
