using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;
using System.Data;

namespace CapaDatos
{
    public class D_Rutas
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Rutas> ListarRutas(string buscar)
        {
            SqlDataReader LeerRegistros;
            SqlCommand command = new SqlCommand("SP_BUSCAR_RUTA", conexion);
            command.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            command.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerRegistros = command.ExecuteReader();

            List<E_Rutas> Listar = new List<E_Rutas>();
            while (LeerRegistros.Read())
            {
                Listar.Add(new E_Rutas
                {
                    IdRuta = LeerRegistros.GetInt32(0),
                    Nombre = LeerRegistros.GetString(1),
                    Salida = LeerRegistros.GetString(2),
                    Final = LeerRegistros.GetString(3),
                    Horario = LeerRegistros.GetString(4)

                });
            }

            conexion.Close();
            LeerRegistros.Close();
            return Listar;
        }

        public void InsertarRuta(E_Rutas rutas)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_RUTA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", rutas.Nombre);
            cmd.Parameters.AddWithValue("@SALIDA", rutas.Salida);
            cmd.Parameters.AddWithValue("@FINAL", rutas.Final);
            cmd.Parameters.AddWithValue("@HORARIO", rutas.Horario);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarRuta(E_Rutas rutas)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_RUTA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID_RUTA", rutas.IdRuta);
            cmd.Parameters.AddWithValue("@NOMBRE", rutas.Nombre);
            cmd.Parameters.AddWithValue("@SALIDA", rutas.Salida);
            cmd.Parameters.AddWithValue("@FINAL", rutas.Final);
            cmd.Parameters.AddWithValue("@HORARIO", rutas.Horario);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarRutas(E_Rutas rutas)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_RUTA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID_RUTA", rutas.IdRuta);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
