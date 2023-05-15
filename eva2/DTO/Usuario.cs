using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eva2.DTO
{
    internal class Usuario
    {

        public struct tipousuario
        {
            public string Nombre { get; set; }
            public string Codigo { get; set; }

        }

        private String rut;
        private String nombres;
        private String apellidos;
        private String usuario;
        private String direccion;
        private String email;
        private String clave;
        private int estado;

        public Usuario(string rut, string nombres, string apellidos, string usuario, string direccion, string email, string clave, int estado)
        {
            this.rut = rut;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.usuario = usuario;
            this.direccion = direccion;
            this.email = email;
            this.clave = clave;
            this.estado = estado;
        }


        public string Rut { get => rut; set => rut = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Usuari { get => usuario; set => usuario = value; }
        public string Direccion{ get => direccion; set => direccion = value; }
        public string Email { get =>   email; set => email = value; }

        public string Clave { get => clave; set => clave = value; }
        public int Estado { get => estado; set => estado = value; }



        public tipousuario Tipousuarios { get; set; }


    }
}
