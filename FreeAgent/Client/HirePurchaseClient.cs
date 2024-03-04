using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class HirePurchaseClient : ResourceClient<HirePurchaseWrapper, HirePurchasesWrapper, HirePurchase>
    {
        public HirePurchaseClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "hire_purchases";

        public override HirePurchaseWrapper WrapperFromSingle(HirePurchase single)
        {
            return new HirePurchaseWrapper { hire_purchase = single };
        }

        public override List<HirePurchase> ListFromWrapper(HirePurchasesWrapper wrapper)
        {
            return wrapper.hire_purchases;
        }

        public override HirePurchase SingleFromWrapper(HirePurchaseWrapper wrapper)
        {
            return wrapper.hire_purchase;
        }
    }
}

