using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    /// <summary>
    /// Only available for UK companies (i.e. those which support payroll in FreeAgent)
    /// </summary>
    public class Profile
    {
        [JsonProperty("user")]
        public Uri User { get; set; }
        [JsonProperty("total_pay_in_previous_employment")]
        public decimal TotalPayInPreviousEmployment { get; set; }
        [JsonProperty("total_tax_in_previous_employment")]
        public decimal TotalTaxInPreviousEmployment { get; set; }
    }

    public class ProfilesWrapper
    {
        public ProfilesWrapper()
        {
            profiles = new List<Profile>();
        }

        public List<Profile> profiles { get; set; }
    }
}

