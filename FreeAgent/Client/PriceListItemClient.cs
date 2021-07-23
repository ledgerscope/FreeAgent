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
            return new PriceListItemWrapper { priceListItem = single };
        }

        public override List<PriceListItem> ListFromWrapper(PriceListItemsWrapper wrapper)
        {
            return wrapper.priceListItems;
        }

        public override PriceListItem SingleFromWrapper(PriceListItemWrapper wrapper)
        {
            return wrapper.priceListItem;
        }
    }
}

