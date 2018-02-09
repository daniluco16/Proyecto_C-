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

        static public List<Ordenador> lis_ordenadores = new List<Ordenador>();

        static public List<Ordenador> lista_temp = new List<Ordenador>(); // Lista temporal para borrar todos los pc de un aula, sino borraria solo un pc 

        static Aula a = new Aula();//Creacion objeto aula

        static Ordenador b = new Ordenador();//Creacion objeto ordenador



        static int available_aula = 5;

        static int available_pc = 15;

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
            bool error = false;
            do
            {
                do
                {
                    try
                    {
                        error = false;
                        Console.Clear();

                        int id;
                        string nombre;
                        string fecha = DateTime.Now.ToString();

                        if (lis_aulas.Count == available_aula)
                        {
                            Console.WriteLine("\n \t ***Has superado el limite de aulas registradas ,por favor borre algún aula***");

                            Console.Write("\n \t PULSE INTRO PARA CONTINUAR");
                            Console.ReadLine();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\n \t === Añadir aulas === \n");

                            Console.Write("\t Identificador (0 ver lista de aulas):  ");

                            id = int.Parse(Console.ReadLine());

                            for (int i = 0; i < lis_aulas.Count; i++)
                            {
                                while (lis_aulas[i].Id == id)
                                {
                                    Console.Write("\n \t El ID introducido ya existe \n");

                                    Console.Write("\n \t Identificador (0 ver lista de aulas):  ");
                                    id = int.Parse(Console.ReadLine());
                                }
                            }

                            while (id < 0)
                            {
                                Console.WriteLine(" \n \t ** Números negativos no permitidos** \n ");
                                Console.Write("\t Identificador (0 ver lista de aulas):  ");
                                id = int.Parse(Console.ReadLine());
                            }

                            if (id == 0)//Controlar q si pulsa 0 ver lista
                            {
                                a.verdatos();
                                return;
                            }


                            Console.Write("\n \t Nombre:  ");
                            nombre = Console.ReadLine();

                            for (int i = 0; i < lis_aulas.Count; i++)
                            {
                                while (lis_aulas[i].Nombre == nombre)
                                {
                                    Console.Write("\n \t No puedes repetir nombres de aulas \n");

                                    Console.Write("\n \t Nombre:  ");
                                    nombre = Console.ReadLine();
                                }
                            }
                            
                            while (nombre == "")
                            {
                                Console.Write("\n \t No puedes dejar este campo vacio \n");

                                Console.Write("\n \t Nombre:  ");
                                nombre = Console.ReadLine();
                            }

                            while (nombre.Length > 40)
                            {
                                Console.WriteLine("\n \t El nombre que has introducido es superior a 40 carácteres ");
                                Console.Write("\n \t Vuelve a introducir Nombre:  ");
                                nombre = Console.ReadLine();

                            }


                            a = new Aula(id, nombre);
                            lis_aulas.Add(a);
                        }
                    }
                    catch
                    {
                        error = true;
                        Console.WriteLine("\n \t ** Carácter no permitido ");
                    }

                } while (error);
                
                Console.Write("\n \t ¿más aulas (S/N)?:  ");
                anadir = Console.ReadLine().ToUpper();

                while (anadir != "S" && anadir != "N" && anadir != "s" && anadir != "n")
                {
                    Console.Write("\n \t ERROR\n");

                    Console.Write("\n \t ¿más aulas (S/N)?:  ");
                    anadir = Console.ReadLine().ToUpper();
                }

            } while (anadir == "S");
        }

        static void borrar_aulas()
        {
            string borraraula;
            bool existe_aula = false;
            bool error = false;
            int id;
            
            do
            {
                do
                {
                    try
                    {
                        error = false;
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

                                while (opcion != "S" && opcion != "N" && opcion != "s" && opcion != "n")
                                {
                                    Console.Write("\n \t ERROR\n");

                                    Console.Write("\n \t ¿Desea borrar el aula (S/N)?:  ");
                                    opcion = Console.ReadLine().ToUpper();
                                }

                                existe_aula = true;

                                if (opcion == "S")
                                {
                                    for (int a = 0; a < lis_ordenadores.Count; a++)
                                    {
                                        if (lis_ordenadores[a].Aula != lis_aulas[i])
                                        {
                                            lista_temp.Add(lis_ordenadores[a]);                                            
                                        }
                                    }
                                    lis_ordenadores.Clear();

                                    for (int c = 0; c < lista_temp.Count; c++)
                                    {
                                        lis_ordenadores.Add(lista_temp[c]);
                                    }

                                    lista_temp.Clear();

                                    lis_aulas.Remove(lis_aulas[i]);//borrar todos los datos de un aula de la lista

                                }
                                if (opcion == "N")
                                {
                                    Console.WriteLine("\n \t ..... No se borro el aula");
                                }

                            }
                        }
                        if (existe_aula == false)
                        {
                            Console.Write("\n \t **No existe dicho identificador** ");
                            Console.ReadLine();
                        }

                       

                    }
                    catch
                    {
                        error = true;
                        Console.WriteLine("\n \t ** Carácter no permitido ");
                    }

                } while (error);
                
                Console.Write("\n \t ¿borrar más? (S/N):  ");
                borraraula = Console.ReadLine().ToUpper();

                while (borraraula != "S" && borraraula != "N" && borraraula != "s" && borraraula != "n")
                {
                    Console.Write("\n \t ERROR\n");

                    Console.Write("\n \t ¿borrar más aulas (S/N)?:  ");
                    borraraula = Console.ReadLine().ToUpper();
                }

            } while (borraraula == "S");

        }

        static void modificar_aula()
        {
            string mod;
            int id;
            string nuevo_nombre;
            bool error = false;

            do
            {
                do
                {
                    try
                    {
                        error = false;
                        Console.Clear();

                        Console.WriteLine("\n \t === Modificar Aulas ===\n ");

                        if (lis_aulas.Count == 0)
                        {
                            Console.WriteLine("\n \t La lista de Aulas está vacía ");
                            Console.WriteLine("\n \t Pulse intro para salir");
                            Console.ReadLine();
                            return;
                        }

                        Console.Write("\t Identificador (0 ver lista de aulas): ");

                        id = int.Parse(Console.ReadLine());

                                        
                            while (lis_aulas.Count != id)
                            {

                            if (id == 0)
                            {
                                a.verdatos();
                                return;//volvemos al menu
                            }

                                Console.Write("\n \t **No existe dicho identificador** \n ");

                                Console.Write("\n \t Identificador (0 ver lista de aulas): ");

                                id = int.Parse(Console.ReadLine());
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
                    }
                    catch
                    {
                        error = true;
                        Console.WriteLine("\n \t ** Carácter no permitido ");
                    }

                } while (error);
                          
                Console.Write("\n \t modificar más aulas (S/N):  ");
                mod = Console.ReadLine().ToUpper();

                while (mod != "S" && mod != "N" && mod != "s" && mod != "n")
                {
                    Console.Write("\n \t ERROR\n");

                    Console.Write("\n \t ¿modificar más aulas (S/N)?:  ");
                    mod = Console.ReadLine().ToUpper();
                }

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
                        b.verdatos_pc();//Lista de ordenadores
                        break;

                    case "2":
                        anadir_ordenadores();//Añadir ordenador
                        break;

                    case "3":
                        borrar_ordenador();///Borrar ordenador
                        break;

                    case "4":
                        cambiar_ubicacion_ordenador();//Cambiar ordenador de aula
                        break;

                    case "5":
                        modificar_ordenador();//Modificar ordenador
                        break;
                }

            } while (menu_ordenador != "0");
        }


        static void anadir_ordenadores()
        {
            string anadir;
            string id_pc = "";
            int id_aula = 0;
            string ram= "", disco_duro= "", procesador= "", hd="", app="";
            Aula aula = new Aula();
            bool error = false;
        
            do
            {
                do
                {
                    try
                    {
                        error = false;
                        Console.Clear();

                        if (lis_ordenadores.Count == available_pc)
                        {
                            Console.WriteLine("\n \t ***Has superado el limite de ordenadores registradas, por favor borre algún ordenador***");

                            Console.Write("\n \t PULSE INTRO PARA SALIR");
                            Console.ReadLine();
                            return;
                        }
                    
                        else
                        {

                            Console.WriteLine("\n \t === Añadir Ordenador === \n");


                            if (lis_aulas.Count == 0)
                            {
                                Console.WriteLine("\n \t  *** No existen Aulas por favor cree algún Aula ***");
                                Console.ReadLine();
                                return;
                            }

                            /////// ID ORDENADOR //////

                            Console.Write("\t Identificador ordenador (0 ver lista de ordenadores):  ");
                            id_pc = Console.ReadLine();

                            while (id_pc == "")
                            {
                                Console.Write("\n \t No puedes dejar este campo vacio \n");

                                Console.Write("\t Identificador ordenador (0 ver lista de ordenadores):  ");
                                id_pc = Console.ReadLine();
                            }


                            while (existe_ordenador(id_pc) && id_pc != "0")
                            {
                                Console.Write("\n \t Esta ID ya existe");

                                Console.Write("\n \t Identificador ordenador (0 ver lista de ordenadores):  ");
                                id_pc = Console.ReadLine();
                            }

                            if (id_pc == "0")//Controlar q si pulsa 0 ver lista
                            {
                                b.verdatos_pc();
                                return;
                            }                                                                           

                            while (id_pc.Length > 20)
                            {
                                Console.WriteLine("\n \t El id que has introducido es superior a 20 carácteres ");
                                Console.Write("\n \t Vuelve a introducir id:  ");
                                id_pc = Console.ReadLine();
                            }


                            /////// ID AULAS//////

                            Console.Write("\n \t Id. Aula en la que se encuentra (0 ver lista aulas): ");
                            id_aula = int.Parse(Console.ReadLine());

                            while (!existe_aula(id_aula) && id_aula != 0)
                            {
                                Console.Write("\n \t Esta ID no existe");

                                Console.Write("\n \t Id. Aula en la que se encuentra (0 ver lista aulas): ");
                                id_aula = int.Parse(Console.ReadLine());

                            }

                            if (id_aula == 0)
                            {
                                a.verdatos();
                                return;
                            }

                            if (id_aula < 0)
                            {
                                Console.Write("\n \t *** No se aceptan números negativos *** \n ");

                                Console.Write("\n \t Id. Aula en la que se encuentra (0 ver lista aulas): ");
                                id_aula = int.Parse(Console.ReadLine());

                            }
                      
                            for (int i = 0; i < lis_aulas.Count; i++)
                            {
                                if (lis_aulas[i].Id == id_aula) // obtenemos el aula indicada
                                {
                                    aula = lis_aulas[i];
                                }
                            }
                         
                            Console.WriteLine("\n \t Introduzca las características del <{0}>", id_pc);

                            Console.Write("\n \t RAM:  ");
                            ram = Console.ReadLine();

                            Console.Write("\n \t Disco duro:  ");
                            disco_duro = Console.ReadLine();

                            Console.Write("\n \t Procesador:  ");
                            procesador = Console.ReadLine();

                            Console.Write("\n \t Tarjeta Gráfica:  ");
                            hd = Console.ReadLine();

                            Console.Write("\n \t Introduzca las aplicaciones separadas por comas del <{0}>:  ", id_pc);
                            app = Console.ReadLine();

                            Console.WriteLine("\n \t ...... Ordenadores añadidos correctamente.");
                        }

                        b = new Ordenador(id_pc, aula, ram, disco_duro, hd, procesador, app);
                        lis_ordenadores.Add(b);
                        aula.ordenador_lista.Add(b); //Añadimos el ordenador a la lista del aula.
                    }
                    catch
                    {
                        error = true;
                        Console.WriteLine("\n \t ** Carácter no permitido ");
                        Console.ReadLine();
                    }

                } while (error);

                Console.Write("\n \t ¿más ordenadores? (S/N):  ");
                anadir = Console.ReadLine().ToUpper();

                while (anadir != "S" && anadir != "N" && anadir != "s" && anadir != "n")
                {
                    Console.Write("\n \t ERROR\n");

                    Console.Write("\n \t ¿añadir más ordenadores (S/N)?:  ");
                    anadir = Console.ReadLine().ToUpper();
                }

            } while (anadir == "S");
        }

        static void borrar_ordenador()
        {
            string borrar;
            string id_ordenador;
            do
            {
                Console.Clear();
                Console.WriteLine("\n \t === Borrar Ordenadores ===");

                if (lis_ordenadores.Count == 0)
                {
                    Console.WriteLine("\n \t La lista de Ordenadores está vacía ");
                    Console.WriteLine("\n \t Pulse intro para salir");
                    Console.ReadLine();
                    return;
                }

                Console.Write("\n \t Identificador de ordenador (0 ver lista de ordenadores):  ");
                id_ordenador = Console.ReadLine();

                if (id_ordenador == "0")
                {
                    b.verdatos_pc();
                    return;//volvemo menu
                }

                for (int a = 0; a < lis_ordenadores.Count; a++)
                {
                    while (lis_ordenadores[a].ID != id_ordenador)
                    {
                        Console.Write("\n \t Introduce un ID de ordenador existente");

                        Console.Write("\n \t Identificador de ordenador (0 ver lista de ordenadores):  ");
                        id_ordenador = Console.ReadLine();

                        if (id_ordenador == "0")
                        {
                            b.verdatos_pc();
                            return;//volvemo menu
                        }
                    }
                }


                for (int i = 0; i < lis_ordenadores.Count; i++)
                {
                    if (lis_ordenadores[i].ID == id_ordenador)
                    {
                        string opcion;

                        Console.WriteLine("\n \t Se procedera a borrar el ordenador <{0}> situado en el aula <{1}>:", lis_ordenadores[i].ID, lis_aulas[i].Nombre);

                        Console.Write("\n \t ¿desea continuar borrando? (S/N): ");
                        opcion = Console.ReadLine().ToUpper();

                        if (opcion == "S")
                        {
                            lis_ordenadores[i].Aula.ordenador_lista.Remove(lis_ordenadores[i]);//borramos el ordenador en la lista en la que se encuentra.
                            lis_ordenadores.Remove(lis_ordenadores[i]);//borra todo del ordenador.
                             
                        }
                        if (opcion == "N")
                        {
                            Console.Write("\n \t ..... No se borro el ordenador");
                            Console.ReadLine();
                        }
                    }
                }

                Console.Write("\n \t ¿borrar más? (S/N):  ");
                borrar = Console.ReadLine().ToUpper();

                while (borrar != "S" && borrar != "N" && borrar != "s" && borrar != "n")
                {
                    Console.Write("\n \t ERROR\n");

                    Console.Write("\n \t ¿borrar más aulas (S/N)?:  ");
                    borrar = Console.ReadLine().ToUpper();
                }

            } while (borrar == "S");
        }
        static void cambiar_ubicacion_ordenador()
        {
            string cambio;
            string id_ordenador;
            int id_aula;
            Aula nueva_aula = new Aula();
            Ordenador ordenador = new Ordenador();
            bool error = false;
            do
            {
                do
                {
                    try
                    {
                        error = false;
                        Console.Clear();

                        Console.WriteLine("\n \t === Cambiar ubicación del ordenador ===");

                        if (lis_ordenadores.Count == 0)
                        {
                            Console.WriteLine("\n \t La lista de Ordenadores está vacía ");
                            Console.WriteLine("\n \t Pulse intro para salir");
                            Console.ReadLine();
                            return;
                        }

                        Console.Write("\n \t Identificador del ordenador (0 ver lista de ordenador):  ");
                        id_ordenador = Console.ReadLine();

                        while (!existe_ordenador(id_ordenador) && id_ordenador != "0")
                        {
                            Console.Write("\n \t Esta ID no existe");

                            Console.Write("\n \t Identificador ordenador (0 ver lista de ordenadores):  ");
                            id_ordenador = Console.ReadLine();
                        }

                        if (id_ordenador == "0")
                        {
                            b.verdatos_pc();
                            return;
                        }

                        for (int i = 0; i < lis_ordenadores.Count; i++)
                        {
                            if (lis_ordenadores[i].ID == id_ordenador)
                            {
                                Console.WriteLine("\n \t Seleccionado <{0}> situado en <{1}>", lis_ordenadores[i].ID, lis_ordenadores[i].Aula.Nombre);//cambiar <>

                                ordenador = lis_ordenadores[i]; // Guardamos un ordenador


                                Console.Write("\n \t Situe un nuevo ID de aula para ubicación (0 lista de aulas): ");
                                id_aula = int.Parse(Console.ReadLine());


                                for (int a = 0; a < lis_aulas.Count; a++)
                                {
                                    if (lis_aulas[a].Id != id_aula && id_aula != 0)
                                    {
                                        Console.Write("\n \t El ID introducido no existe");

                                        Console.Write("\n \t Situe un nuevo ID de aula para ubicación (0 lista de aulas): ");
                                        id_aula = int.Parse(Console.ReadLine());
                                    }

                                    if (lis_aulas[a].Id == id_aula)
                                    {
                                        nueva_aula = lis_aulas[a];// Guardamos un aula 
                                    }
                                }

                                if (id_aula == 0)
                                {
                                    a.verdatos();
                                    return;
                                }

                                //El ordenador 5 esta en aula 5 "Aula 5 tiene una lista de ordenadores donde esta el oredandor 5"

                                ordenador.Aula.ordenador_lista.Remove(ordenador);//Borramos de la lista de ordenadores del aula el ordenador.

                                ordenador.Aula = nueva_aula;// Cambia el aula actual por el nuevo aula.

                                nueva_aula.ordenador_lista.Add(ordenador);// Añadimos a la lista de ordenadores del nuevo aula el ordenador.

                                Console.WriteLine("\n \t ...... El ordenador |{0}| se movio correctamente al <{1}>", lis_ordenadores[i].ID, nueva_aula.Nombre);
                            }
                        }
                    }
                    catch
                    {
                        error = true;
                        Console.Write("\n \t *** Error carácter no permitido *** ");
                    }

                } while (error);
                
                Console.Write("\n \t ¿mover más? (S/N):  ");
                cambio = Console.ReadLine().ToUpper();

                while (cambio != "S" && cambio != "N" && cambio != "s" && cambio != "n")
                {
                    Console.Write("\n \t ERROR\n");

                    Console.Write("\n \t ¿cambiar más ordenadores (S/N)?:  ");
                    cambio = Console.ReadLine().ToUpper();
                }

            } while (cambio == "S");
        }
        static void modificar_ordenador()
        {
            string mod;
            string mod2;
            string id_pc;
            string nuevo_id;
            do
            {
                Console.Clear();

                if (lis_ordenadores.Count == 0)
                {
                    Console.Write("\n \t La lista de Ordenadores está vacía \n");
                    Console.Write("\n \t Pulse intro para salir");
                    Console.ReadLine();
                    return;
                }

                Console.Write("\n \t === Modificar ordenador ===\n");

                    Console.Write("\n \t Identificador de ordenador (0 ver lista ordenador):  ");
                    id_pc = Console.ReadLine();

                if (id_pc == "0")
                {
                    b.verdatos_pc();
                    return;
                }
               
                for (int i = 0; i < lis_ordenadores.Count; i++)
                    {
                        if (lis_ordenadores[i].ID != id_pc)
                        {
                        Console.Write("\n \t ID no disponible mire bien la lista de ordenadores");
                        Console.ReadLine();

                        Console.Clear();

                        b.verdatos_pc();
                        return;

                        }
                        if (lis_ordenadores[i].ID == id_pc)
                        {
                            Console.Write("\n \t ¿Desea modificar su identificador (S/N):  ");
                            mod = Console.ReadLine().ToUpper();

                        if (mod == "S")
                        {
                            Console.Write("\n \t Escribe el nuevo identificador:  ");
                            nuevo_id = Console.ReadLine();

                            lis_ordenadores[i].ID = nuevo_id;

                            Console.Write("\n \t Tu id de ordenador fue modificado \n ");
                        }

                        Console.Write("\n \t El ordenador se encuentra en el aula con ID <{0}> \n ", lis_aulas[i].Id);// cambiar <>

                        Console.Write("\n \t Modifique las características del <{0}> (en blanco se mantienen) \n ", lis_ordenadores[i].ID);//cambiar <>

                        Console.Write("\n \t RAM <{0}>: ", lis_ordenadores[i].RAM);
                        lis_ordenadores[i].RAM = Console.ReadLine();

                        Console.Write("\n \t Disco duro <{0}>: ", lis_ordenadores[i].Disco_duro);
                        lis_ordenadores[i].Disco_duro = Console.ReadLine();

                        Console.Write("\n \t Procesador <{0}>: ", lis_ordenadores[i].Procesador);
                        lis_ordenadores[i].Procesador = Console.ReadLine();

                        Console.Write("\n \t Tarjeta gráfica <{0}>: ",lis_ordenadores[i].T_video);
                        lis_ordenadores[i].T_video = Console.ReadLine();

                        Console.Write("\n \t Modifique las aplicaciones (separadas por comas) del <{0}> (en blanco se mantienen) <{1}>:  ", lis_ordenadores[i].ID, lis_ordenadores[i].Aplicaciones);//cambiar <> <>
                        lis_ordenadores[i].Aplicaciones = Console.ReadLine();


                        Console.Write("\n \t ......Ordenador modificado con éxito");

                    }
                    }

                Console.Write("\n \t ¿más ordenadores? (S/N):  ");
                mod2 = Console.ReadLine().ToUpper();

                while (mod2 != "S" && mod2 != "N" && mod2 != "s" && mod2 != "n")
                {
                    Console.Write("\n \t ERROR\n");

                    Console.Write("\n \t ¿modificar más ordenadores (S/N)?:  ");
                    mod2 = Console.ReadLine().ToUpper();
                }

            } while (mod2 == "S");

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
                        lista_aulas_ordenadas();//Lista ordenada por nombre
                        break;

                    case "2":
                        ordenadores_ordenados();//Lista ordenada por id y nombre
                        break;

                    case "3":
                        aplicaciones_instaladas(); //Aplicaciones instaladas por ordenador
                        break;

                    case "4":
                        b.lista_ordenador();//Características del ordenador
                        break;
                }
            } while (menu_lista != "0");
        }

        static void lista_aulas_ordenadas()
        {
            Console.Clear();

            if(lis_aulas.Count == 0)
            {
                Console.WriteLine("\n \t La lista de aulas esta vacia (Pulse alguna letra para volver) ");
                Console.ReadLine();
            }
            else
            {
                List<Aula> sorted = lis_aulas.OrderBy(Aula => Aula.Nombre).ToList();

                Console.Write("\n \t === LISTADO DE AULAS ORDENADAS === \n");

                Console.WriteLine("\n \t ID.\t\t Nombre \t \t  Nº Ordenadores");
                Console.WriteLine("\n \t ======= \t ============ \t \t ===============");

                foreach (Aula var in sorted)
                {
                    Console.WriteLine("\n \t {0} \t \t {1} \t \t \t {2}", var.Id, var.Nombre, var.ordenador_lista.Count);
                }
                Console.WriteLine("\n ========================================================================================================\n");

                Console.WriteLine("\t Nº de Aulas: {0} ", lis_aulas.Count);

                Console.WriteLine("\n \t Pulse INTRO para volver");
                Console.ReadLine();
            }
        }

        static void ordenadores_ordenados()
        {
            Console.Clear();

            if (lis_aulas.Count == 0)
            {
                Console.WriteLine("\n \t La lista de aulas esta vacia (Pulse alguna letra para volver) ");
                Console.ReadLine();
            }
            else if (lis_ordenadores.Count == 0)
            {
                Console.WriteLine("\n \t La lista de ordenadores esta vacia (Pulse alguna letra para volver) ");
                Console.ReadLine();
            }           
            else
            {
                List<Ordenador> sorted = lis_ordenadores.OrderBy(Ordenador => Ordenador.Aula.Nombre).ThenBy(Ordenador => Ordenador.ID).ToList();
               
                Console.Write("\n \t === Listado de ordenadores ordenados por aulas e identf \n");

                Console.WriteLine("\n \t ID.\t\t Aula \t \t \t Aplicaciones");
                Console.WriteLine("\n \t ======= \t ============ \t \t ===============");

                foreach (Ordenador var in sorted)
                {
                    if (var.Aplicaciones.Length < 30)
                    {
                        Console.WriteLine("\n \t {0} \t \t {1} \t \t \t {2}", var.ID, var.Aula.Nombre, var.Aplicaciones);
                    }
                    else
                    {
                        Console.WriteLine("\n \t {0} \t \t {1} \t \t \t {2}", var.ID, var.Aula.Nombre, var.Aplicaciones.Substring(0, 30));
                    }
                               
                }

                Console.WriteLine("\n ========================================================================================================\n");

                Console.WriteLine("\t Nº de Ordenadores: {0} ", lis_ordenadores.Count);

                Console.WriteLine("\n \t Pulse INTRO para volver");
                Console.ReadLine();
            }
            
        }
        static void aplicaciones_instaladas()
        {
            Console.Clear();

            if (lis_ordenadores.Count == 0)
            {
                Console.WriteLine("\n \t La lista de ordenadores esta vacia (Pulse alguna letra para volver) ");
                Console.ReadLine();
            }
            else
            {
                List<Ordenador> sorted = lis_ordenadores.OrderBy(Ordenador => Ordenador.ID).ToList();

                Console.Write("\n \t === Aplicaciones instaladas por ordenador === \n");

                Console.WriteLine("\n \t ID.\t\t\t Aplicaciones");
                Console.WriteLine("\n \t ======= \t =============================");

                foreach (Ordenador pc in sorted)
                {
                    Console.Write("\n \t {0}", pc.ID + "\t\t");

                    if (pc.Aplicaciones.Length > 50)
                    {
                        for (int i = 0; i < 50; i++)
                        {
                            Console.Write(pc.Aplicaciones[i]);
                        }
                        Console.Write("\n \t\t\t");
                        for (int i = 49; i < pc.Aplicaciones.Length; i++)
                        {
                            Console.Write(pc.Aplicaciones[i]);
                        }
                    }
                    else
                    {
                        Console.Write(pc.Aplicaciones);
                    }                                                          
                }
                Console.WriteLine("\n ========================================================================================================\n");

                Console.WriteLine("\t Nº de Ordenadores: {0} ", lis_ordenadores.Count);

                Console.WriteLine("\n \t Pulse INTRO para volver");
                Console.ReadLine();
            }         
        }
       /* static void caracteris_pc()
        {
            Console.Clear();


            if (lis_ordenadores.Count == 0)
            {
                Console.WriteLine("\n \t La lista de ordenadores esta vacia (Pulse alguna letra para volver) ");
                Console.ReadLine();
            }
            else
            {
                List<Ordenador> sorted = lis_ordenadores.OrderBy(Ordenador => Ordenador.ID).ToList();

                Console.Write("\n \t === Características por ordenador === \n");

                Console.Write("\n \t ID.\t RAM \t\t Disco.D \t\t T.Gráf\t\t Proces\t\t Alta/Mod.");

                Console.WriteLine("\n \t ======\t========\t========\t==========\t======\t=========");

                foreach (Ordenador pc in sorted)
                {
                    Console.WriteLine("\n \t {0} \t {1}\t {2}\t {3}\t {4}\t", pc.ID, pc.RAM, pc.Disco_duro, pc.T_video, pc.Procesador);
                }
                Console.WriteLine("\n ========================================================================================================\n");

                Console.WriteLine("\t Nº de Ordenadores: {0} ", lis_ordenadores.Count);

                Console.WriteLine("\n \t Pulse INTRO para volver");
                Console.ReadLine();
            }

        }*/
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
                        maximo_aulas();//Máximo aulas
                        break;

                    case "2":
                        maximo_ordenador();//Máximo ordenadores
                        break;

                    case "9":
                        prueba_automatica();//Pruebas automáticas
                        break;
                }
            } while (menu_config != "0");
        }

        static void maximo_aulas()
        {
           
            string maximo;

            int maximoaula;

            do
            {
                Console.Clear();
                Console.Write("\n \t === Cambiar máximo de aulas ===\n");

                Console.Write("\n \t Introduce nuevo máximo de aulas: ");
                 maximoaula = int.Parse(Console.ReadLine());

                while(maximoaula <= available_aula)
                {
                    Console.Write("\n \t No se puede cambiar a ese número ya sea porque es menor o igual a 5(predeterminado) ");

                    Console.Write("\n \t Introduce nuevo máximo de aulas: ");
                    maximoaula = int.Parse(Console.ReadLine());
                }

                available_aula = maximoaula;
               
                Console.Write("\n \t Desea volver a cambiar máximo (S/N):  ");
                maximo = Console.ReadLine().ToUpper();

                while (maximo != "S" && maximo != "N" && maximo != "s" && maximo != "n")
                {
                    Console.Write("\n \t ERROR\n");

                    Console.Write("\n \t Desea volver a cambiar máximo (S/N):  ");
                    maximo = Console.ReadLine().ToUpper();
                }

            } while (maximo == "S");
        }

        static void maximo_ordenador()
        {
            string maximo;
            int maximo_orde;
            do
            {
                Console.Clear();

                Console.Write("\n \t === Cambiar máximo de ordenadores ===\n");

                Console.Write("\n \t Introduce nuevo máximo de ordenadores: ");
                maximo_orde = int.Parse(Console.ReadLine());

                while (maximo_orde <= available_pc)
                {
                    Console.Write("\n \t No se puede cambiar a ese número ya sea porque es menor o igual a 15(predeterminado) ");

                    Console.Write("\n \t Introduce nuevo máximo de aulas: ");
                    maximo_orde = int.Parse(Console.ReadLine());
                }
                available_pc = maximo_orde;

                Console.Write("\n \t Desea volver a cambiar máximo (S/N):  ");
                maximo = Console.ReadLine().ToUpper();

                while (maximo != "S" && maximo != "N" && maximo != "s" && maximo != "n")
                {
                    Console.Write("\n \t ERROR\n");

                    Console.Write("\n \t Desea volver a cambiar máximo (S/N):  ");
                    maximo = Console.ReadLine().ToUpper();
                }

            } while (maximo == "S");

        }
        static void prueba_automatica()
        {
            lis_aulas.Clear();
            lis_ordenadores.Clear();

            Console.Clear();

            for ( int i = 1; i <= 5; i++)
            {
                a = new Aula(i, "Aula" + i);
                lis_aulas.Add(a);
            }
            for (int o = 1; o <= 2; o++)
            {
                b = new Ordenador("PC0" + o, lis_aulas[o - 1], "8,00 GB", "350,00 GB", "Intel i5", "AMD R7 370", "Win 7, Office 2010, Chrome");
                lis_aulas[o - 1].ordenador_lista.Add(b);
                lis_ordenadores.Add(b);

            }
            for (int i = 3; i <= 4; i++)
            {
                b = new Ordenador("PC0" + i, lis_aulas[i], "8,00 GB", "480,00 GB", "Intel i5", "GTX 1080", "Win 7, Office 2010, Chrome");
                lis_aulas[i].ordenador_lista.Add(b);
                lis_ordenadores.Add(b);
            }
            for (int i = 5; i <= 8; i++)
            {
                b = new Ordenador("PC0" + i, lis_aulas[2], "4,00 GB", "150,00 GB", "Intel Celeron", "GeForce GTX Titan X PASCAL", "Ubuntu 14, Gedit, LibreOffice 5");
                lis_aulas[2].ordenador_lista.Add(b);
                lis_ordenadores.Add(b);
            }


            Console.WriteLine("\n \t Modo de depuración automática listo");
            Console.WriteLine("\n \t Pulse INTRO para volver ");
            Console.ReadLine();
        }
       
        ///////MÉTODOS////////
        static bool existe_aula(int id_aula)
        {
            bool existe = false;

            for (int i = 0; i < lis_aulas.Count; i++)
            {
                if (lis_aulas[i].Id == id_aula)
                {
                    existe = true;
                }
            }
            return existe;
        }

        static bool existe_ordenador(string id_pc)
        {
            bool existe = false;

            for (int i = 0; i < lis_ordenadores.Count; i++)
            {
                if (lis_ordenadores[i].ID == id_pc)
                {
                    existe = true;
                }
            }
            return existe;
        }

    }
}

