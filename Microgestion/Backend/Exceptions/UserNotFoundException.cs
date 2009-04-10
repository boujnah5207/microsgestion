using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysQ.Microgestion.Backend.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
            : base("No se encontró el usuario.") { }

        public UserNotFoundException(Exception innerException)
            : base("No se encontró el usuario.", innerException) { }
    }
}
