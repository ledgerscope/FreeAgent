using FreeAgent.Client;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class CapitalAssetType : UpdatableModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("system_default")]
        public bool SystemDefault { get; set; }
    }

    public class CapitalAssetTypeWrapper
    {
        public CapitalAssetTypeWrapper()
        {
            capital_asset_type = null;
        }

        public CapitalAssetType capital_asset_type { get; set; }
    }

    public class CapitalAssetTypesWrapper
    {
        public CapitalAssetTypesWrapper()
        {
            capital_asset_types = new List<CapitalAssetType>();
        }

        public List<CapitalAssetType> capital_asset_types { get; set; }
    }
}




