using eva2.DAL;
using eva2.DTO;
using eva2.Vista;
using XSystem.Security.Cryptography;

namespace eva2
{
   
    class Program
    {
        public static Vistas vi = new Vistas();
        private static CRUDUsuarios usuarioDal = new CRUDUsuarios();
        private static CRUDFamiliacs familiaDal = new CRUDFamiliacs();
        private static CRUDProductos productoDal = new CRUDProductos();

       

        static void Main(string[] args)
        {

            //Usuario u1 = new Usuario("19341278-5", "gerardo", "carvajal Sanhueza", "admin", "ulmo 1966", "Nikocarvajal@gmail.com", "c4ca4238a0b923820dcc509a6f75849b", 1);
            //u1.Tipousuarios = CRUDUsuarios.Tipoadm;
            //usuarioDal.InsertarArchivo(u1);

            insertarDearchivoalista();

            //Familia f1 = new Familia("127882gg","Tornillo madera","Tornillo de acero para madera punta cruz",1);
            //familiaDal.Insertar(f1);

            //Producto p1 = new Producto("asq-155","tornillo 1.5","construccion", 5990, "tornillo bauker", "127882gg;Tornillo madera",1,1243,123);
            //productoDal.insertar(p1);
            
           // Clogin();
            Cmenuprincipal(); 

   
            // agregarusuario();

            // pedirdatos();



        }

        public static void Clogin() {

            String[] datos = new String[2];
            bool pasa = false;
            datos = vi.login();

            if (datos[0].Equals("") || datos[1].Equals(""))
            {
                Console.SetCursorPosition(42, 22);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                String msj = " DEBE COMPLETAR TODOS LOS CAMPOS !";
                int i = 0;
                while (i <= 5){
                    Console.SetCursorPosition(42, 22);
                    Console.WriteLine(msj);
                    msj = msj + "!";
                    Thread.Sleep(200);
                    i++;
                }
              
                Clogin();
            }
            else
            {

                string FileToRead = usuarioDal.ruta;

                string[] lines = File.ReadAllLines(FileToRead);

                int i = 0;
                while (i < lines.Length)
                {
                    String[] ar = lines[i].Split(";");

                    //Console.WriteLine("claveing:"+ datos[0].Trim());
                    //Console.WriteLine("clavearch:"+ar[0]);
                   
                    if ((datos[0].Trim() == ar[0]) && (GetMD5Hash(datos[1].Trim()) == ar[1]))
                    {
                        pasa=true;
                        Cmenuprincipal();
                    }
                    i = i + 1;
                }
              
            }

            if (pasa) {

                Cmenuprincipal();

            }
            else{
                Console.SetCursorPosition(42, 22);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                String ms = " Usuario y/o Clave incorrectas  !";
                int j = 0;
                while (j <= 5)
                {
                    Console.SetCursorPosition(42, 22);
                    Console.WriteLine(ms);
                    ms = ms + "!";
                    Thread.Sleep(250);
                    j++;
                }

                Clogin();


            }

        }


        public static void Cmenuprincipal() {

            int opc=vi.menuPrincipal();

            switch (opc)
            {
                case 1:
                   CmenuUsuarios(); 
                    break;
                case 2:
                   CmenuFamilia();
                    break;
                case 3:
                    CmenuProductos();
                    break;
                case 4:
                   
                  
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Cmenuprincipal();
                    break;
            }
        }

        public static void CmenuUsuarios()
        {

            int opc = vi.menuUsuarios();


            switch (opc)
            {
                case 1:
                    insertarUsuario();
                    break;
                case 2:
                     modificarUsuario();
                    break;
                case 3:
                    eliminarUsuario();
                    break;
                case 4:
                    ListarUsuarios();
                    break;
                case 5:
                    Cmenuprincipal();
                    break;
                case 6:
                    Console.Clear();
                   

                    Environment.Exit(0);
                    break;
                default:
                     CmenuUsuarios();  
                    break;
            }
        }

        public static void CmenuFamilia()
        {

            int opc = vi.menuFamilia();


            switch (opc)
            {
                case 1:
                   insertarFamilia();
                    break;
                case 2:
                    modificarFamilia();
                    break;
                case 3:
                    eliminaFamilia();
                    break;
                case 4:
                    ListarFamilia();
                    break;
                case 5:
                    Cmenuprincipal();
                    break;
                case 6:
                    Console.Clear();
                    
                    Environment.Exit(0);
                    break;
                default:
                    CmenuFamilia();
                    break;
            }
        }

        public static void CmenuProductos()
        {

            int opc = vi.menuProductos();


            switch (opc)
            {
                case 1:
                   insertarProducto();
                    break;
                case 2:
                    modificarProducto();
                    break;
                case 3:
                    eliminaProducto();
                    break;
                case 4:
                    listarProducto();
                    break;
                case 5:
                    Cmenuprincipal();
                    break;
                case 6:
                   

                    Environment.Exit(0);
                    break;
                default:
                    CmenuProductos();
                    break;
            }
        }

        public static void insertarDearchivoalista(){

            string  ruta =  @"D:\C#Programs\eva2\eva2\Usuarios.txt";;
            string[] lines = File.ReadAllLines(ruta);

            int k = 0;
            while (k < lines.Length)
            {
                String[] datos = lines[k].Split(";");

                int est;
                int.TryParse(datos[7], out est);

                Usuario u1 = new Usuario(datos[2], datos[3], datos[4], datos[0], datos[5], datos[6], datos[1], est);
               

                if (datos[8].Equals("0001"))
                {
                    u1.Tipousuarios = CRUDUsuarios.Tipobode;
                }
                else if (datos[8].Equals("0002"))
                {
                    u1.Tipousuarios = CRUDUsuarios.Tipoadm;
                }
                else if (datos[8].Equals("0003"))
                {
                    u1.Tipousuarios = CRUDUsuarios.Tipousu;
                }

                usuarioDal.InsertarLista(u1);


                k = k + 1;
            }

     

        }

        public static void insertarUsuario(){

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(20, 5);
                Console.WriteLine("┌─────────────────────────────────────────────────────────────────────┐");
                Console.SetCursorPosition(20, 6);
                Console.WriteLine("|                                                                     |▓▓░░");
                Console.SetCursorPosition(20, 7);
                Console.WriteLine("|                            Agregar Usuario                          |▓▓░░");
                Console.SetCursorPosition(20, 8);
                Console.WriteLine("|                                                                     |▓▓░░");
                Console.SetCursorPosition(20, 9);
                Console.WriteLine("|─────────────────────────────────────────────────────────────────────|▓▓░░");
                Console.SetCursorPosition(20, 10);
                Console.WriteLine("|          Rut       [                                   ]            |▓▓░░");
                Console.SetCursorPosition(20, 11);
                Console.WriteLine("|                                                                     |▓▓░░");
                Console.SetCursorPosition(45, 10);
                String r = Console.ReadLine();


                if (validaRut(r) && !existe(r))
                {


                bool blanco = false;
                do
                {

                    if (blanco) Console.ForegroundColor = ConsoleColor.Red;

                    Console.SetCursorPosition(20, 12);
                    Console.WriteLine("|       Usuario      [                                   ]            |▓▓░░");
                    Console.SetCursorPosition(20, 13);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(20, 14);
                    Console.WriteLine("|       Nombres      [                                   ]            |▓▓░░");
                    Console.SetCursorPosition(20, 15);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(20, 16);
                    Console.WriteLine("|    Apellidos       [                                   ]            |▓▓░░");
                    Console.SetCursorPosition(20, 17);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(20, 18);
                    Console.WriteLine("|    Direccion       [                                   ]            |▓▓░░");
                    Console.SetCursorPosition(20, 19);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(20, 20);
                    Console.WriteLine("|       E-mail       [                                   ]            |▓▓░░");
                    Console.SetCursorPosition(20, 21);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(20, 22);
                    Console.WriteLine("|        Clave       [                                   ]            |▓▓░░");


                    if (blanco) Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(45, 12);
                    String u = Console.ReadLine().Trim();
                    Console.SetCursorPosition(45, 14);
                    String n = Console.ReadLine().Trim().ToUpper();
                    Console.SetCursorPosition(45, 16);
                    String a = Console.ReadLine().Trim().ToUpper();
                    Console.SetCursorPosition(45, 18);
                    String d = Console.ReadLine().Trim().ToUpper();
                    Console.SetCursorPosition(45, 20);
                    String em = Console.ReadLine().Trim().ToUpper();
                    Console.SetCursorPosition(45, 22);

                    ConsoleKeyInfo key;

                    String c = "";
                    do
                    {

                        key = Console.ReadKey(true);
                        if (key.Key != ConsoleKey.Backspace)
                        {
                            c += key.KeyChar;
                            if (key.Key != ConsoleKey.Enter) Console.Write("*");
                        }
                    } while (key.Key != ConsoleKey.Enter);
                    // String c = Console.ReadLine();




                    int e;
                    do
                    {
                        Console.SetCursorPosition(20, 23);
                        Console.WriteLine("|                                                                     |▓▓░░");
                        Console.SetCursorPosition(20, 24);
                        Console.WriteLine("|        Estado   [1]activo [0]inactivo  [               ]            |▓▓░░");
                        Console.SetCursorPosition(20, 25);
                        Console.WriteLine("|                                                                     |▓▓░░");
                        Console.SetCursorPosition(20, 26);
                        Console.WriteLine("|─────────────────────────────────────────────────────────────────────|▓▓░░");
                        Console.SetCursorPosition(69, 24);
                        String op = Console.ReadLine();
                        int.TryParse(op, out e);

                    } while (e < 0 || e > 1);
                    int tipo;
                    do
                    {

                        Console.SetCursorPosition(20, 27);
                        Console.WriteLine("|                                                                     |▓▓░░");
                        Console.SetCursorPosition(20, 28);
                        Console.WriteLine("|            Tipo                        [               ]            |▓▓░░");
                        Console.SetCursorPosition(20, 29);
                        Console.WriteLine("|  [1] bodeguero - [2] admin - [3] usuario                            |▓▓░░");
                        Console.SetCursorPosition(20, 30);
                        Console.WriteLine("└─────────────────────────────────────────────────────────────────────┘▓▓░░");
                        Console.SetCursorPosition(20, 31);
                        Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");
                        Console.SetCursorPosition(69, 28);
                        String o = Console.ReadLine();
                        int.TryParse(o, out tipo);

                    } while (tipo < 1 || tipo > 3);

                   
                    c = GetMD5Hash(c.Trim());

                   




                    Usuario us = new Usuario(r, n, a, u, d, em, c, e);
                    if (tipo == 1)
                    {
                        us.Tipousuarios = CRUDUsuarios.Tipobode;
                    }
                    else if (tipo == 2)
                    {
                        us.Tipousuarios = CRUDUsuarios.Tipoadm;
                    }
                    else if (tipo == 3)
                    {
                        us.Tipousuarios = CRUDUsuarios.Tipousu;
                    }

                    if (!u.Equals("") && !n.Equals("") && !a.Equals("") && !d.Equals("") && !em.Equals("") && !c.Equals(""))
                    {
                        blanco = false;
                        usuarioDal.Insertar(us);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(35, 32);
                        Console.WriteLine("     USUARIO INGRESADO      !!!!!!!!!!!!!");
                        Thread.Sleep(1000);
                        Console.SetCursorPosition(35, 34);
                        Console.WriteLine("Ingrese una tecla para Continuar ...");
                        Console.ReadKey();
                        Cfin();

                    }
                    else {
                        blanco=true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(35, 32);
                        Console.WriteLine("Debe llenar todos los campos !!!!!");
                        Thread.Sleep(1000);


                    }





                } while (blanco);


                
                //fin();

            }
            else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(35, 32);
                    Console.WriteLine("RUT INVALIDO O ya se encuentra ingresado !!!!");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(35, 34);
                    Console.WriteLine("Ingrese una tecla para Continuar ...");
                    Console.ReadKey();
                    insertarUsuario();


             }

         }


        public static void insertarFamilia()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("┌─────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(20, 6);
            Console.WriteLine("|                                                                     |▓▓░░");
            Console.SetCursorPosition(20, 7);
            Console.WriteLine("|                            Agregar Familia                          |▓▓░░");
            Console.SetCursorPosition(20, 8);
            Console.WriteLine("|                                                                     |▓▓░░");
            Console.SetCursorPosition(20, 9);
            Console.WriteLine("|─────────────────────────────────────────────────────────────────────|▓▓░░");
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("|          ID        [                                   ]            |▓▓░░");
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("|                                                                     |▓▓░░");
            Console.SetCursorPosition(45, 10);
            String i = Console.ReadLine();


            if ( !existeFamilia(i))
            {


                bool blanco = false;
                do
                {

                    if (blanco) Console.ForegroundColor = ConsoleColor.Red;

                    Console.SetCursorPosition(20, 12);
                    Console.WriteLine("|       Nombre       [                                   ]            |▓▓░░");
                    Console.SetCursorPosition(20, 13);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(20, 14);
                    Console.WriteLine("| Descripcion  [                                                    ] |▓▓░░");
                    Console.SetCursorPosition(20, 15);
                    Console.WriteLine("|                                                                     |▓▓░░");
                  
                    if (blanco) Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(45, 12);
                    String n = Console.ReadLine().Trim().ToUpper();
                    Console.SetCursorPosition(37, 14);
                    String d = Console.ReadLine().Trim().ToUpper();
                  

                    int e;
                    do
                    {
                        Console.SetCursorPosition(20, 16);
                        Console.WriteLine("|                                                                     |▓▓░░");
                        Console.SetCursorPosition(20, 17);
                        Console.WriteLine("|        Estado   [1]activo [0]inactivo  [               ]            |▓▓░░");
                        Console.SetCursorPosition(20, 18);
                        Console.WriteLine("|                                                                     |▓▓░░");
                       
                        Console.SetCursorPosition(20, 19);
                        Console.WriteLine("└─────────────────────────────────────────────────────────────────────┘▓▓░░");
                        Console.SetCursorPosition(20, 20);
                        Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");
                        Console.SetCursorPosition(69, 17);
                        String op = Console.ReadLine();
                        int.TryParse(op, out e);

                    } while (e < 0 || e > 1);



                    Familia fa = new Familia(i,n,d,e);
                   

                    if (!n.Equals("") && !d.Equals("") )
                    {
                        blanco = false;
                        familiaDal.Insertar(fa);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(35, 22);
                        Console.WriteLine("     Familia INGRESADA correctamente      !!!!!!!!!!!!!");
                        Thread.Sleep(1000);
                        Console.SetCursorPosition(35, 24);
                        Console.WriteLine("Ingrese una tecla para Continuar ...");
                        Console.ReadKey();
                        Cfin();

                    }
                    else
                    {
                        blanco = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(35, 32);
                        Console.WriteLine("Debe llenar todos los campos !!!!!");
                        Thread.Sleep(1000);


                    }





                } while (blanco);



                //fin();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(35, 32);
                Console.WriteLine("Id ya se encuentra Ingresado !!!!");
                Thread.Sleep(1000);
                Console.SetCursorPosition(35, 34);
                Console.WriteLine("Ingrese una tecla para Continuar ...");
                Console.ReadKey();
                insertarFamilia();


            }

        }

        public static void insertarProducto()
        {

            Console.Clear();


            List<Familia> fam = familiaDal.Mostrar();
            if (fam.Count == 0)
            {
                Console.SetCursorPosition(20, 5);
                Console.WriteLine("No hay familia de productos , ingrese una !!!!");
                Console.ReadKey();

                Cfin();


            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(20, 5);
                Console.WriteLine("┌─────────────────────────────────────────────────────────────────────┐");
                Console.SetCursorPosition(20, 6);
                Console.WriteLine("|                                                                     |▓▓░░");
                Console.SetCursorPosition(20, 7);
                Console.WriteLine("|                            Agregar Producto                         |▓▓░░");
                Console.SetCursorPosition(20, 8);
                Console.WriteLine("|                                                                     |▓▓░░");
                Console.SetCursorPosition(20, 9);
                Console.WriteLine("|─────────────────────────────────────────────────────────────────────|▓▓░░");
                Console.SetCursorPosition(20, 10);
                Console.WriteLine("|       Codigo       [                                   ]            |▓▓░░");
                Console.SetCursorPosition(20, 11);
                Console.WriteLine("|                                                                     |▓▓░░");
                Console.SetCursorPosition(20, 12);
                Console.WriteLine("|       Nombre       [                                   ]            |▓▓░░");
                Console.SetCursorPosition(20, 13);
                Console.WriteLine("|                                                                     |▓▓░░");
                Console.SetCursorPosition(20, 14);
                Console.WriteLine("|         Tipo       [                                   ]            |▓▓░░");
                Console.SetCursorPosition(20, 15);
                Console.WriteLine("|                                                                     |▓▓░░");
                Console.SetCursorPosition(20, 16);
                Console.WriteLine("|   Precio(CLP)      [                                   ]            |▓▓░░");
                Console.SetCursorPosition(20, 17);
                Console.WriteLine("|                                                                     |▓▓░░");
                Console.SetCursorPosition(20, 18);
                Console.WriteLine("|  Descripcion       [                                   ]            |▓▓░░");
                Console.SetCursorPosition(20, 19);
                Console.WriteLine("|                                                                     |▓▓░░");
                Console.SetCursorPosition(20, 20);
                Console.WriteLine("└─────────────────────────────────────────────────────────────────────┘▓▓░░");





                Console.SetCursorPosition(42, 10);
                string c = Console.ReadLine();
                Console.SetCursorPosition(42, 12);
                string n = Console.ReadLine();
                Console.SetCursorPosition(42, 14);
                string t = Console.ReadLine();
                Console.SetCursorPosition(42, 16);
                string p = Console.ReadLine();
                Console.SetCursorPosition(42, 18);
                string d = Console.ReadLine();

                int pre;
                int.TryParse(p, out pre);


                if (c.Equals("") || n.Equals("") || t.Equals("") || p.Equals("") || d.Equals("") || pre < 1)
                {
                    Console.SetCursorPosition(42, 35);

                    Console.WriteLine("Debe llenar todos los campos correctamente");
                    Thread.Sleep(1000);
                    insertarProducto();
                }

                int s;
                String st;
                do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(20, 21);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(20, 22);
                    Console.WriteLine("|        Stock       [                                   ]            |▓▓░░");
                    Console.SetCursorPosition(20, 23);
                    Console.WriteLine("|                                                                     |▓▓░░");

                    Console.SetCursorPosition(42, 22);
                    st = Console.ReadLine();
                    int.TryParse(st, out s);

                    if (st.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(20, 25);
                        Console.WriteLine("Debe llenar el campo");
                        Thread.Sleep(1000);
                    }

                    if (s < 0)

                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(20, 25);
                        Console.WriteLine("Stock no puede ser menor a 0");
                        Thread.Sleep(1000);
                    }

                } while (s < 0 || st.Equals(""));

                int sc;
                String stc;
                do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(20, 24);
                    Console.WriteLine("|  Stock Critico     [                                   ]            |▓▓░░");
                    Console.SetCursorPosition(20, 25);
                    Console.WriteLine("└─────────────────────────────────────────────────────────────────────┘▓▓░░");
                    Console.SetCursorPosition(42, 24);
                    stc = Console.ReadLine();
                    int.TryParse(stc, out sc);

                    if (st.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(20, 26);
                        Console.WriteLine("Debe llenar el campo");
                        Thread.Sleep(1000);
                    }

                    if (sc < 0 || sc > s)

                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(20, 26);
                        Console.WriteLine("Stock critico no puede ser menor a 0 o mayor al STOCK");
                        Thread.Sleep(1000);
                    }

                } while (sc < 0 || sc > s || stc.Equals(""));

                int e;
                do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(20, 26);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(20, 27);
                    Console.WriteLine("|        Estado   [1]activo [0]inactivo  [               ]            |▓▓░░");
                    Console.SetCursorPosition(20, 28);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(20, 29);
                    Console.WriteLine("└─────────────────────────────────────────────────────────────────────┘▓▓░░");

                    Console.SetCursorPosition(69, 27);
                    String op = Console.ReadLine();
                    int.TryParse(op, out e);

                } while (e < 0 || e > 1);

                int numf;
                List<Familia> lines = familiaDal.Mostrar();
                do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(20, 30);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(20, 31);
                    Console.WriteLine("|      Seleccione N° Familia de productos    [       ]                |▓▓░░");
                    Console.SetCursorPosition(20, 32);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(20, 33);
                    Console.WriteLine("|  N°  |    Codigo   |          Nombre Famlia producto                |▓▓░░");
                    Console.SetCursorPosition(20, 34);
                    Console.WriteLine("|---------------------------------------------------------------------|▓▓░░");


                    int i = 0;

                    while (i < lines.Count)
                    {


                        Console.SetCursorPosition(20, 35 + i); Console.WriteLine("|  " + (i + 1));
                        Console.SetCursorPosition(28, 35 + i); Console.WriteLine("|  " + lines[i].ID1);
                        Console.SetCursorPosition(43, 35 + i); Console.WriteLine("|  " + lines[i].Nombre);

                        Console.SetCursorPosition(90, 35 + i); Console.WriteLine("|▓▓░░ ");

                        i = i + 1;
                    }
                    Console.SetCursorPosition(20, 35 + i);
                    Console.WriteLine("└─────────────────────────────────────────────────────────────────────┘▓▓░░");
                    Console.SetCursorPosition(20, 36 + i);
                    Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");
                    Console.SetCursorPosition(69, 31);
                    String op = Console.ReadLine();
                    int.TryParse(op, out numf);

                } while (numf < 1 || numf > lines.Count);

                String familia = lines[numf - 1].ID1 + ";" + lines[numf - 1].Nombre;

                Producto pr = new Producto(c, n, t, pre, d, familia, e, s, sc);

                productoDal.insertar(pr);
                Console.ForegroundColor = ConsoleColor.Green;

                Console.SetCursorPosition(40, 40);
                Console.WriteLine("    PRODUCTO INGRESADO CORRECTAMENTE");
                Thread.Sleep(700);
                Console.SetCursorPosition(40, 41);

                Console.WriteLine("Ingrese una tecla para Continuar ...");

                Console.ReadKey();
                Cfin();

            }






            // crud.insertar(productos);

        }

        public static void modificarUsuario()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(5, 6);
            Console.WriteLine("|                                                                                                            |▓▓░░");
            Console.SetCursorPosition(5, 7);
            Console.WriteLine("|                                Ingrese El ID modificar   [            ]                                    |▓▓░░");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("|                                                                                                            |▓▓░░");
            Console.SetCursorPosition(5, 9);
            Console.WriteLine("|────────────────────────────────────────────────────────────────────────────────────────────────────────────|▓▓░░");
            Console.SetCursorPosition(5, 10);


            Console.WriteLine("|   ID   |       Rut       |       Usuario       |                    Nombre             |       Tipo        |▓▓░░");
            Console.SetCursorPosition(5, 11);

            List<Usuario> lines = usuarioDal.Mostrar();
            //
            Console.WriteLine("|----------------------------------------------------------------------------------------|-------------------|▓▓░░");
            int i = 0;
            int cont = 1;
            while (i < lines.Count)
            {


                Console.SetCursorPosition(5, 12 + i); Console.WriteLine("|  " + cont);
                Console.SetCursorPosition(14, 12 + i); Console.WriteLine("|  " + lines[i].Rut);
                Console.SetCursorPosition(32, 12 + i); Console.WriteLine("|  " + lines[i].Usuari);
                Console.SetCursorPosition(54, 12 + i); Console.WriteLine("|  " + lines[i].Nombres + " " + lines[i].Apellidos);
                Console.SetCursorPosition(94, 12 + i); Console.WriteLine("|  " + lines[i].Tipousuarios.Nombre);
                Console.SetCursorPosition(114, 12 + i); Console.WriteLine("|▓▓░░ ");


                i = i + 1;
                cont = cont + 1;
            }
            Console.SetCursorPosition(5, 12 + i);
            Console.WriteLine("|        |                 |                     |                                       |                   |▓▓░░");
            Console.SetCursorPosition(5, 13 + i);
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(5, 14 + i);
            Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");

            Console.SetCursorPosition(71, 7);

            int num;
            String r = Console.ReadLine();
            int.TryParse(r, out num);

           
            if (num < 1 || num > cont)
            {


                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(40, 16 + i);
                Console.WriteLine("Id fuera de rango, volviendo a intentar ...");
                Thread.Sleep(1000);
                modificarUsuario();

            }
            else
            {

                pedirmodificar(num);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(40, 16 + i);
                Console.WriteLine("    Usuario Modificado Correctamente !!");
                Cfin();

            }

        }

        public static void modificarFamilia()
        {

            Console.Clear();

            List<Familia> fa =familiaDal.Mostrar();

            if (fa.Count < 1)
            {
                Console.SetCursorPosition(30, 12);
                Console.WriteLine("Tabla vacia!! , Volviendo...");
                Thread.Sleep(1000);
                Cfin();
            }


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(5, 6);
            Console.WriteLine("|                                                                                                            |▓▓░░");
            Console.SetCursorPosition(5, 7);
            Console.WriteLine("|                                Ingrese El Numero a modificar   [            ]                              |▓▓░░");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("|                                                                                                            |▓▓░░");
            Console.SetCursorPosition(5, 9);
            Console.WriteLine("|────────────────────────────────────────────────────────────────────────────────────────────────────────────|▓▓░░");
            Console.SetCursorPosition(5, 10);


            Console.WriteLine("| Numero |       ID        |       Nombre         |                    Descripcion                           |▓▓░░");
            Console.SetCursorPosition(5, 11);

            List<Familia> lines = familiaDal.Mostrar();
            //
            Console.WriteLine("|------------------------------------------------------------------------------------------------------------|▓▓░░");
            int i = 0;
            int cont = 1;
            while (i < lines.Count)
            {


                Console.SetCursorPosition(5, 12 + i); Console.WriteLine("|   " + cont);
                Console.SetCursorPosition(14, 12 + i); Console.WriteLine("|  " + lines[i].ID1);
                Console.SetCursorPosition(32, 12 + i); Console.WriteLine("|  " + lines[i].Nombre);
                Console.SetCursorPosition(55, 12 + i); Console.WriteLine("|  " + lines[i].Descripcion1);
                Console.SetCursorPosition(114, 12 + i); Console.WriteLine("|▓▓░░ ");


                i = i + 1;
                cont = cont + 1;
            }
            Console.SetCursorPosition(5, 12 + i);
            Console.WriteLine("|        |                 |                      |                                                          |▓▓░░");
            Console.SetCursorPosition(5, 13 + i);
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(5, 14 + i);
            Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");

            Console.SetCursorPosition(77, 7);

            int num;
            String r = Console.ReadLine();
            int.TryParse(r, out num);


            if (num < 1 || num > cont)
            {


                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(40, 16 + i);
                Console.WriteLine("Id fuera de rango, volviendo a intentar ...");
                Thread.Sleep(1000);
                modificarUsuario();

            }
            else
            {

                pedirmodificarFamilia(num);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(40, 16 + i);
                Console.WriteLine("    Usuario Modificado Correctamente !!");
                Cfin();

            }

        }

        public static void modificarProducto()
        {
            List<Producto> pr = productoDal.Mostrar();
            Console.Clear();
            if (pr.Count < 1)
            {
                Console.SetCursorPosition(30, 12);
                Console.WriteLine("Tabla vacia!! , Volviendo...");
                Thread.Sleep(1000);
                Cfin();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("|                                                                                             |▓▓░░");
            Console.SetCursorPosition(10, 7);
            Console.WriteLine("|                 Ingrese el N° de producto a Modificar    [     ]                            |▓▓░░");
            Console.SetCursorPosition(10, 8);
            Console.WriteLine("|                                                                                             |▓▓░░");
            Console.SetCursorPosition(10, 9);
            Console.WriteLine("|─────────────────────────────────────────────────────────────────────────────────────────────|▓▓░░");
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("|   N°   |    Codigo      |     Nombre     |  Precio(CLP)  |  Stock  |  Familia de Producto   |▓▓░░");
            Console.SetCursorPosition(10, 11);

            List<Producto> lines = productoDal.Mostrar();

            Console.WriteLine("|---------------------------------------------------------------------------------------------|▓▓░░");
            int i = 0;
            int cont = 1;
            while (i < lines.Count)
            {

                String[] fa = lines[i].Familia.Split(";");

                Console.SetCursorPosition(10, 12 + i); Console.WriteLine("|  " + (i+1));
                Console.SetCursorPosition(19, 12 + i); Console.WriteLine("| " + lines[i].Codigo);
                Console.SetCursorPosition(36, 12 + i); Console.WriteLine("|" + lines[i].Nombre);
                Console.SetCursorPosition(53, 12 + i); Console.WriteLine("| " + lines[i].Precio);
                Console.SetCursorPosition(69, 12 + i); Console.WriteLine("| " + lines[i].Stock);
                Console.SetCursorPosition(79, 12 + i); Console.WriteLine("| " + fa[1]);
                Console.SetCursorPosition(104, 12 + i); Console.WriteLine("|▓▓░░ ");

                i = i + 1;
                cont++;
            }

            Console.SetCursorPosition(10, 12 + i);
            Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(10, 13 + i);
            Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");

            Console.SetCursorPosition(72, 7);

            int num;
            String r = Console.ReadLine();
            int.TryParse(r, out num);


            if (num < 1 || num > cont)
            {


                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(40, 16 + i);
                Console.WriteLine("Id fuera de rango, volviendo a intentar ...");
                Thread.Sleep(1000);
                modificarProducto();

            }
            else
            {

                pedirmodificarProducto(num);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(40, 16 + i);
                Console.WriteLine("    Usuario Modificado Correctamente !!");
                Cfin();

            }

        }

        public static void pedirmodificar(int id)
        {

            List<Usuario> lines = usuarioDal.Mostrar();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Clear();
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("┌─────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(20, 6);
            Console.WriteLine("|                                                                     |▓▓░░");
            Console.SetCursorPosition(20, 7);
            Console.WriteLine("|                            MODIFICAR USUARIO                        |▓▓░░");
            Console.SetCursorPosition(20, 8);
            Console.WriteLine("|        (Pulse enter sobre el campo si no lo desea modificar)        |▓▓░░");
            Console.SetCursorPosition(20, 9);
            Console.WriteLine("|─────────────────────────────────────────────────────────────────────|▓▓░░");
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("|           Rut [ " + lines[(id - 1)].Rut + " ] ");
            Console.SetCursorPosition(54, 10); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("|                                                                     |▓▓░░");
            Console.SetCursorPosition(20, 12);
            Console.WriteLine("|       Usuario [ " + lines[(id - 1)].Usuari + " ] ");
            Console.SetCursorPosition(54, 12); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
            Console.SetCursorPosition(20, 13);
            Console.WriteLine("|                                                                     |▓▓░░");
            Console.SetCursorPosition(20, 14);
            Console.WriteLine("|       Nombres [ " + lines[(id - 1)].Nombres+ " ] ");
            Console.SetCursorPosition(54, 14); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
            Console.SetCursorPosition(20, 15);
            Console.WriteLine("|                                                                     |▓▓░░");
            Console.SetCursorPosition(20, 16);
            Console.WriteLine("|     Apellidos [ " + lines[(id - 1)].Apellidos + " ] ");
            Console.SetCursorPosition(54, 16); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
            Console.SetCursorPosition(20, 17);
            Console.WriteLine("|                                                                     |▓▓░░");
            Console.SetCursorPosition(20, 18);
            Console.WriteLine("|     Direccion [ " + lines[(id - 1)].Direccion + " ] ");
            Console.SetCursorPosition(54, 18); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
            Console.SetCursorPosition(20, 19);
            Console.WriteLine("|                                                                     |▓▓░░");
            Console.SetCursorPosition(20, 20);
            Console.WriteLine("|        E-Mail [ " + lines[(id - 1)].Email + " ] ");
            Console.SetCursorPosition(54, 20); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
            Console.SetCursorPosition(20, 21);
            Console.WriteLine("|                                                                     |▓▓░░");
            Console.SetCursorPosition(20, 22);
            Console.WriteLine("|        Clave  [ ********** ] ");
            Console.SetCursorPosition(54, 22); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
            Console.SetCursorPosition(20, 23);
            Console.WriteLine("|                                                                     |▓▓░░");
       

           



            Console.SetCursorPosition(65, 10);
            String r = Console.ReadLine();

            if (!existe(r) || r.Equals(lines[(id - 1)].Rut))
             {

                if (!r.Equals("") && !validaRut(r))
                {

                    Console.SetCursorPosition(40, 32);
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Rut INVALIDO!!!!");
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(40, 34);
                    Console.WriteLine("Volviendo a intentar....");
                    Thread.Sleep(1000);
                    pedirmodificar(id);

                }
                else
                {



                    Console.SetCursorPosition(65, 12);
                    String u = Console.ReadLine();
                    Console.SetCursorPosition(65, 14);
                    String n = Console.ReadLine();
                    Console.SetCursorPosition(65, 16);
                    String p = Console.ReadLine();
                    Console.SetCursorPosition(65, 18);
                    String d = Console.ReadLine();
                    Console.SetCursorPosition(65, 20);
                    String em = Console.ReadLine();
                    Console.SetCursorPosition(65, 22);
                    ConsoleKeyInfo key;

                    String c = " ";
                    do
                    {

                        key = Console.ReadKey(true);
                        if (key.Key != ConsoleKey.Backspace)
                        {

                            c += key.KeyChar;
                            if (key.Key != ConsoleKey.Enter) Console.Write("*");
                        }
                    } while (key.Key != ConsoleKey.Enter);


                    int e; String estado;
                    do
                    {
                        Console.SetCursorPosition(20, 24);
                        Console.WriteLine("|       Estado  [  " + lines[(id - 1)].Estado + "  ] ");
                        Console.SetCursorPosition(54, 24); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
                        Console.SetCursorPosition(20, 25);
                        Console.WriteLine("|   [1]activo [0]inactivo                                             |▓▓░░");
                        Console.SetCursorPosition(20, 26);
                        Console.WriteLine("|                                                                     |▓▓░░");
                        Console.SetCursorPosition(65, 24);
                        estado = Console.ReadLine();
                        int.TryParse(estado, out e);

                    } while (e < 1 || e > 2);


                    int tipo;
                    do
                    {
                        Console.SetCursorPosition(20, 27);
                        Console.WriteLine("|      Tipo [ " + lines[(id - 1)].Tipousuarios.Nombre + " ]");
                        Console.SetCursorPosition(54, 27); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
                        Console.SetCursorPosition(20, 28);
                        Console.WriteLine("|  [1] bodeguero - [2] admin - [3] usuario                            |▓▓░░");
                        Console.SetCursorPosition(20, 29);
                        Console.WriteLine("└─────────────────────────────────────────────────────────────────────┘▓▓░░");
                        Console.SetCursorPosition(20, 30);
                        Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");

                        Console.SetCursorPosition(65, 27);
                        String o = Console.ReadLine();
                        int.TryParse(o, out tipo);

                    } while (tipo < 1 || tipo > 3);





                    //String e = Console.ReadLine();
                    int esta;

                    if (r.Equals("")) r = lines[(id - 1)].Rut;
                    if (u.Equals("")) u = lines[(id - 1)].Usuari;
                    if (n.Equals("")) n = lines[(id - 1)].Nombres;
                    if (p.Equals("")) p = lines[(id - 1)].Apellidos;
                    if (d.Equals("")) d = lines[(id - 1)].Direccion;
                    if (em.Equals("")) em = lines[(id - 1)].Email;
                    if (c.Equals(""))
                    {
                        c = lines[(id - 1)].Clave;
                    }
                    else
                    {
                        c = GetMD5Hash(c.Trim());
                    }
                    if (estado.Equals("")) esta = lines[(id - 1)].Estado;
                    else int.TryParse(estado, out esta);



                    Usuario usu = new Usuario(r, n, p, u, d, em, c, esta);
                    if (tipo == 1)
                    {
                        usu.Tipousuarios = CRUDUsuarios.Tipobode;
                    }
                    else if (tipo == 2)
                    {
                        usu.Tipousuarios = CRUDUsuarios.Tipoadm;
                    }
                    else if (tipo == 3)
                    {
                        usu.Tipousuarios = CRUDUsuarios.Tipousu;
                    }
                    Usuario antiguo = lines[id - 1];
                    usuarioDal.Eliminar(lines[id - 1]);
                    usuarioDal.Modificar((id - 1), usu, antiguo);
                    Console.SetCursorPosition(40, 32);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Usuario modificado exitosamente !!!!");
                    Thread.Sleep(1000);
                    Cfin();
                }

            }
            else
            {

                Console.SetCursorPosition(40, 32);
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(" REPETIDO!!!!");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(40, 34);
                Console.WriteLine("Volviendo a intentar....");
                Thread.Sleep(1000);
                pedirmodificar(id);

            }
        }
        public static void pedirmodificarProducto(int id)
        {

            List<Producto> lines = productoDal.Mostrar();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Clear();
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("┌─────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(20, 6);
            Console.WriteLine("|                                                                     |▓▓░░");
            Console.SetCursorPosition(20, 7);
            Console.WriteLine("|                            MODIFICAR Producto                       |▓▓░░");
            Console.SetCursorPosition(20, 8);
            Console.WriteLine("|        (Pulse enter sobre el campo si no lo desea modificar)        |▓▓░░");
            Console.SetCursorPosition(20, 9);
            Console.WriteLine("|─────────────────────────────────────────────────────────────────────|▓▓░░");
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("|        Codigo [ " + lines[(id - 1)].Codigo + " ] ");
            Console.SetCursorPosition(54, 10); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("|                                                                     |▓▓░░");
            Console.SetCursorPosition(20, 12);
            Console.WriteLine("|        Nombre [ " + lines[(id - 1)].Nombre + " ] ");
            Console.SetCursorPosition(54, 12); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
            Console.SetCursorPosition(20, 13);
            Console.WriteLine("|                                                                     |▓▓░░");
            Console.SetCursorPosition(20, 14);
            Console.WriteLine("|          Tipo [ " + lines[(id - 1)].Tipo + " ] ");
            Console.SetCursorPosition(54, 14); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
            Console.SetCursorPosition(20, 15);
            Console.WriteLine("|                                                                     |▓▓░░");
            Console.SetCursorPosition(20, 16);
            Console.WriteLine("|   Descripcion [ " + lines[(id - 1)].Descripcion + " ] ");
            Console.SetCursorPosition(54, 16); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
            Console.SetCursorPosition(20, 17);
            Console.WriteLine("|                                                                     |▓▓░░");

            

            Console.SetCursorPosition(65, 10);
            String c = Console.ReadLine();

            if (!existeproducto(c) || c.Equals(lines[(id - 1)].Codigo))
            {

                    Console.SetCursorPosition(65, 12);
                    String n = Console.ReadLine();
                    Console.SetCursorPosition(65, 14);
                    String t = Console.ReadLine();
                    Console.SetCursorPosition(65, 16);
                    String d = Console.ReadLine();

                int p;
                String pr;
                do
                {
                    Console.SetCursorPosition(20, 18);
                    Console.WriteLine("|       Precio  [  " + lines[(id - 1)].Precio + "  ] ");
                    Console.SetCursorPosition(54, 18); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
                    Console.SetCursorPosition(20, 19);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(65, 18);

                    pr = Console.ReadLine();
                    int.TryParse(pr, out p);




                } while (p < 1);


                int e; String estado;
                    do
                    {
                        Console.SetCursorPosition(20, 20);
                        Console.WriteLine("|       Estado  [  " + lines[(id - 1)].Estado + "  ] ");
                        Console.SetCursorPosition(54, 20); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
                        Console.SetCursorPosition(20, 21);
                        Console.WriteLine("|   [1]activo [0]inactivo                                             |▓▓░░");
                        Console.SetCursorPosition(20, 22);
                        Console.WriteLine("|                                                                     |▓▓░░");
                        Console.SetCursorPosition(65, 20);
                        estado = Console.ReadLine();
                        int.TryParse(estado, out e);

                    } while (e < 1 || e > 2);

                int s;
                String st;
                do
                {
                    Console.SetCursorPosition(20, 23);
                    Console.WriteLine("|        Stock  [  " + lines[(id - 1)].Stock + "  ] ");
                    Console.SetCursorPosition(54, 23); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
                    Console.SetCursorPosition(20, 24);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(65, 23);
                   
                    st = Console.ReadLine();
                    int.TryParse(st, out s);

                   

                    if (s < 0)

                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(20, 25);
                        Console.WriteLine("Stock no puede ser menor a 0");
                        Thread.Sleep(1000);
                    }

                } while (s < 0 );

                int sc;
                String stc;
                do
                {
                    Console.SetCursorPosition(20, 25);
                    Console.WriteLine("|Stock Critico  [  " + lines[(id - 1)].StockCritico + "  ] ");
                    Console.SetCursorPosition(54, 25); Console.WriteLine("Nuevo: [                         ]  |▓▓░░");
                    Console.SetCursorPosition(20, 26);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(65, 25);
                    stc = Console.ReadLine();
                    int.TryParse(stc, out sc);

                   

                    if (sc < 0 || sc > s)

                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(20, 26);
                        Console.WriteLine("Stock critico no puede ser menor a 0 o mayor al STOCK");
                        Thread.Sleep(1000);
                    }

                } while (sc < 0 || sc > s );

                int numf;
                String fa;
                List<Familia> li = familiaDal.Mostrar();
                do
                {

                    String[] nf = lines[(id - 1)].Familia.Split(";");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(20, 27 );
                    Console.WriteLine("└─────────────────────────────────────────────────────────────────────┘▓▓░░");
                    Console.SetCursorPosition(20, 28);
                    Console.WriteLine("|Familia de productos [ "+ nf[0] +" ]                ");
                    Console.SetCursorPosition(70, 28); Console.WriteLine("Nuevo N° : [     ]  |▓▓░░");
                   
                    Console.SetCursorPosition(20, 29);
                    Console.WriteLine("|                                                                     |▓▓░░");
                    Console.SetCursorPosition(20, 30);
                    Console.WriteLine("|  N°  |    Codigo   |          Nombre Famlia producto                |▓▓░░");
                    Console.SetCursorPosition(20, 31);
                    Console.WriteLine("|---------------------------------------------------------------------|▓▓░░");


                    int i = 0;

                    while (i < li.Count)
                    {


                        Console.SetCursorPosition(20, 32 + i); Console.WriteLine("|  " + (i + 1));
                        Console.SetCursorPosition(27, 32 + i); Console.WriteLine("|  " + li[i].ID1);
                        Console.SetCursorPosition(41, 32 + i); Console.WriteLine("|  " + li[i].Nombre);

                        Console.SetCursorPosition(90, 32 + i); Console.WriteLine("|▓▓░░ ");

                        i = i + 1;
                    }
                    Console.SetCursorPosition(20, 32 + i);
                    Console.WriteLine("└─────────────────────────────────────────────────────────────────────┘▓▓░░");
                    Console.SetCursorPosition(20, 33 + i);
                    Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");
                    Console.SetCursorPosition(84, 28);
                    fa = Console.ReadLine();
                    int.TryParse(fa, out numf);

                } while (numf < 1 || numf > li.Count);

                String familia = li[numf - 1].ID1 + ";" + li[numf - 1].Nombre;






                //String e = Console.ReadLine();
                int esta;

                    if (c.Equals("")) c = lines[(id - 1)].Codigo;
                    if (n.Equals("")) n = lines[(id - 1)].Nombre;
                    if (t.Equals("")) t = lines[(id - 1)].Tipo;
                    if (pr.Equals("")) p = lines[(id - 1)].Precio;
                    if (d.Equals("")) d = lines[(id - 1)].Descripcion;
                    if (fa.Equals("")) familia= lines[(id - 1)].Familia;
                    if (st.Equals("")) s = lines[(id - 1)].Stock;
                     if (stc.Equals("")) sc = lines[(id - 1)].StockCritico;

                 if (estado.Equals("")) esta = lines[(id - 1)].Estado;
                    else int.TryParse(estado, out esta);



                Producto prod = new Producto(c,n,t,p,d,familia,esta,s,sc);
                productoDal.Eliminar(lines[id - 1]);
                productoDal.Modificar(prod, (id - 1));



                Console.SetCursorPosition(40, 42);
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(" Producto modificado exitosamente !!!!");
                    Thread.Sleep(1000);
                    Cfin();
                }

            
            else
            {

                Console.SetCursorPosition(40, 42);
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(" REPETIDO!!!!");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(40, 34);
                Console.WriteLine("Volviendo a intentar....");
                Thread.Sleep(1000);
                pedirmodificar(id);

            }
        }


        public static void pedirmodificarFamilia(int id)
        {

            List<Familia> lines = familiaDal.Mostrar();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Clear();
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(20, 6);
            Console.WriteLine("|                                                                               |▓▓░░");
            Console.SetCursorPosition(20, 7);
            Console.WriteLine("|                       MODOFICAR FAMILIA DE PRODUCTOS                          |▓▓░░");
            Console.SetCursorPosition(20, 8);
            Console.WriteLine("|            (Pulse enter sobre el campo si no lo desea modificar)              |▓▓░░");
            Console.SetCursorPosition(20, 9);
            Console.WriteLine("|───────────────────────────────────────────────────────────────────────────────|▓▓░░");
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("|           ID [ " + lines[(id - 1)].ID1 + " ] ");
            Console.SetCursorPosition(54, 10); Console.WriteLine("     Nuevo: [                              ]  |▓▓░░");
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("|                                                                               |▓▓░░");
            Console.SetCursorPosition(20, 12);
            Console.WriteLine("|        Nombre [ "+ lines[(id - 1)].Nombre +" ] ");
            Console.SetCursorPosition(59, 12); Console.WriteLine("Nuevo: [                              ]  |▓▓░░");
            Console.SetCursorPosition(20, 13);
            Console.WriteLine("|                                                                               |▓▓░░");
            Console.SetCursorPosition(20, 14);
            Console.WriteLine("|   Descripcion [" + lines[(id - 1)].Descripcion1 + "] ");
            Console.SetCursorPosition(89, 14); Console.WriteLine("           |▓▓░░");
            Console.SetCursorPosition(20, 15); Console.WriteLine("|    Nueva : [                                                               ]  |▓▓░░");
            Console.SetCursorPosition(20, 16);
            Console.WriteLine("|                                                                               |▓▓░░");
            Console.SetCursorPosition(20, 17);
         
            


            Console.SetCursorPosition(67, 10);
            String i = Console.ReadLine();

            if (!existeFamilia(i) || i.Equals(lines[(id - 1)].ID1))
            {

                Console.SetCursorPosition(67, 12);
                String n = Console.ReadLine();
                Console.SetCursorPosition(35, 15);
                String d = Console.ReadLine();
            
                int e; String estado;
                do
                {


                    Console.SetCursorPosition(20, 17);
                    Console.WriteLine("|       Estado  [  " + lines[(id - 1)].Estado + "  ] ");
                    Console.SetCursorPosition(54, 17); Console.WriteLine("Nuevo: [                         ]            |▓▓░░");
                    Console.SetCursorPosition(20, 18);
                    Console.WriteLine("|   [1]activo [0]inactivo                                                       |▓▓░░");
                    Console.SetCursorPosition(20, 19);
                    Console.WriteLine("|                                                                               |▓▓░░");
                    Console.SetCursorPosition(20, 20);
                    Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘▓▓░░");
                    Console.SetCursorPosition(20, 21);
                    Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");
                    Console.SetCursorPosition(65, 17);
                    estado = Console.ReadLine();
                    int.TryParse(estado, out e);

                } while (e < 1 || e > 2);



                //String e = Console.ReadLine();
                int esta;

                if (i.Equals("")) i = lines[(id - 1)].ID1;
                if (n.Equals("")) n = lines[(id - 1)].Nombre;
                if (d.Equals("")) d = lines[(id - 1)].Descripcion1;
               
                if (estado.Equals("")) esta = lines[(id - 1)].Estado;
                else int.TryParse(estado, out esta);



                Familia fa = new Familia(i, n, d, esta);
              

                familiaDal.Eliminar(lines[id - 1]);
                familiaDal.Modificar((id - 1), fa);



                Console.SetCursorPosition(40, 22);
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(" Usuario modificado exitosamente !!!!");
                Thread.Sleep(1000);
                Cfin();


            }
            else
            {

                Console.SetCursorPosition(40, 22);
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Rut INVALIDO O REPETIDO!!!!");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(40, 24);
                Console.WriteLine("Volviendo a intentar....");
                Thread.Sleep(1000);
                pedirmodificarFamilia(id);

            }
        }


        public static void eliminarUsuario()
        {

            Console.Clear();

            List<Usuario> lines = usuarioDal.Mostrar();
            if (lines.Count < 1)
            {
                Console.SetCursorPosition(30, 12);
                Console.WriteLine("Tabla vacia!! , Volviendo...");
                Thread.Sleep(1000);
                Cfin();
            }



            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(5, 6);
            Console.WriteLine("|                                                                                                            |▓▓░░");
            Console.SetCursorPosition(5, 7);
            Console.WriteLine("|                               Ingrese El ID a Eliminar   [            ]                                    |▓▓░░");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("|                                                                                                            |▓▓░░");
            Console.SetCursorPosition(5, 9);
            Console.WriteLine("|────────────────────────────────────────────────────────────────────────────────────────────────────────────|▓▓░░");
            Console.SetCursorPosition(5, 10);


            Console.WriteLine("|   ID   |       Rut       |       Usuario       |                    Nombre             |       Tipo        |▓▓░░");
            Console.SetCursorPosition(5, 11);

            
            Console.WriteLine("|------------------------------------------------------------------------------------------------------------|▓▓░░");
            int i = 0;
            int cont = 1;
            while (i < lines.Count)
            {


                Console.SetCursorPosition(5, 12 + i); Console.WriteLine("|  " + cont);
                Console.SetCursorPosition(14, 12 + i); Console.WriteLine("|  " + lines[i].Rut);
                Console.SetCursorPosition(32, 12 + i); Console.WriteLine("|  " + lines[i].Usuari);
                Console.SetCursorPosition(54, 12 + i); Console.WriteLine("|  " + lines[i].Nombres + " " + lines[i].Apellidos);
                Console.SetCursorPosition(94, 12 + i); Console.WriteLine("|  " + lines[i].Tipousuarios.Nombre);
                Console.SetCursorPosition(114, 12 + i); Console.WriteLine("|▓▓░░ ");


                i = i + 1;
                cont = cont + 1;
            }
            Console.SetCursorPosition(5, 12 + i);
            Console.WriteLine("|        |                 |                     |                                       |                   |▓▓░░");
            Console.SetCursorPosition(5, 13 + i);
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(5, 14 + i);
            Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");

            Console.SetCursorPosition(71, 7);


            int num;
            //String op = Console.ReadLine();
            //int.TryParse(op, out opc);

            // int num = Convert.ToInt32(Console.ReadLine());
            String r = Console.ReadLine();
            int.TryParse(r, out num);
            // Console.WriteLine(num);
            if (num < 1 || num > cont)
            {
                Console.ForegroundColor = ConsoleColor.Red;



                Console.SetCursorPosition(40, 11);
                Console.WriteLine("Id fuera de rango, volviendo a intentar ...");
                Thread.Sleep(1000);
                eliminarUsuario();


            }
            else
            {
                
                List<Usuario> line = usuarioDal.Mostrar();

                usuarioDal.Eliminar(line[(num - 1)]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(40, 16 + i);
                Console.WriteLine("    Usuario Eliminado Correctamente !!");
                Thread.Sleep(1000);
                Cfin();


            }

        }

        public static void eliminaProducto()
        {

            Console.Clear();
            List<Producto> lines = productoDal.Mostrar();

            if (lines.Count < 1)
            {
                Console.SetCursorPosition(30, 12);
                Console.WriteLine("Tabla vacia!! , Volviendo...");
                Thread.Sleep(1000);
                Cfin();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("|                                                                                             |▓▓░░");
            Console.SetCursorPosition(10, 7);
            Console.WriteLine("|                        Ingrese El N° ELIMINAR   [            ]                              |▓▓░░");
            Console.SetCursorPosition(10, 8);
            Console.WriteLine("|                                                                                             |▓▓░░");
            Console.SetCursorPosition(10, 9);
            Console.WriteLine("|─────────────────────────────────────────────────────────────────────────────────────────────|▓▓░░");
            Console.SetCursorPosition(10, 10);


            Console.WriteLine("|   N°   |       Codigo       |       Nombre       |                   Familia                |▓▓░░");
            Console.SetCursorPosition(10, 11);
            
           
            //
            Console.WriteLine("|---------------------------------------------------------------------------------------------|▓▓░░");
            int i = 0;
            int cont = 1;
           
            while (i < lines.Count)
            {
                String[] fa = lines[i].Familia.Split(";");

                Console.SetCursorPosition(10, 12 + i); Console.WriteLine("|   " + cont);
                Console.SetCursorPosition(19, 12 + i); Console.WriteLine("|  " + lines[i].Codigo);
                Console.SetCursorPosition(40, 12 + i); Console.WriteLine("|  " + lines[i].Nombre);
                Console.SetCursorPosition(61, 12 + i); Console.WriteLine("|  " + fa[1]);
                Console.SetCursorPosition(104, 12 + i); Console.WriteLine("|▓▓░░ ");


                i = i + 1;
                cont = cont + 1;
            }
            Console.SetCursorPosition(10, 12 + i);
            Console.WriteLine("|        |                    |                    |                                          |▓▓░░");
            Console.SetCursorPosition(10, 13 + i);
            Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(10, 14 + i);
            Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");



            Console.SetCursorPosition(67, 7);


            int num;
           
            String r = Console.ReadLine();
            int.TryParse(r, out num);
        
            if (num < 1 || num > cont)
            {
                Console.ForegroundColor = ConsoleColor.Red;



                Console.SetCursorPosition(40, 11);
                Console.WriteLine("Id fuera de rango, volviendo a intentar ...");
                Thread.Sleep(1000);
                eliminaProducto();


            }
            else
            {
               
                

                productoDal.Eliminar(lines[(num - 1)]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(40, 16 + i);
                Console.WriteLine("    Producto Eliminado Correctamente !!");
                Thread.Sleep(1000);
                Cfin();


            }

        }

        public static void eliminaFamilia()
        {

            Console.Clear();
            List<Familia> lines = familiaDal.Mostrar();

            if (lines.Count < 1)
            {
                Console.SetCursorPosition(30, 12);
                Console.WriteLine("Tabla vacia!! , Volviendo...");
                Thread.Sleep(1000);
                Cfin();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("|                                                                                             |▓▓░░");
            Console.SetCursorPosition(10, 7);
            Console.WriteLine("|                        Ingrese El N° ELIMINAR   [            ]                              |▓▓░░");
            Console.SetCursorPosition(10, 8);
            Console.WriteLine("|                                                                                             |▓▓░░");
            Console.SetCursorPosition(10, 9);
            Console.WriteLine("|─────────────────────────────────────────────────────────────────────────────────────────────|▓▓░░");
            Console.SetCursorPosition(10, 10);


            Console.WriteLine("|   N°   |       ID       |       Nombre       |                   Descripcion                |▓▓░░");
            Console.SetCursorPosition(10, 11);


            //
            Console.WriteLine("|---------------------------------------------------------------------------------------------|▓▓░░");
            int i = 0;
            int cont = 1;

            while (i < lines.Count)
            {
                

                Console.SetCursorPosition(10, 12 + i); Console.WriteLine("|   " + cont);
                Console.SetCursorPosition(19, 12 + i); Console.WriteLine("|  " + lines[i].ID1);
                Console.SetCursorPosition(36, 12 + i); Console.WriteLine("|  " + lines[i].Nombre);
                Console.SetCursorPosition(57, 12 + i); Console.WriteLine("|  " + lines[i].Descripcion1);
                Console.SetCursorPosition(104, 12 + i); Console.WriteLine("|▓▓░░ ");


                i = i + 1;
                cont = cont + 1;
            }
            Console.SetCursorPosition(10, 12 + i);
            Console.WriteLine("|        |                |                    |                                              |▓▓░░");
            Console.SetCursorPosition(10, 13 + i);
            Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(10, 14 + i);
            Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");



            Console.SetCursorPosition(67, 7);


            int num;

            String r = Console.ReadLine();
            int.TryParse(r, out num);

            if (num < 1 || num > cont)
            {
                Console.ForegroundColor = ConsoleColor.Red;



                Console.SetCursorPosition(40, 11);
                Console.WriteLine("Id fuera de rango, volviendo a intentar ...");
                Thread.Sleep(1000);
                eliminaProducto();


            }
            else
            {



                familiaDal.Eliminar(lines[(num - 1)]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(40, 16 + i);
                Console.WriteLine("    Familia Eliminada Correctamente !!");
                Thread.Sleep(1000);
                Cfin();


            }

        }



        public static void ListarUsuarios()
        {


            Console.Clear();


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("|                                                                                             |▓▓░░");
            Console.SetCursorPosition(10, 7);
            Console.WriteLine("|                                        Lista de Usuarios                                    |▓▓░░");
            Console.SetCursorPosition(10, 8);
            Console.WriteLine("|                                                                                             |▓▓░░");
            Console.SetCursorPosition(10, 9);
            Console.WriteLine("|─────────────────────────────────────────────────────────────────────────────────────────────|▓▓░░");
            Console.SetCursorPosition(10, 10);


            Console.WriteLine("|       Rut     |        Usuario      |      Tipousuario     |           Nombre               |▓▓░░");
            Console.SetCursorPosition(10, 11);

            List<Usuario> lines = usuarioDal.Mostrar();

            Console.WriteLine("|---------------------------------------------------------------------------------------------|▓▓░░");
            int i = 0;
            while (i < lines.Count)
            {


                Console.SetCursorPosition(10, 12 + i); Console.WriteLine("|  " + lines[i].Rut);
                Console.SetCursorPosition(26, 12 + i); Console.WriteLine("|  " + lines[i].Usuari);
                Console.SetCursorPosition(48, 12 + i); Console.WriteLine("|  " + lines[i].Tipousuarios.Nombre);
                Console.SetCursorPosition(71, 12 + i); Console.WriteLine("|  " + lines[i].Nombres + " " + lines[i].Apellidos);
                Console.SetCursorPosition(104, 12 + i); Console.WriteLine("|▓▓░░ ");

                //    // Console.WriteLine("Clave: " + clave); 



                i = i + 1;
            }
            Console.SetCursorPosition(10, 12 + i);
            Console.WriteLine("|               |                     |                      |                                |▓▓░░");
            Console.SetCursorPosition(10, 13 + i);
            Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(10, 14 + i);
            Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");
            Thread.Sleep(1000);
            Console.SetCursorPosition(40, 16 + i); Console.WriteLine("Ingrese una tecla para Continuar ...");

            Console.ReadKey();
            Cfin();

        }


        public static void ListarFamilia()
        {


            Console.Clear();


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("|                                                                                             |▓▓░░");
            Console.SetCursorPosition(10, 7);
            Console.WriteLine("|                                  Lista de Familias de productos                             |▓▓░░");
            Console.SetCursorPosition(10, 8);
            Console.WriteLine("|                                                                                             |▓▓░░");
            Console.SetCursorPosition(10, 9);
            Console.WriteLine("|─────────────────────────────────────────────────────────────────────────────────────────────|▓▓░░");
            Console.SetCursorPosition(10, 10);


            Console.WriteLine("|      ID      |        Nombre      |                       Descripcion                       |▓▓░░");
            Console.SetCursorPosition(10, 11);

            List<Familia> lines =familiaDal.Mostrar();

            Console.WriteLine("|---------------------------------------------------------------------------------------------|▓▓░░");
            int i = 0;
            while (i < lines.Count)
            {


                Console.SetCursorPosition(10, 12 + i); Console.WriteLine("|  " + lines[i].ID1);
                Console.SetCursorPosition(25, 12 + i); Console.WriteLine("|  " + lines[i].Nombre);
                Console.SetCursorPosition(46, 12 + i); Console.WriteLine("|  " + lines[i].Descripcion1);
               
                Console.SetCursorPosition(104, 12 + i); Console.WriteLine("|▓▓░░ ");

                //    // Console.WriteLine("Clave: " + clave); 



                i = i + 1;
            }
            Console.SetCursorPosition(10, 12 + i);
            Console.WriteLine("|              |                    |                                                         |▓▓░░");
            Console.SetCursorPosition(10, 13 + i);
            Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(10, 14 + i);
            Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");
            Thread.Sleep(1000);
            Console.SetCursorPosition(40, 16 + i); Console.WriteLine("Ingrese una tecla para Continuar ...");

            Console.ReadKey();
            Cfin();

        }

        public static void listarProducto()
        {
            Console.Clear();


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("|                                                                                             |▓▓░░");
            Console.SetCursorPosition(10, 7);
            Console.WriteLine("|                                    Lista de Productos                                       |▓▓░░");
            Console.SetCursorPosition(10, 8);
            Console.WriteLine("|                                                                                             |▓▓░░");
            Console.SetCursorPosition(10, 9);
            Console.WriteLine("|─────────────────────────────────────────────────────────────────────────────────────────────|▓▓░░");
            Console.SetCursorPosition(10, 10);


            Console.WriteLine("|   Codigo   |    Nombre    |     Tipo     |  Precio(CLP)  |  Stock  |  Familia de Producto   |▓▓░░");
            Console.SetCursorPosition(10, 11);

            List<Producto> lines = productoDal.Mostrar();

            Console.WriteLine("|---------------------------------------------------------------------------------------------|▓▓░░");
            int i = 0;
            while (i < lines.Count)
            {

                String[] fa = lines[i].Familia.Split(";");

                Console.SetCursorPosition(10, 12 + i); Console.WriteLine("|  " + lines[i].Codigo);
                Console.SetCursorPosition(23, 12 + i); Console.WriteLine("| " + lines[i].Nombre);
                Console.SetCursorPosition(38, 12 + i); Console.WriteLine("|" + lines[i].Tipo);
                Console.SetCursorPosition(53, 12 + i); Console.WriteLine("| " + lines[i].Precio);
                Console.SetCursorPosition(69, 12 + i); Console.WriteLine("| " + lines[i].Stock);
                Console.SetCursorPosition(79, 12 + i); Console.WriteLine("| " + fa[1]);

                Console.SetCursorPosition(104, 12 + i); Console.WriteLine("|▓▓░░ ");

                //    // Console.WriteLine("Clave: " + clave); 


                i = i + 1;
            }
            
            Console.SetCursorPosition(10, 12 + i);
            Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────────────────┘▓▓░░");
            Console.SetCursorPosition(10, 13 + i);
            Console.WriteLine("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░");
            Thread.Sleep(1000);
            Console.SetCursorPosition(40, 15 + i); Console.WriteLine("Ingrese una tecla para Continuar ...");

            Console.ReadKey();
            Cfin();
        }



        public static bool validaRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));
                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }


        public static bool existe(String rut)
        {
            bool exi = false;
            List<Usuario> lines = usuarioDal.Mostrar();
            int i = 0;
            while (i < lines.Count)
            {

                if (lines[i].Rut.Equals(rut))
                {

                    exi = true;

                    return exi;

                }
                i = i + 1;
            }
            return exi;


        }
        public static bool existeproducto(String rut)
        {
            bool exi = false;
            List<Producto> lines = productoDal.Mostrar();
            int i = 0;
            while (i < lines.Count)
            {

                if (lines[i].Codigo.Equals(rut))
                {

                    exi = true;

                    return exi;

                }
                i = i + 1;
            }
            return exi;


        }

        public static bool existeFamilia(String id)
        {
            bool exi = false;
            List<Familia> lines = familiaDal.Mostrar();
            int i = 0;
            while (i < lines.Count)
            {

                if (lines[i].ID1.Equals(id))
                {

                    exi = true;

                    return exi;

                }
                i = i + 1;
            }
            return exi;

        }


        public static String GetMD5Hash(String input)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            String hash = s.ToString();
            return hash;
        }

        public static void Cfin() {

            int opc = vi.fin();

                 switch (opc)
            {
                case 1:
                    Cmenuprincipal();
                    break;
                case 2:
                    Console.Clear();
                   

                    Environment.Exit(0);
                    break;

                default:
                    Cfin();
                    break;
            }


        }



    }

}