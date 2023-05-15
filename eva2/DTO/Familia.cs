using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eva2.DTO
{
    internal class Familia
    {
        private String ID;
        private String nombre;
        private String Descripcion;
        private int estado;

        public Familia(string iD, string nombre, string descripcion, int estado)
        {
            ID1 = iD;
            this.Nombre = nombre;
            Descripcion1 = descripcion;
            this.Estado = estado;
        }

        public string ID1 { get => ID; set => ID = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
