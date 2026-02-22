using System;

namespace Services.BLL
{
    public class DuplicatePurchaseItemException : BusinessException
    {
        public DuplicatePurchaseItemException()
            : base("Duplicate product found in purchase items")
        {
        }

        public DuplicatePurchaseItemException(string message)
            : base(message)
        {
        }

        public DuplicatePurchaseItemException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
