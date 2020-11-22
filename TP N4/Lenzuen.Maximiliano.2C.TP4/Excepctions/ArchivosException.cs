using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepctions
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException) : base("ARCHIVO FAIL", innerException)
        {

        }
    }
}
