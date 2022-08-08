using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_Autobuses
    {
        private int _IdAutobus;
        private string _Marca;
        private string _Modelo;
        private string _Placa;
        private string _Color;
        private int _Año;
        private string _Condicion;
        private string _Capacidad;

        public int IdAutobus { get => _IdAutobus; set => _IdAutobus = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public string Placa { get => _Placa; set => _Placa = value; }
        public string Color { get => _Color; set => _Color = value; }
        public int Año { get => _Año; set => _Año = value; }
        public string Condicion { get => _Condicion; set => _Condicion = value; }
        public string Capacidad { get => _Capacidad; set => _Capacidad = value; }
    }
}
