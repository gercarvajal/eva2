using eva2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eva2.DAL
{
    internal class CRUDFamiliacs
    {

        private static List<Familia> lista = new List<Familia>();

        public void Insertar(Familia fa)
        {

            lista.Add(fa);


        }

        public void Modificar(int indice, Familia fa)
        {

            lista.Insert(indice, fa);

        }
        public void Eliminar(Familia fa)
        {

            lista.Remove(fa);
        }

        public List<Familia> Mostrar()
        {

            return lista;
        }




    }
}
