using eva2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eva2.Vista
{
    public class Vistas
    {

        public String[] login()
        {
            String[] datos=new String[2];
            Console.Clear();
           

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(40, 8);
            Console.WriteLine("┌─────────────────────────────────────────┐");
            Console.SetCursorPosition(40, 9);
            Console.WriteLine("|                                         |▓▓░░");
            Console.SetCursorPosition(40, 10);
            Console.WriteLine("|             INICIO DE SESION            |▓▓░░");
            Console.SetCursorPosition(40, 11);
            Console.WriteLine("|                                         |▓▓░░");
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("|                                         |▓▓░░");
            Console.SetCursorPosition(40, 13);
            Console.WriteLine("|   Ususario:  [                    ]     |▓▓░░");
            Console.SetCursorPosition(40, 14);
            Console.WriteLine("|                                         |▓▓░░");
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("|      Clave:  [                    ]     |▓▓░░");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("|                                         |▓▓░░");
            Console.SetCursorPosition(40, 17);
            Console.WriteLine("|                                         |▓▓░░");
            Console.SetCursorPosition(40, 18);
            Console.WriteLine("└─────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(40, 19);
            Console.WriteLine(" ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");
            Console.SetCursorPosition(40, 20);
            Console.WriteLine("  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            Console.SetCursorPosition(57, 13);
            String usu = Console.ReadLine();

            ConsoleKeyInfo key;
            Console.SetCursorPosition(57, 15);
            String pass = " ";
            do
            {

                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
                {

                    pass += key.KeyChar;
                    if (key.Key != ConsoleKey.Enter)Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            datos[0] =usu;
            datos[1] =pass;

            //Console.WriteLine("Clave: " + pass);
            //Console.ReadKey();
            

            return datos;

           // archivo2(usu, pass);

        }
        public int menuPrincipal()
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(30, 9);
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("|                           MENU PRINCIPAL                               |▓▓");
            Console.SetCursorPosition(30, 11);
            Console.WriteLine("|                                                                        |▓▓░░");
            Console.SetCursorPosition(30, 12);
            Console.WriteLine("| Ingrese 1 para Mantenedor de Usuarios                                  |▓▓░░");
            Console.SetCursorPosition(30, 13);
            Console.WriteLine("|                                                         ┌──────────┐   |▓▓░░");
            Console.SetCursorPosition(30, 14);
            Console.WriteLine("| Ingrese 2 para Mantenedor de familia de productos       |          |   |▓▓░░");
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("|                                                         |          |   |▓▓░░");
            Console.SetCursorPosition(30, 16);
            Console.WriteLine("| Ingrese 3 para Mantenedor de productos                  |          |   |▓▓░░");
            Console.SetCursorPosition(30, 17);
            Console.WriteLine("|                                                         └──────────┘   |▓▓░░");
            Console.SetCursorPosition(30, 18);
            Console.WriteLine("| Ingrese 4 para Salir                                                   |▓▓░░");
            Console.SetCursorPosition(30, 19);
            Console.WriteLine("|                                                                        |▓▓░░");
            Console.SetCursorPosition(30, 20);
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(30, 21);
            Console.WriteLine(" ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");
            Console.SetCursorPosition(30, 22);
            Console.WriteLine("  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");


            int opc;
            do
            {
                Console.SetCursorPosition(93, 15);
                String op = Console.ReadLine();
                int.TryParse(op, out opc);
            } while (opc < 0 || opc > 4);

            Console.Clear();

            return opc;


        }

        public int menuUsuarios()
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(30, 9);
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("|                           MENU USUARIOS                                |▓▓");
            Console.SetCursorPosition(30, 11);
            Console.WriteLine("|                                                                        |▓▓░░");
            Console.SetCursorPosition(30, 12);
            Console.WriteLine("| Ingrese 1 Para Ingresar de Usuarios                                    |▓▓░░");
            Console.SetCursorPosition(30, 13);
            Console.WriteLine("|                                                         ┌──────────┐   |▓▓░░");
            Console.SetCursorPosition(30, 14);
            Console.WriteLine("| Ingrese 2 Para Modificar datos Usuario                  |          |   |▓▓░░");
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("|                                                         |          |   |▓▓░░");
            Console.SetCursorPosition(30, 16);
            Console.WriteLine("| Ingrese 3 Para Eliminar Usuario                         |          |   |▓▓░░");
            Console.SetCursorPosition(30, 17);
            Console.WriteLine("|                                                         └──────────┘   |▓▓░░");
            Console.SetCursorPosition(30, 18);
            Console.WriteLine("| Ingrese 4 Para Mostrar Usuarios                                        |▓▓░░");
            Console.SetCursorPosition(30, 19);
            Console.WriteLine("|                                                                        |▓▓░░");
            Console.SetCursorPosition(30, 20);
            Console.WriteLine("| Ingrese 5 Para Volver al Menu Principal                                |▓▓░░");
            Console.SetCursorPosition(30, 21);
            Console.WriteLine("|                                                                        |▓▓░░");
            Console.SetCursorPosition(30, 22);
            Console.WriteLine("| Ingrese 6 Para Salir al Escritorio                                     |▓▓░░");
            Console.SetCursorPosition(30, 23);
            Console.WriteLine("|                                                                        |▓▓░░");
            Console.SetCursorPosition(30, 24);
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(30, 25);
            Console.WriteLine(" ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");
            Console.SetCursorPosition(30, 26);
            Console.WriteLine("  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");


            int opc;
            do
            {
                Console.SetCursorPosition(94, 15);
                String op = Console.ReadLine();
                int.TryParse(op, out opc);
            } while (opc < 0 || opc > 6);

            return opc;

            Console.Clear();


        }

        public int menuFamilia()
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(30, 9);
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("|                           MENU FAMILIA DE PRODUCTOS                    |▓▓");
            Console.SetCursorPosition(30, 11);
            Console.WriteLine("|                                                                        |▓▓░░");
            Console.SetCursorPosition(30, 12);
            Console.WriteLine("| Ingrese 1 Para Ingresar de Familia de productos                        |▓▓░░");
            Console.SetCursorPosition(30, 13);
            Console.WriteLine("|                                                         ┌──────────┐   |▓▓░░");
            Console.SetCursorPosition(30, 14);
            Console.WriteLine("| Ingrese 2 Para Modificar Familia de productos           |          |   |▓▓░░");
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("|                                                         |          |   |▓▓░░");
            Console.SetCursorPosition(30, 16);
            Console.WriteLine("| Ingrese 3 Para Eliminar Familia de productos            |          |   |▓▓░░");
            Console.SetCursorPosition(30, 17);
            Console.WriteLine("|                                                         └──────────┘   |▓▓░░");
            Console.SetCursorPosition(30, 18);
            Console.WriteLine("| Ingrese 4 Para Mostrar Familias de productos                           |▓▓░░");
            Console.SetCursorPosition(30, 19);
            Console.WriteLine("|                                                                        |▓▓░░");
            Console.SetCursorPosition(30, 20);
            Console.WriteLine("| Ingrese 5 Para Volver al Menu Principal                                |▓▓░░");
            Console.SetCursorPosition(30, 21);
            Console.WriteLine("|                                                                        |▓▓░░");
            Console.SetCursorPosition(30, 22);
            Console.WriteLine("| Ingrese 6 Para Salir al Escritorio                                     |▓▓░░");
            Console.SetCursorPosition(30, 23);
            Console.WriteLine("|                                                                        |▓▓░░");
            Console.SetCursorPosition(30, 24);
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(30, 25);
            Console.WriteLine(" ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");
            Console.SetCursorPosition(30, 26);
            Console.WriteLine("  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");

           
            int opc;
            do
            {
                Console.SetCursorPosition(93, 15);
                String op = Console.ReadLine();
                int.TryParse(op, out opc);
            } while (opc < 0 || opc > 6);

            return opc;

            Console.Clear();

           
        }


        public int menuProductos()
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(30, 9);
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("|                           MENU  PRODUCTOS                              |▓▓");
            Console.SetCursorPosition(30, 11);
            Console.WriteLine("|                                                                        |▓▓░░");
            Console.SetCursorPosition(30, 12);
            Console.WriteLine("| Ingrese 1 Para Ingresar Producto                                       |▓▓░░");
            Console.SetCursorPosition(30, 13);
            Console.WriteLine("|                                                         ┌──────────┐   |▓▓░░");
            Console.SetCursorPosition(30, 14);
            Console.WriteLine("| Ingrese 2 Para Modificar Producto                       |          |   |▓▓░░");
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("|                                                         |          |   |▓▓░░");
            Console.SetCursorPosition(30, 16);
            Console.WriteLine("| Ingrese 3 Para Eliminar Productos                       |          |   |▓▓░░");
            Console.SetCursorPosition(30, 17);
            Console.WriteLine("|                                                         └──────────┘   |▓▓░░");
            Console.SetCursorPosition(30, 18);
            Console.WriteLine("| Ingrese 4 Para Mostrar Productos                                       |▓▓░░");
            Console.SetCursorPosition(30, 19);
            Console.WriteLine("|                                                                        |▓▓░░");
            Console.SetCursorPosition(30, 20);
            Console.WriteLine("| Ingrese 5 Para Volver al Menu Principal                                |▓▓░░");
            Console.SetCursorPosition(30, 21);
            Console.WriteLine("|                                                                        |▓▓░░");
            Console.SetCursorPosition(30, 22);
            Console.WriteLine("| Ingrese 6 Para Salir al Escritorio                                     |▓▓░░");
            Console.SetCursorPosition(30, 23);
            Console.WriteLine("|                                                                        |▓▓░░");
            Console.SetCursorPosition(30, 24);
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(30, 25);
            Console.WriteLine(" ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");
            Console.SetCursorPosition(30, 26);
            Console.WriteLine("  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");

        
            int opc;
            do
            {
                Console.SetCursorPosition(93, 15);
                String op = Console.ReadLine();
                int.TryParse(op, out opc);
            } while (opc < 0 || opc > 6);

            Console.Clear();
            return opc;

           
        }







       




        public int fin()
        {


            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(40, 9);
            Console.WriteLine("┌───────────────────────────────────────────────┐");
            Console.SetCursorPosition(40, 10);
            Console.WriteLine("|                 SELECCIONE                    |▓▓");
            Console.SetCursorPosition(40, 11);
            Console.WriteLine("|                                               |▓▓░░");
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("|    Ingrese 1 para volver al menu principal    |▓▓░░");
            Console.SetCursorPosition(40, 13);
            Console.WriteLine("|    Ingrese 2 para Salir AL ESCRITORIO         |▓▓░░");
            Console.SetCursorPosition(40, 14);
            Console.WriteLine("|                                               |▓▓░░");
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("|                 ┌────────┐                    |▓▓░░");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("|                 |        |                    |▓▓░░");
            Console.SetCursorPosition(40, 17);
            Console.WriteLine("|                 └────────┘                    |▓▓░░");
            Console.SetCursorPosition(40, 18);
            Console.WriteLine("|                                               |▓▓░░");
            Console.SetCursorPosition(40, 19);
            Console.WriteLine("└───────────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(40, 20);
            Console.WriteLine(" ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");
            Console.SetCursorPosition(40, 21);
            Console.WriteLine("   ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            Console.SetCursorPosition(62, 16);

            // int opc = Convert.ToInt32(Console.ReadLine());

            int opc;
            do
            {
                String op = Console.ReadLine();
                int.TryParse(op, out opc);
                Console.SetCursorPosition(60, 16);
            } while (opc < 0 || opc > 2);

            return opc;


        }






    }


}
