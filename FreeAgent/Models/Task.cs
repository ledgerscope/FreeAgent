using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class Task : UpdatableModel, IRemoveUrlOnSerialization
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("is_billable")]
        public bool IsBillable { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("project")]
        public Uri Project { get; set; }

        // Additional properties available to users with Contacts & Projects permission level
        [JsonProperty("billing_rate")]
        public decimal BillingRate { get; set; }
        [JsonProperty("billing_period")]
        public string BillingPeriod { get; set; }
    }

    public static class TaskBillingPeriod
    {
        public static string Hour = "hour";
        public static string Day = "day";
    }

    public static class TaskStatus
    {
        public static string Active = "Active";
        public static string Completed = "Completed";
        public static string Hidden = "Hidden";
    }

    public class TaskWrapper
    {
        public TaskWrapper()
        {
            task = null;
        }

        public Task task { get; set; }
    }

    public class TasksWrapper
    {
        public TasksWrapper()
        {
            tasks = new List<Task>();
        }

        public List<Task> tasks { get; set; }
    }
}

