using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class N_Rutas
    {
        D_Rutas objDato = new D_Rutas();
        public List<E_Rutas> ListarRutas(string buscar)
        {
            return objDato.ListarRutas(buscar);
        }

        public void InsertandoRuta(E_Rutas rutas)
        {
            objDato.InsertarRuta(rutas);
        }

        public void EditandoRuta(E_Rutas rutas)
        {
            objDato.EditarRuta(rutas);
        }

        public void EliminandoRuta(E_Rutas rutas)
        {
            objDato.EditarRuta(rutas);
        }
    }
}
