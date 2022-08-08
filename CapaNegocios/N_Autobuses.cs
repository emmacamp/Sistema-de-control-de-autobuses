using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class N_Autobuses
    {
        D_Autobuses objDato = new D_Autobuses();
        public List<E_Autobuses> ListarAutobuses(string buscar)
        {
            return objDato.ListarAutobuses(buscar);
        }

        public void InsertandoAutobus(E_Autobuses autobuses)
        {
            objDato.InsertarAutobus(autobuses);
        }

        public void EditandoAutobus(E_Autobuses autobuses)
        {
            objDato.EditarAutobus(autobuses);
        }

        public void EliminandoAutobus(E_Autobuses autobuses)
        {
            objDato.EliminarAutobus(autobuses);
        }
    }

}
