using System;

namespace StoreAppWeb.Domain.Model.Exceptions
{
    public class TooManyItemsToRemoveException: Exception
    {

        public StockItem ExistingStockItem { get; private set; }
        public int QtyToTake { get; private set; }       

        public TooManyItemsToRemoveException(string message, StockItem existingItem, int qtyToTake) : base(message)
        {
            ExistingStockItem = existingItem;
            QtyToTake = qtyToTake;
        }
    }
}
