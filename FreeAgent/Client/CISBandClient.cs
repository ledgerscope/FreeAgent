using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class CISBandClient : ResourceClient<CISBandWrapper, CISBandsWrapper, CISBand>
    {
        public CISBandClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "cis_bands";

        public override CISBandWrapper WrapperFromSingle(CISBand single)
        {
            return new CISBandWrapper { available_band = single };
        }

        public override List<CISBand> ListFromWrapper(CISBandsWrapper wrapper)
        {
            return wrapper.available_bands;
        }

        public override CISBand SingleFromWrapper(CISBandWrapper wrapper)
        {
            return wrapper.available_band;
        }
    }
}

