using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class N_Choferes
    {
        D_Choferes objDato = new D_Choferes();
        public List<E_Choferes> ListarChoferes(string buscar)
        {
            return objDato.ListarChoferes(buscar);
        }

        public void InsertandoChofer(E_Choferes choferes)
        {
            objDato.InsertarChofer(choferes);
        }

        public void EditandoChofer(E_Choferes choferes)
        {
            objDato.EditarChofer(choferes);
        }

        public void EliminandoChofer(E_Choferes choferes)
        {
            objDato.EliminarChofer(choferes);
        }
    }
}
