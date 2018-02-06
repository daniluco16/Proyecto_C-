using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2_Evaluación
{
    /*********************************
         Autor: Daniel de la Rosa Romero
         Fecha creación: 02/02/2018
         Última modificación: dd/mm/aaaa
         Versión: x.xx
        ***********************************/

    class Program
    {
        static public List<Aula> lis_aulas = new List<Aula>();

        static Aula a = new Aula();
       
        static void Main(string[] args)
        {
            string main_menu;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "\t \t *** Administración de aulas y ordenadores ***";
            do
            {
                Console.Clear();

                Console.WriteLine("\n \t ===GESTION DE ORDENADORES===\n" +
                    "\n \t 1. Aulas/Salas del centro" +
                    "\n \t 2. Ordenadores" +
                    "\n \t 3. Busquedas" +
                    "\n \t 4. Listados" +
                    "\n \t 5. Configuración" +
                    "\n \t 0. Salir");

                Console.Write("\n \t Escriba la opción del menu:  ");
                main_menu = Console.ReadLine();

                while (main_menu != "1" && main_menu != "2" && main_menu != "3" && main_menu != "4" && main_menu != "5" && main_menu !="0")
                {  
                    Console.Write("\n \t **ERROR** Vuelva a escoger una opción:  ");
                    main_menu = Console.ReadLine();    
                }
                switch (main_menu)
                {
                    case "1":
                        menu_aulas(); //Aulas
                        break;

                    case "2":
                        menu_ordenadores(); //Ordenadores
                        break;

                    case "3":
                        //Busqueda
                        break;

                    case "4":
                        menu_listado(); //Listas
                        break;

                    case "5":
                        menu_configuracion(); //Configuración
                        break;

                } 
            } while (main_menu != "0");   
        }
        static void menu_aulas()
        {
            Console.Title = "\t \t *** Aulas ***";
            string menu_aula;
            do
            {
                Console.Clear();

                Console.WriteLine("\n \t === AULAS ===\n" +
                    "\n \t 1. Ver aulas." +
                    "\n \t 2. Añadir aulas." +
                    "\n \t 3. Borrar aulas." +
                    "\n \t 4. Modificar aulas." +
                    "\n \t 0. Volver al menu principal.");

                Console.Write("\n \t Elige una de las opciones: ");
                menu_aula = Console.ReadLine();

                while (menu_aula != "1" && menu_aula != "2" && menu_aula != "3" && menu_aula != "4" && menu_aula != "0")
                {
                    Console.Write("\n \t **ERROR** Vuelve a elegir una opción correcta:  ");
                    menu_aula = Console.ReadLine();
                }
                switch (menu_aula)
                {
                    case "1":
                        a.verdatos();//Ver aulas
                        break;
                        
                    case "2":
                        Anadir_aula();//Añadir aulas
                        break;
                        
                    case "3":
                        borrar_aulas();//Borrar aulas
                        break;
                        
                    case "4":
                        modificar_aula();//Modificar aulas
                        break;
                }
            } while (menu_aula != "0");
        }

        static void Anadir_aula()
        {
            string anadir;
            int available_aula = 5;
            do
            {
                Console.Clear();
                
                int id;
                string nombre;
                string fecha = DateTime.Now.ToString();





                if (lis_aulas.Count == available_aula)
                {
                    Console.WriteLine("\n \t ***Has superado el limite de aulas registradas ,por favor borre algún aula***");
                    
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("\n \t === Añadir aulas === \n");

                    Console.Write("\t Identificador (0 ver lista de aulas):  ");//Controlar q si pulsa 0 ver lista 
                    id = int.Parse(Console.ReadLine());

                    for (int i = 0; i < lis_aulas.Count; i++)
                    {
                        if (lis_aulas[i].Id == id)
                        {
                            Console.Write("\n \t El ID introducido ya existe \n");

                            Console.Write("\n \t Identificador (0 ver lista de aulas):  ");
                            id = int.Parse(Console.ReadLine());


                        }
                    }

                    if (id == 0)
                    {
                        a.verdatos();
                        return;
                    }

                    while (id < 0)
                    {
                        Console.WriteLine(" \n \t ** Números negativos no permitidos** \n ");
                        Console.Write("\t Identificador:  ");
                        id = int.Parse(Console.ReadLine());
                    }


                    Console.Write("\n \t Nombre:  ");
                    nombre = Console.ReadLine();

                    if (nombre.Length > 40)
                    {
                        Console.WriteLine("\n \t El nombre que has introducido es superior a 40 carácteres ");
                        Console.Write("\n \t Vuelve a introducir Nombre:  ");
                        nombre = Console.ReadLine();

                    }


                    a = new Aula(id, nombre);
                    lis_aulas.Add(a);
                }
                Console.Write("\n \t ¿más aulas (S/N)?:  ");
                anadir = Console.ReadLine().ToUpper();

            } while (anadir == "S");
        }

        static void borrar_aulas()
        {
            string borraraula;
            bool existe_aula = false;
            int id;
            do
            {
                Console.Clear();

                Console.WriteLine("\n \t === Borrar Aulas === \n");

                if (lis_aulas.Count == 0)
                {
                    Console.WriteLine("\n \t La lista de Aulas está vacía ");
                    Console.WriteLine("\n \t Pulse intro para salir");
                    Console.ReadLine();
                    return;
                }

                Console.Write("\t Identificador (0 ver lista de aulas): ");

                id = int.Parse(Console.ReadLine());

                if (id == 0)
                {
                    a.verdatos();
                    return;//volvemo menu
                }
               

                for (int i = 0; i < lis_aulas.Count; i++)
                {
                    if (lis_aulas[i].Id == id)//comparamos los id de la lista con el introducido por el usuario 
                    {
                        string opcion;
                        Console.WriteLine("\n \t Se procedera a borrar el aula:  {0}", lis_aulas[i].Nombre);
                        Console.WriteLine("\n \t Esta aula tiene {0} ordenadores que serán tambien eliminados", lis_aulas[i].ordenador_lista.Count);

                        Console.Write("\n \t ¿Desea borrar el aula  (S/N):   ");
                        opcion = Console.ReadLine().ToUpper();

                        existe_aula = true;

                        if (opcion == "S")
                        {
                            lis_aulas.Remove(lis_aulas[i]);//borrar todo de la lista aula
                        }
                        if (opcion == "N")
                        {
                            Console.WriteLine("\n \t ..... No se borro el aula");
                        }
                       
                    }
                }
                if(existe_aula == false)
                {
                    Console.Write("\n \t **No existe dicho identificador** ");
                    Console.ReadLine();
                }

                Console.Write("\n \t ¿borrar más? (S/N):  ");
                borraraula = Console.ReadLine().ToUpper();


            } while (borraraula == "S");

        }

        static void modificar_aula()
        {
            string mod;

            do
            {
                Console.Clear();
                int id;
                string nuevo_nombre;

                Console.WriteLine("\n \t === Modificar Aulas === ");

                if (lis_aulas.Count == 0)
                {
                    Console.WriteLine("\n \t La lista de Aulas está vacía ");
                    Console.WriteLine("\n \t Pulse intro para salir");
                    Console.ReadLine();
                    return;
                }

                Console.Write("\t Identificador (0 ver lista de aulas): ");

                id = int.Parse(Console.ReadLine());

                if (id == 0)
                {
                    a.verdatos();
                    return;//volvemo menu
                }
                for (int i = 0; i < lis_aulas.Count; i++)
                {
                    if (lis_aulas[i].Id == id)
                    {
                        Console.Write("\n \t Nuevo nombre:  ");
                        nuevo_nombre = Console.ReadLine();
                        lis_aulas[i].Nombre = nuevo_nombre;

                    }
                }
                
                Console.WriteLine("\n \t modificar más aulas (S/N):  ");
                mod = Console.ReadLine().ToUpper();
            } while (mod == "S");
        }

        static void menu_ordenadores()
        {
            Console.Title = "\t \t *** ORDENADORES ***";
            string menu_ordenador;

            do
            {
                Console.Clear(); 
                Console.WriteLine("\n \t === ORDENADORES ===\n" +
                    "\n \t 1. Ver lista de ordenadores" +
                    "\n \t 2. Añadir ordenador" +
                    "\n \t 3. Borrar ordenador" +
                    "\n \t 4. Cambiar ordenador de aula" +
                    "\n \t 5. Modificar ordenador" +
                    "\n \t 0. Salir");

                Console.Write("\n \t Elige una opción del menu:  ");
                menu_ordenador = Console.ReadLine();

                while (menu_ordenador != "1" && menu_ordenador != "2" && menu_ordenador != "3" && menu_ordenador!= "4" && menu_ordenador != "5" && menu_ordenador != "0")
                {
                    Console.Write("\n \t **ERROR** Vuelva a escoger una opción:  ");
                    menu_ordenador = Console.ReadLine();
                }

                switch (menu_ordenador)
                {
                    case "1":
                        //Lista de ordenadores
                        break;

                    case "2":
                        //Añadir ordenador
                        break;

                    case "3":
                       ///Borrar ordenador
                        break;

                    case "4":
                       //Cambiar ordenador de aula
                        break;

                    case "5":
                        //Modificar ordenador
                        break;
                }

            } while (menu_ordenador != "0");
        }
        static void menu_listado()
        {
            Console.Title = "\t \t *** Tipos de Listado ***";
            string menu_lista;
            do
            {
                Console.Clear();

                Console.WriteLine("\n \t === LISTADO ===\n" +
                    "\n \t 1. Nº de ordenadores por aula." +
                    "\n \t 2. Lista de ordenadores ordenados por aula e identificador." +
                    "\n \t 3. Aplicaciones instaladas por cada ordenador." +
                    "\n \t 4. Características de cada ordenador." +
                    "\n \t 0. Volver al menu principal.");

                Console.Write("\n \t Elige una de las opciones: ");
                menu_lista = Console.ReadLine();

                while (menu_lista != "1" && menu_lista != "2" && menu_lista != "3" && menu_lista != "4" && menu_lista != "0")
                {
                    Console.Write("\n \t **ERROR** Vuelve ha elegir una opción correcta:  ");
                    menu_lista = Console.ReadLine();
                }
                switch (menu_lista)
                {
                    case "1":
                        //Ver aulas
                        break;

                    case "2":
                        //Añadir aulas
                        break;

                    case "3":
                        //Borrar aulas
                        break;

                    case "4":
                        //Modificar aulas
                        break;
                }
            } while (menu_lista != "0");
        }
        static void menu_configuracion()
        {
            string menu_config;
            do
            {
                Console.Title = "\t \t *** CONFIGURACIÓN ***";
                Console.Clear();

                Console.WriteLine("\n \t === Configuración ===\n" +
                    "\n \t 1. Número máximo de aulas." +
                    "\n \t 2. Número máximo de ordenadores por aula." +
                    "\n \t 9. Inicialización automática para pruebas." +
                    "\n \t 0. Volver al menu principal.");

                Console.Write("\n \t Elige una de las opciones: ");
                menu_config = Console.ReadLine();

                while (menu_config != "1" && menu_config != "2" && menu_config != "9" && menu_config != "0")
                {
                    Console.Write("\n \t **ERROR** Vuelve ha elegir una opción correcta:  ");
                    menu_config = Console.ReadLine();
                }
                switch (menu_config)
                {
                    case "1":
                        //Máximo aulas
                        break;

                    case "2":
                        //Máximo ordenadores
                        break;

                    case "9":
                        //Pruebas automáticas
                        break;
                }
            } while (menu_config != "0");
        }
    }
}

