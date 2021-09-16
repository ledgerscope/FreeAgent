using FreeAgent.Client;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    /// <summary>
    /// Only available to UK companies enrolled in the Construction Industry Scheme
    /// </summary>
    public class CISBand : BaseModel, IRemoveUrlOnSerialization
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("deduction_rate")]
        public decimal DeductionRate { get; set; }
        [JsonProperty("income_description")]
        public string IncomeDescription { get; set; }
        [JsonProperty("deduction_description")]
        public string DeductionDescription { get; set; }
        [JsonProperty("nominal_code")]
        public int NominalCode { get; set; }
    }

    public class CISBandWrapper
    {
        public CISBandWrapper()
        {
            available_band = null;
        }

        public CISBand available_band { get; set; }
    }

    public class CISBandsWrapper
    {
        public CISBandsWrapper()
        {
            available_bands = new List<CISBand>();
        }

        public List<CISBand> available_bands { get; set; }
    }
}

