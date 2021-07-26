using FreeAgent.Client;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class User : UpdatableModel, IRemoveUrlOnSerialization
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }
        [JsonProperty("ni_number")]
        public string NiNumber { get; set; }
        [JsonProperty("unique_tax_reference")]
        public string UniqueTaxReference { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("opening_mileage")]
        public decimal OpeningMileage { get; set; }
        [JsonProperty("send_invitation")]
        public bool SendInvitation { get; set; }
        [JsonProperty("permission_level")]
        public int PermissionLevel { get; set; }
    }

    public static class UserRole
    {
        public static string Owner = "Owner";
        public static string Director = "Director";
        public static string Partner = "Partner";
        public static string CompanySecretary = "Company Secretary";
        public static string Employee = "Employee";
        public static string Shareholder = "Shareholder";
        public static string Accountant = "Accountant";
    }

    public enum PermissionLevel
    {
        NoAccess = 0,
        Time = 1,
        MyMoney = 2,
        ContactsAndProjects = 3,
        InvoicesEstimatesAndFiles = 4,
        Bills = 5,
        Banking = 6,
        TaxAccountingAndUsers = 7,
        Full = 8
    }

    public class UserWrapper
    {
        public UserWrapper()
        {
            user = null;
        }

        public User user { get; set; }
    }

    public class UsersWrapper
    {
        public UsersWrapper()
        {
            users = new List<User>();
        }

        public List<User> users { get; set; }
    }
}

