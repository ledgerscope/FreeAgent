using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class CapitalAssetClient : ResourceClient<CapitalAssetWrapper, CapitalAssetsWrapper, CapitalAsset>
    {
        public CapitalAssetClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "capital_assets";

        public override CapitalAssetWrapper WrapperFromSingle(CapitalAsset single)
        {
            return new CapitalAssetWrapper { capitalAsset = single };
        }

        public override List<CapitalAsset> ListFromWrapper(CapitalAssetsWrapper wrapper)
        {
            return wrapper.capitalAssets;
        }

        public override CapitalAsset SingleFromWrapper(CapitalAssetWrapper wrapper)
        {
            return wrapper.capitalAsset;
        }
    }
}

