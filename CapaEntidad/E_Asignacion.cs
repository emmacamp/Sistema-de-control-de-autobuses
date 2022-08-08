using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_Asignacion
    {
        private int _IdAsignacion;
        private string _NombreChofer;
        private string _AutobusAsignado;
        private string _RutaAsignada;

        public int IdAsignacion { get => _IdAsignacion; set => _IdAsignacion = value; }
        public string NombreChofer { get => _NombreChofer; set => _NombreChofer = value; }
        public string AutobusAsignado { get => _AutobusAsignado; set => _AutobusAsignado = value; }
        public string RutaAsignada { get => _RutaAsignada; set => _RutaAsignada = value; }
    }
}
