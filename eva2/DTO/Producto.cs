using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eva2.DTO
{
    internal class Producto
    {

        private string codigo;
        private string nombre;
        private string tipo;
        private int precio;
        private string descripcion;
        private string familia;
        private int estado;
        private int stock;
        private int stockCritico;

        public Producto(string codigo, string nombre, string tipo, int precio, string descripcion, string familia, int estado, int stock, int stockCritico)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.tipo = tipo;
            this.precio = precio;
            this.descripcion = descripcion;
            this.familia = familia;
            this.estado = estado;
            this.stock = stock;
            this.stockCritico = stockCritico;
        }

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Precio { get => precio; set => precio = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Familia { get => familia; set => familia = value; }
        public int Estado { get => estado; set => estado = value; }
        public int Stock { get => stock; set => stock = value; }
        public int StockCritico { get => stockCritico; set => stockCritico = value; }

        public override string ToString()
        {
            return this.codigo + " " + this.nombre;
        }
    }

   
}
