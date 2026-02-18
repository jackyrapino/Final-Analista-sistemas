using System;

namespace Services.BLL
{
    /// <summary>
    /// Exceptions related to sales operations.
    /// </summary>
    public class SaleNotFoundException : BusinessException
    {
        /// <summary>
        /// Creates a new instance indicating the requested sale was not found.
        /// </summary>
        public SaleNotFoundException()
            : base("Sale not found")
        {
        }

        /// <summary>
        /// Creates a new instance with a descriptive message.
        /// </summary>
        public SaleNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance including the inner exception that caused the error.
        /// </summary>
        public SaleNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class SaleProcessingException : BusinessException
    {
        public SaleProcessingException()
            : base("An error occurred while processing the sale")
        {
        }

        public SaleProcessingException(string message)
            : base(message)
        {
        }

        public SaleProcessingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
