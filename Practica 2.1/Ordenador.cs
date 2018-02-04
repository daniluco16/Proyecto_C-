using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2._1
{
    class Ordenador
    {
        string id,ram, disco_duro, t_video, procesador, aplicaciones;
        Aula aula;

        public Ordenador(string UnId, string UnaRam, string UnDiscoDuro, string UnaT_video, string UnProcesador, string UnaAplicacion)
        {
            this.id = UnId;
            this.ram = UnaRam;
            this.disco_duro = UnDiscoDuro;
            this.t_video = UnaT_video;
            this.procesador = UnProcesador;
            this.aplicaciones = UnaAplicacion;
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
                ram = value;
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
                disco_duro = value;
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
                t_video = value;
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
                procesador = value;
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
                aplicaciones = value;
            }
        }
    }
}
