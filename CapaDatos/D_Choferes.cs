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
    public class D_Choferes
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Choferes> ListarChoferes (string buscar)
        {
            SqlDataReader LeerRegistros;
            SqlCommand command = new SqlCommand("SP_BUSCAR_CHOFER", conexion);
            command.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            command.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerRegistros = command.ExecuteReader();

            List<E_Choferes> Listar = new List<E_Choferes>();
            while(LeerRegistros.Read())
            {
                Listar.Add(new E_Choferes
                {
                    IdChofer = LeerRegistros.GetInt32(0),
                    Nombres = LeerRegistros.GetString(1),
                    Apellidos = LeerRegistros.GetString(2),
                    FNacimiento =LeerRegistros.GetString(3),
                    Cedula = LeerRegistros.GetString(4),
                    Edad = LeerRegistros.GetInt32(5),
                    Telefono = LeerRegistros.GetString(6),
                    Sexo = LeerRegistros.GetString(7),
                    Nacionalidad = LeerRegistros.GetString(8)

                }); 
            }

            conexion.Close();
            LeerRegistros.Close();
            return Listar;
        }

        public void InsertarChofer(E_Choferes choferes)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_CHOFER", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRES", choferes.Nombres);
            cmd.Parameters.AddWithValue("@APELLIDOS", choferes.Apellidos);
            cmd.Parameters.AddWithValue("@F_NACIMIENTO", choferes.FNacimiento);
            cmd.Parameters.AddWithValue("@CEDULA", choferes.Cedula);
            cmd.Parameters.AddWithValue("@EDAD", choferes.Edad);
            cmd.Parameters.AddWithValue("@TELEFONO", choferes.Telefono);
            cmd.Parameters.AddWithValue("@SEXO", choferes.Sexo);
            cmd.Parameters.AddWithValue("@NACIONALIDAD", choferes.Nacionalidad);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarChofer(E_Choferes choferes)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_CHOFER", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID_CHOFER", choferes.IdChofer);
            cmd.Parameters.AddWithValue("@NOMBRES", choferes.Nombres);
            cmd.Parameters.AddWithValue("@APELLIDOS", choferes.Apellidos);
            cmd.Parameters.AddWithValue("@F_NACIMIENTO", choferes.FNacimiento);
            cmd.Parameters.AddWithValue("@CEDULA", choferes.Cedula);
            cmd.Parameters.AddWithValue("@EDAD", choferes.Edad);
            cmd.Parameters.AddWithValue("@TELEFONO", choferes.Telefono);
            cmd.Parameters.AddWithValue("@SEXO", choferes.Sexo);
            cmd.Parameters.AddWithValue("@NACIONALIDAD", choferes.Nacionalidad);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarChofer(E_Choferes choferes)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_CHOFER", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID_CHOFER", choferes.IdChofer);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }

}
