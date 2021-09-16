using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class CapitalAsset : UpdatableModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("asset_life_years")]
        public int AssetLifeYears { get; set; }
        [JsonProperty("asset_type")]
        public string AssetType { get; set; }
        [JsonProperty("purchased_on")]
        public DateTime PurchasedOn { get; set; }
        [JsonProperty("disposed_on")]
        public DateTime DisposedOn { get; set; }
        //[JsonProperty("capital_asset_history")]
        //public List<CapitalAssetHistoryItem> CapitalAssetHistory { get; set; } // Returned if 'include_history=true' is added to the request URL
    }

    //public class CapitalAssetHistoryItem
    //{
    //}

    //public static class CapitalAssetType
    //{
    //    public static string ComputerEquipment = "Computer Equipment";
    //    public static string FixturesAndFittings = "Fixtures and Fittings";
    //    public static string MotorVehicles = "Motor Vehicles";
    //    public static string OtherCapitalAsset = "Other Capital Asset";
    //}

    public class CapitalAssetWrapper
    {
        public CapitalAssetWrapper()
        {
            capital_asset = null;
        }

        public CapitalAsset capital_asset { get; set; }
    }

    public class CapitalAssetsWrapper
    {
        public CapitalAssetsWrapper()
        {
            capital_assets = new List<CapitalAsset>();
        }

        public List<CapitalAsset> capital_assets { get; set; }
    }
}




