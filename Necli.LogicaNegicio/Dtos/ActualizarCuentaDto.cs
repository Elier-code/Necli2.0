using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Necli.LogicaNegicio.Dtos
{
    public record ActualizarCuentaDto(int Id, string Contraseña, string Nombres, string Apellidos, string Email, string NumeroTelefono);

}
