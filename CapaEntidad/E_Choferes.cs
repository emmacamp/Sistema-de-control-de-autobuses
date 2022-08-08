using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_Choferes
    {
        private int _IdChofer;
        private string _Nombres;
        private string _Apellidos;
        private string _FNacimiento;
        private string _Cedula;
        private int _Edad;
        private string _Telefono;
        private string _Sexo;
        private string _Nacionalidad;

        public int IdChofer { get => _IdChofer; set => _IdChofer = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string FNacimiento { get => _FNacimiento; set => _FNacimiento = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public int Edad { get => _Edad; set => _Edad = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public string Nacionalidad { get => _Nacionalidad; set => _Nacionalidad = value; }
        
    }
}
