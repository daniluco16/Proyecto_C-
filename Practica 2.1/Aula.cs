using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2_Evaluación
{
    class Aula
    {
        List<Ordenador> list_ordenador = new List<Ordenador>();

        int id;
        string nombre;
        DateTime fecha = DateTime.Now;

        public Aula() // Constructor por defecto 
        {
            
        }

        public Aula(int unId, string unNombre)//Leer datos
        {
            list_ordenador = new List<Ordenador>();
            this.id = unId;
            this.nombre = unNombre;
            this.fecha = DateTime.Now;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
       
            }
            
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                fecha = DateTime.Now;
            }
        }

        public List<Ordenador> ordenador_lista
        {
            get
            {
                return list_ordenador;
            }
        }

        public void verdatos()
        {
            Console.Clear();
            if (Program.lis_aulas.Count == 0)
            {
                Console.WriteLine("\n \t La lista de aulas esta vacia (Pulse alguna letra para volver) ");
                Console.ReadLine();
            }
            else
            {
                List<Aula> sorted = Program.lis_aulas.OrderBy(Aula => Aula.id).ToList();

                Console.WriteLine("\n \t \t  === Listado de aulas ===");

                Console.WriteLine("\n \t ID.\t\t Nombre \t \t  Nº Ordenadores \t  Fecha y hora de modificación ");
                Console.WriteLine("\n \t ======= \t ============ \t \t ============== \t ============================ ");

                foreach (Aula clase in sorted)
                {
                    Console.WriteLine("\n \t {0} \t \t {1} \t \t \t {2} \t \t \t{3}", clase.id, clase.nombre, clase.ordenador_lista.Count, clase.fecha);
                }

                Console.WriteLine("\n ========================================================================================================\n");
                Console.WriteLine("\t Nº de Aulas: {0} ", Program.lis_aulas.Count);
                Console.WriteLine("\n \t Nº de Ordenadores: {0}", Program.lis_ordenadores.Count);

                Console.WriteLine("\n \t Pulse INTRO para volver");
                Console.ReadLine();
            }
        }
    }
}