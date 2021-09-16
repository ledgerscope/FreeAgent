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
            return new CapitalAssetWrapper { capital_asset = single };
        }

        public override List<CapitalAsset> ListFromWrapper(CapitalAssetsWrapper wrapper)
        {
            return wrapper.capital_assets;
        }

        public override CapitalAsset SingleFromWrapper(CapitalAssetWrapper wrapper)
        {
            return wrapper.capital_asset;
        }
    }
}

