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
            cisBand = null;
        }

        public CISBand cisBand { get; set; }
    }

    public class CISBandsWrapper
    {
        public CISBandsWrapper()
        {
            cisBands = new List<CISBand>();
        }

        public List<CISBand> cisBands { get; set; }
    }
}

