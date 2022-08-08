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
    public class D_Autobuses
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Autobuses> ListarAutobuses(string buscar)
        {
            SqlDataReader LeerRegistros;
            SqlCommand command = new SqlCommand("SP_BUSCAR_AUTOBUS", conexion);
            command.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            command.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerRegistros = command.ExecuteReader();

            List<E_Autobuses> Listar = new List<E_Autobuses>();
            while (LeerRegistros.Read())
            {
                Listar.Add(new E_Autobuses
                {
                    IdAutobus = LeerRegistros.GetInt32(0),
                    Marca = LeerRegistros.GetString(1),
                    Modelo = LeerRegistros.GetString(2),
                    Placa = LeerRegistros.GetString(3),
                    Color = LeerRegistros.GetString(4),
                    Año = LeerRegistros.GetInt32(5),
                    Condicion = LeerRegistros.GetString(6),
                    Capacidad = LeerRegistros.GetString(7)

                });
            }

            conexion.Close();
            LeerRegistros.Close();
            return Listar;
        }

        public void InsertarAutobus(E_Autobuses autobuses)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_AUTOBUS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@MARCA", autobuses.Marca);
            cmd.Parameters.AddWithValue("@MODELO", autobuses.Modelo);
            cmd.Parameters.AddWithValue("@PLACA", autobuses.Placa);
            cmd.Parameters.AddWithValue("@COLOR", autobuses.Color);
            cmd.Parameters.AddWithValue("@AÑO", autobuses.Año);
            cmd.Parameters.AddWithValue("@CONDICION", autobuses.Condicion);
            cmd.Parameters.AddWithValue("@CAPACIDAD", autobuses.Capacidad);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarAutobus(E_Autobuses autobuses)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_AUTOBUS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID_AUTOBUS", autobuses.IdAutobus);
            cmd.Parameters.AddWithValue("@MARCA", autobuses.Marca);
            cmd.Parameters.AddWithValue("@MODELO", autobuses.Modelo);
            cmd.Parameters.AddWithValue("@PLACA", autobuses.Placa);
            cmd.Parameters.AddWithValue("@COLOR", autobuses.Color);
            cmd.Parameters.AddWithValue("@AÑO", autobuses.Año);
            cmd.Parameters.AddWithValue("@CONDICION", autobuses.Condicion);
            cmd.Parameters.AddWithValue("@CAPACIDAD", autobuses.Capacidad);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarAutobus(E_Autobuses autobuses)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_AUTOBUS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID_AUTOBUS", autobuses.IdAutobus);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
