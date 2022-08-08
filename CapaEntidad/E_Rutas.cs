using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_Rutas
    {
        private int _IdRuta;
        private string _Nombre;
        private string _Salida;
        private string _Final;
        private string _Horario;

        public int IdRuta { get => _IdRuta; set => _IdRuta = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Salida { get => _Salida; set => _Salida = value; }
        public string Final { get => _Final; set => _Final = value; }
        public string Horario { get => _Horario; set => _Horario = value; }
    }
}
