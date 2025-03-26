using Microsoft.Data.SqlClient;
using Necli.Entidades;
using System.Transactions;


namespace Necli.Persistencia
{
    public class TransaccionesRepositorio
    {
        private readonly string _cadena_conexion = "Server=LAPTOP-UVUGVE35\\WEB2DB;Database=Necli;Trusted_Connection=True; TrustServerCertificate=True;";
        private string sql = "";

        public bool RegistrarTransaccion(Transaccion transaccion)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                conexion.Open();
                sql = "INSERT INTO Transacciones (Fecha, NumeroCuentaOrigen, NumeroCuentaDestino, Monto, Tipo) VALUES (@Fecha, @NumeroCuentaOrigen, @NumeroCuentaDestino, @Monto, @Tipo)";

                using (var comando = new SqlCommand(sql,conexion))
                {
                    
                    comando.Parameters.AddWithValue("@Fecha", transaccion.Fecha);
                    comando.Parameters.AddWithValue("@NumeroCuentaOrigen", transaccion.NumeroCuentaOrigen);
                    comando.Parameters.AddWithValue("@NumeroCuentaDestino", transaccion.NumeroCuentaDestino);
                    comando.Parameters.AddWithValue("@Monto", transaccion.Monto);
                    comando.Parameters.AddWithValue("@Tipo", transaccion.Tipo);
                    comando.ExecuteNonQuery();
                }


            }


            return true;
        } 


        public List<Transaccion> ConsultarTransaccion(string telefono,DateOnly desdeFecha,DateOnly hastaFecha)
        {
            var Transaciones = new List<Transaccion>();

            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                sql = "SELECT * FROM Transacciones WHERE (NumeroCuentaOrigen = @NumeroCuentaOrigen OR NumeroCuentaDestino = @NumeroCuentaDestino) AND Fecha between @desdeFecha and @hastafecha";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@NumeroCuentaOrigen", telefono);
                    comando.Parameters.AddWithValue("@NumeroCuentaDestino", telefono);
                    comando.Parameters.AddWithValue("@desdeFecha", desdeFecha.ToDateTime(TimeOnly.MinValue));
                    comando.Parameters.AddWithValue("@hastaFecha", hastaFecha.ToDateTime(TimeOnly.MinValue));
                    conexion.Open();
                    var lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        var transaccion = new Transaccion
                        {
                            Fecha = lector["Fecha"] != DBNull.Value
                            ? DateOnly.FromDateTime(Convert.ToDateTime(lector["Fecha"]))
                            : default,
                            Monto = Convert.ToSingle(lector["Monto"].ToString()),
                            Numero = (int)Convert.ToUInt32(lector["Numero"].ToString()),
                            NumeroCuentaDestino = lector["NumeroCuentaDestino"].ToString(),
                            NumeroCuentaOrigen = lector["NumeroCuentaOrigen"].ToString(),
                            Tipo = lector["Tipo"].ToString()

                        };
                        Transaciones.Add(transaccion);
                        
                    }

                }

            }



            return Transaciones;
        }















    }
}
