using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class Timeslip : UpdatableModel, IRemoveUrlOnSerialization
    {
        [JsonProperty("user")]
        public Uri User { get; set; }
        [JsonProperty("project")]
        public Uri Project { get; set; }
        [JsonProperty("task")]
        public Uri Task { get; set; }
        [JsonProperty("dated_on")]
        public DateTime DatedOn { get; set; }
        [JsonProperty("hours")]
        public decimal Hours { get; set; }
        [JsonProperty("comment")]
        public string Comment { get; set; }
        [JsonProperty("billed_on_invoice")]
        public Uri BilledOnInvoice { get; set; }

        // Additional properties for timeslips with running timers
        [JsonProperty("timer")]
        public RunningTimer Timer { get; set; }
    }

    public class RunningTimer
    {
        [JsonProperty("running")]
        public bool Running { get; set; }
        [JsonProperty("start_from")]
        public DateTime StartFrom { get; set; }
    }

    public class TimeslipWrapper
    {
        public TimeslipWrapper()
        {
            timeslip = null;
        }

        public Timeslip timeslip { get; set; }
    }

    public class TimeslipsWrapper
    {
        public TimeslipsWrapper()
        {
            timeslips = new List<Timeslip>();
        }

        public List<Timeslip> timeslips { get; set; }
    }
}

