using eva2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eva2.DAL
{
    internal class CRUDProductos
    {

        private static List<Producto> productos = new List<Producto>();

        public void insertar(Producto pro)
        {
            productos.Add(pro);

        }

        public bool Modificar(Producto pro, int posicionProductos)
        {
            productos.Insert(posicionProductos, pro);

            return true;
        }

        public void Eliminar(Producto pro)
        {


            productos.Remove(pro);
        }

        public List<Producto> Mostrar()
        {
            return productos;
        }







    }
}
