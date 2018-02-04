using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2._1
{
    class Aula
    {
        int id;
        string nombre;

        public Aula(int unId, string unNombre)
        {
            this.id = unId;
            this.nombre = unNombre;
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
            }
        }
    }
}
