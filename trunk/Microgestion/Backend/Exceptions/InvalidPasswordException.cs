using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackspot.Microgestion.Backend.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
            : base("La contraseña ingresada es incorrecta.") { }

        public InvalidPasswordException(Exception innerException)
            : base("La contraseña ingresada es incorrecta.", innerException) { }
    }
}
