using System;

namespace Services.BLL
{
    /// <summary>
    /// Excepciones relacionadas con usuarios del dominio.
    /// </summary>
    public class UsuarioInexistenteException : BusinessException
    {
        /// <summary>
        /// Crea una nueva instancia indicando que el usuario solicitado no existe.
        /// </summary>
        public UsuarioInexistenteException()
            : base("Usuario inexistente")
        {
        }

        /// <summary>
        /// Crea una nueva instancia con un mensaje descriptivo del error.
        /// </summary>
        public UsuarioInexistenteException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Crea una nueva instancia incluyendo la excepción interna que originó el error.
        /// </summary>
        public UsuarioInexistenteException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class PasswordIncorrectaException : BusinessException
    {
        public PasswordIncorrectaException()
            : base("Password incorrecta")
        {
        }

        public PasswordIncorrectaException(string message)
            : base(message)
        {
        }

        public PasswordIncorrectaException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class UsuarioBloqueadoException : BusinessException
    {
        public UsuarioBloqueadoException()
            : base("Usuario bloqueado")
        {
        }

        public UsuarioBloqueadoException(string message)
            : base(message)
        {
        }

        public UsuarioBloqueadoException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class UsuarioInactivoException : BusinessException
    {
        public UsuarioInactivoException()
            : base("Usuario inactivo")
        {
        }

        public UsuarioInactivoException(string message)
            : base(message)
        {
        }

        public UsuarioInactivoException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
