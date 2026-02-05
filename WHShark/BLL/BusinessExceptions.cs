using System;

namespace Services.BLL
{
    // Base business exception
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
        public BusinessException(string message, Exception inner) : base(message, inner) { }
    }

    public class UsuarioInexistenteException : BusinessException
    {
        public UsuarioInexistenteException(string message = "Usuario inexistente") : base(message) { }
    }

    public class PasswordIncorrectaException : BusinessException
    {
        public PasswordIncorrectaException(string message = "Password incorrecta") : base(message) { }
    }

    public class UsuarioBloqueadoException : BusinessException
    {
        public UsuarioBloqueadoException(string message = "Usuario bloqueado") : base(message) { }
    }
}
