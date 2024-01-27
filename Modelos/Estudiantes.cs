using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kpullopaxiS67.modelos
{
   public  class Estudiantes
    {
        public int codigo { set; get; }
        public required string nombre { set; get; }
        public required string apellido { set; get; }
        public int edad { set; get; }
    }
}
