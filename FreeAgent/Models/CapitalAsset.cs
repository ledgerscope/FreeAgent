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
        [JsonProperty("capital_asset_history")]
        public List<CapitalAssetHistoryItem> CapitalAssetHistory { get; set; }
    }

    public class CapitalAssetHistoryItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("value")]
        public decimal Value { get; set; }
        [JsonProperty("tax_value")]
        public decimal TaxValue { get; set; }
        [JsonProperty("link")]
        public Uri Link { get; set; }

        public static class CapitalAssetHistoryItemType
        {
            public const string Purchase = "purchase";
            public const string Depreciation = "depreciation";
            public const string AnnualInvestmentAllowance = "annual_investment_allowance";
            public const string Disposal = "disposal";
        }
    }

    public static class SystemCapitalAssetType
    {
        public const string ComputerEquipment = "Computer Equipment";
        public const string FixturesAndFittings = "Fixtures and Fittings";
        public const string MotorVehicles = "Motor Vehicles";
        public const string OtherCapitalAsset = "Other Capital Asset";
    }

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




