using FreeAgent.Client;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class User : UpdatableModel, IRemoveUrlOnSerialization
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public int permission_level { get; set; }
        public double opening_mileage { get; set; }
        public string password { get; set; }
        public string password_confirmation { get; set; }
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
    public enum UserPermission
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

    public static class UserRole
    {
        public static string Director = "Director";
        public static string Accountant = "Accountant";
        public static string CompanySecretary = "Company Secretary";
        public static string Employee = "Employee";
        public static string Shareholder = "Shareholder";
    }
}

