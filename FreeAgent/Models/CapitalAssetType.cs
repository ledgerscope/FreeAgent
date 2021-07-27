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
            capitalAssetType = null;
        }

        public CapitalAssetType capitalAssetType { get; set; }
    }

    public class CapitalAssetTypesWrapper
    {
        public CapitalAssetTypesWrapper()
        {
            capitalAssetTypes = new List<CapitalAssetType>();
        }

        public List<CapitalAssetType> capitalAssetTypes { get; set; }
    }
}




