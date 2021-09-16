using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class StockItemClient : ResourceClient<StockItemWrapper, StockItemsWrapper, StockItem>
    {
        public StockItemClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "stock_items";

        public override StockItemWrapper WrapperFromSingle(StockItem single)
        {
            return new StockItemWrapper { stock_item = single };
        }

        public override List<StockItem> ListFromWrapper(StockItemsWrapper wrapper)
        {
            return wrapper.stock_items;
        }

        public override StockItem SingleFromWrapper(StockItemWrapper wrapper)
        {
            return wrapper.stock_item;
        }
    }
}

