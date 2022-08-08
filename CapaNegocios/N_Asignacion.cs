using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class N_Asignacion
    {
        D_Asignacion objDato = new D_Asignacion();
        public List<E_Asignacion> ListarAsignacion(string buscar)
        {
            return objDato.ListarAsignacion(buscar);
        }

        public void InsertandoAsignacion(E_Asignacion asignacion)
        {
            objDato.InsertarAsignacion(asignacion);
        }

        public void EditandoAsignacion(E_Asignacion asignacion)
        {
            objDato.EditarAsignacion(asignacion);
        }

        public void EliminandoAsignacion(E_Asignacion asignacion)
        {
            objDato.EliminarAsignacion(asignacion);
        }
    }
}
