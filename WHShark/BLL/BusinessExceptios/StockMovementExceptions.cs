using System;

namespace Services.BLL
{
    /// <summary>
    /// Exceptions related to stock movement operations.
    /// </summary>
    public class StockMovementNotFoundException : BusinessException
    {
        public StockMovementNotFoundException()
            : base("Stock movement not found")
        {
        }

        public StockMovementNotFoundException(string message)
            : base(message)
        {
        }

        public StockMovementNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class InvalidStockMovementStateException : BusinessException
    {
        public InvalidStockMovementStateException()
            : base("Invalid stock movement state for this operation")
        {
        }

        public InvalidStockMovementStateException(string message)
            : base(message)
        {
        }

        public InvalidStockMovementStateException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class StockMovementProcessingException : BusinessException
    {
        public StockMovementProcessingException()
            : base("An error occurred while processing the stock movement")
        {
        }

        public StockMovementProcessingException(string message)
            : base(message)
        {
        }

        public StockMovementProcessingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
