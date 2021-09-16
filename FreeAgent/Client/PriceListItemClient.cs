using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class PriceListItemClient : ResourceClient<PriceListItemWrapper, PriceListItemsWrapper, PriceListItem>
    {
        public PriceListItemClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "price_list_items";

        public override PriceListItemWrapper WrapperFromSingle(PriceListItem single)
        {
            return new PriceListItemWrapper { price_list_item = single };
        }

        public override List<PriceListItem> ListFromWrapper(PriceListItemsWrapper wrapper)
        {
            return wrapper.price_list_items;
        }

        public override PriceListItem SingleFromWrapper(PriceListItemWrapper wrapper)
        {
            return wrapper.price_list_item;
        }
    }
}

