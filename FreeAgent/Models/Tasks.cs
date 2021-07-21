using FreeAgent.Client;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class Task : BaseModel, IRemoveUrlOnSerialization
    {
        public Task() : base()
        {

        }

        public string project { get; set; }
        public string name { get; set; }
        public bool is_billable { get; set; }
        public double billing_rate { get; set; }
        public string billing_period { get; set; }
        public string status { get; set; }
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

