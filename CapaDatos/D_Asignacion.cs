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
    public class D_Asignacion
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Asignacion> ListarAsignacion(string buscar)
        {
            SqlDataReader LeerRegistros;
            SqlCommand command = new SqlCommand("SP_BUSCAR_ASIGNACION", conexion);
            command.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            command.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerRegistros = command.ExecuteReader();

            List<E_Asignacion> Listar = new List<E_Asignacion>();
            while (LeerRegistros.Read())
            {
                Listar.Add(new E_Asignacion
                {
                    IdAsignacion = LeerRegistros.GetInt32(0),
                    NombreChofer = LeerRegistros.GetString(1),
                    AutobusAsignado = LeerRegistros.GetString(2),
                    RutaAsignada = LeerRegistros.GetString(3)

                });
            }

            conexion.Close();
            LeerRegistros.Close();
            return Listar;
        }

        public void InsertarAsignacion(E_Asignacion asignacion)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_ASIGNACION", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE_CHOFER", asignacion.NombreChofer);
            cmd.Parameters.AddWithValue("@AUTOBUS_ASIGNADO", asignacion.AutobusAsignado);
            cmd.Parameters.AddWithValue("@RUTA_ASIGNADA", asignacion.RutaAsignada);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarAsignacion(E_Asignacion asignacion)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_ASIGNACION", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID_ASIGNACION", asignacion.IdAsignacion);
            cmd.Parameters.AddWithValue("@NOMBRE_CHOFER", asignacion.NombreChofer);
            cmd.Parameters.AddWithValue("@AUTOBUS_ASIGNADO", asignacion.AutobusAsignado);
            cmd.Parameters.AddWithValue("@RUTA_ASIGNADA", asignacion.RutaAsignada);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarAsignacion(E_Asignacion asignacion)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_ASIGNACION", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID_ASIGNACION", asignacion.IdAsignacion);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
