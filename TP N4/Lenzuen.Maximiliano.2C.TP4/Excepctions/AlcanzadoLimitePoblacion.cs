using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepctions 
{
    public class AlcanzadoLimitePoblacion : Exception
    {
        public AlcanzadoLimitePoblacion() : base("Alcanzado el limite de poblacion")
        {

        }
    }
}
