using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class CorporationTaxReturnClient : ResourceClient<CorporationTaxReturnWrapper, CorporationTaxReturnsWrapper, CorporationTaxReturn>
    {
        public CorporationTaxReturnClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "corporation_tax_returns";

        public override CorporationTaxReturnWrapper WrapperFromSingle(CorporationTaxReturn single)
        {
            return new CorporationTaxReturnWrapper { corporation_tax_return = single };
        }

        public override List<CorporationTaxReturn> ListFromWrapper(CorporationTaxReturnsWrapper wrapper)
        {
            return wrapper.corporation_tax_returns;
        }

        public override CorporationTaxReturn SingleFromWrapper(CorporationTaxReturnWrapper wrapper)
        {
            return wrapper.corporation_tax_return;
        }
    }
}

