using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class HirePurchase : BaseModel, IRemoveUrlOnSerialization, IRemoveRecurringOnSerialization
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("bill")]
        public Uri Bill { get; set; }
        [JsonProperty("liabilities_over_one_year_category")]
        public Uri LiabilitiesOverOneYearCategory { get; set; }
        [JsonProperty("liabilities_under_one_year_category")]
        public Uri LiabilitiesUnderOneYearCategory { get; set; }
    }

    public class HirePurchaseWrapper
    {
        public HirePurchaseWrapper()
        {
            hire_purchase = null;
        }

        public HirePurchase hire_purchase { get; set; }
    }

    public class HirePurchasesWrapper
    {
        public HirePurchasesWrapper()
        {
            hire_purchases = new List<HirePurchase>();
        }

        public List<HirePurchase> hire_purchases { get; set; }
    }
}




