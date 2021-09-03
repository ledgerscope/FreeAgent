using FreeAgent.Client;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class Category : BaseModel, IRemoveUrlOnSerialization
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("nominal_code")]
        public string NominalCode { get; set; }
        [JsonProperty("group_description")]
        public string GroupDescription { get; set; }
        [JsonProperty("auto_sales_tax_rate")]
        public string AutoSalesTaxRate { get; set; }
        [JsonProperty("allowable_for_tax")]
        public bool AllowableForTax { get; set; }
        [JsonProperty("tax_reporting_name")]
        public string TaxReportingName { get; set; }
    }

    public class Categories
    {
        public Categories()
        {
            admin_expenses_categories = new List<Category>();
            cost_of_sales_categories = new List<Category>();
            income_categories = new List<Category>();
            general_categories = new List<Category>();
        }

        public List<Category> admin_expenses_categories { get; set; }
        public List<Category> cost_of_sales_categories { get; set; }
        public List<Category> income_categories { get; set; }
        public List<Category> general_categories { get; set; }
    }
}

