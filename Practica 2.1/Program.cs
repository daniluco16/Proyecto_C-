using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2_Evaluación
{
    class Program
    {
         /*********************************
         Autor: Daniel de la Rosa Romero
         Fecha creación: 02/02/2018
         Última modificación: dd/mm/aaaa
         Versión: x.xx
        ***********************************/
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
                Console.WriteLine("hola");

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
                    Console.Write("\n \t **ERROR** Vuelve ha elegir una opción correcta:  ");
                    menu_aula = Console.ReadLine();
                }
                switch (menu_aula)
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
            } while (menu_aula != "0");
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

