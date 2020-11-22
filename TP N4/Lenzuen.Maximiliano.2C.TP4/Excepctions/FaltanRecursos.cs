using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepctions
{
    public class FaltanRecursos : Exception
    {
        public FaltanRecursos() : base("No posee recursos para comprar la unidad")
        {

        }
    }
}
