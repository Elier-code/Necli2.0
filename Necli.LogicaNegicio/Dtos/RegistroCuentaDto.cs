namespace Necli.LogicaNegicio.Dtos;

public record RegistroCuentaDto(int Id, string Contraseña, string Nombres, string Apellidos, string Email, int NumeroTelefono)
{
    public float Saldo { get; internal set; }
}

