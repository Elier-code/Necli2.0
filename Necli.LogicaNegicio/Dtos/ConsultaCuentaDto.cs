namespace Necli.LogicaNegicio.Dtos;

public record ConsultaCuentaDto (int Id, string Contraseña, string Nombres, string Apellidos, string Email, int NumeroTelefono, float Saldo, DateTime FechaCreacion);

