using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class CapitalAssetTypeClient : ResourceClient<CapitalAssetTypeWrapper, CapitalAssetTypesWrapper, CapitalAssetType>
    {
        public CapitalAssetTypeClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "capital_asset_types";

        public override CapitalAssetTypeWrapper WrapperFromSingle(CapitalAssetType single)
        {
            return new CapitalAssetTypeWrapper { capital_asset_type = single };
        }

        public override List<CapitalAssetType> ListFromWrapper(CapitalAssetTypesWrapper wrapper)
        {
            return wrapper.capital_asset_types;
        }

        public override CapitalAssetType SingleFromWrapper(CapitalAssetTypeWrapper wrapper)
        {
            return wrapper.capital_asset_type;
        }
    }
}

