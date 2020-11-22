using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepctions
{
    public class NoExisteEnDB : Exception
    {
        public NoExisteEnDB() : base("No existe el item buscado en nuestra base de datos")
        {

        }
    }
}
