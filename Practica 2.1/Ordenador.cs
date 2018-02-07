using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2_Evaluación
{
    class Ordenador
    {
        string id,ram, disco_duro, t_video, procesador, aplicaciones;
        Aula aula;
        DateTime fecha = DateTime.Now;

        public Ordenador()
        {

        }
        public Ordenador(string UnId,Aula aula, string UnaRam, string UnDiscoDuro, string UnaT_video, string UnProcesador, string UnaAplicacion)
        {
            this.id = UnId;
            this.ram = UnaRam;
            this.disco_duro = UnDiscoDuro;
            this.t_video = UnaT_video;
            this.procesador = UnProcesador;
            this.aplicaciones = UnaAplicacion;
            this.aula = aula;
            this.fecha = DateTime.Now;
        }

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                fecha = DateTime.Now;
            }
        }
        public Aula Aula
        {
            get
            {
                return aula;
            }
            set
            {
                aula = value;
            }
        }
        public string nombreaula
        {
            get
            {
                return aula.Nombre;
            }
        }

        public string RAM
        {
            get
            {
                return ram;
            }
            set
            {

                if (value != "")
                {
                    ram = value;
                }
            }
        }
        public string Disco_duro
        {
            get
            {
                return disco_duro;
            }
            set
            {

                if (value != "")
                {
                    disco_duro = value;
                }
            }
        }
        public string T_video
        {
            get
            {
                return t_video;
            }
            set
            {

                if (value != "")
                {
                    t_video = value;
                }
            }
        }
        public string Procesador
        {
            get
            {
                return procesador;
            }
            set
            {

                if (value != "")
                {
                    procesador = value;
                }
            }
        }
        public string Aplicaciones
        {
            get
            {
                return aplicaciones;
            }
            set
            {

                if (value != "")
                {
                    aplicaciones = value;
                }
            }
        }

        public void verdatos_pc()
        {
            Console.Clear();

            if (Program.lis_ordenadores.Count == 0)
            {
                Console.WriteLine("\n \t La lista de aulas esta vacia (Pulse alguna letra para volver) ");
                Console.ReadLine();
            }
            else
            {
                List<Ordenador> sorted = Program.lis_ordenadores.OrderBy(Ordenador => Ordenador.id).ToList();

                Console.WriteLine("\n \t === Listado de ordenadores === \n ");

                Console.WriteLine("\t Id \t \t Aula \t \t \t F.Creación");

                Console.WriteLine("\n =========== \t ======================== \t =========================================");

                foreach (Ordenador pc in sorted)
                {
                    Console.WriteLine("\n \t {0} \t \t {1} \t \t \t {2}", pc.id, pc.nombreaula, pc.fecha);
                }

                Console.WriteLine("\n ========================================================================================\n");
                Console.WriteLine("\t Nº de Ordenadores: {0}", Program.lis_ordenadores.Count);
                Console.Write("\n \t Pulse INTRO para volver");
                Console.ReadLine();
            }
        }
    }
}
