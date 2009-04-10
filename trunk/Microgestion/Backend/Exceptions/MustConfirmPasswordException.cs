using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackspot.Microgestion.Backend.Exceptions
{
    public class MustConfirmPasswordException : Exception
    {
        public MustConfirmPasswordException()
            : base("Debe confirmar la contraseña.") { }

        public MustConfirmPasswordException(Exception innerException)
            : base("Debe confirmar la contraseña.", innerException) { }
    }
}
