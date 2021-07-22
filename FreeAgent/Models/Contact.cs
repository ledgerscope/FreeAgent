using Newtonsoft.Json;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class Contact : UpdatableModel
    {
        //public Contact()
        //{
        //    //locale = "en";
        //    //organisation_name = "";
        //    //first_name = "";
        //    //last_name = "";
        //}

        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("organisation_name")]
        public string OrganisationName { get; set; }
        [JsonProperty("active_projects_count")]
        public string ActiveProjectsCount { get; set; }
        [JsonProperty("direct_debit_mandate_state")]
        public string DirectDebitMandateState { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("emails_invoices_automatically")]
        public string EmailsInvoicesAutomatically { get; set; }
        [JsonProperty("emails_payment_reminders")]
        public string EmailsPaymentReminders { get; set; }
        [JsonProperty("emails_thank_you_notes")]
        public string EmailsThankYouNotes { get; set; }
        [JsonProperty("billing_email")]
        public string BillingEmail { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("mobile")]
        public string Mobile { get; set; }
        [JsonProperty("address1")]
        public string Address1 { get; set; }
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        [JsonProperty("address3")]
        public string Address3 { get; set; }
        [JsonProperty("town")]
        public string Town { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("uses_contact_invoice_sequence")]
        public bool UsesContactInvoiceSequence { get; set; }
        [JsonProperty("uses_contact_level_email_settings")]
        public bool UsesContactLevelEmailSettings { get; set; }
        [JsonProperty("contact_name_on_invoices")]
        public bool ContactNameOnInvoices { get; set; }
        [JsonProperty("charge_sales_tax")]
        public string ChargeSalesTax { get; set; }
        [JsonProperty("sales_tax_registration_number")]
        public string SalesTaxRegistrationNumber { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("default_payment_terms_in_days")]
        public int DefaultPaymentTermsInDays { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
        [JsonProperty("account_balance")]
        public decimal AccountBalance { get; set; }
    }

    public static class ContactStatus
    {
        public static string Active = "Active";
        public static string Hidden = "Hidden";
    }

    public class ContactWrapper
    {
        public ContactWrapper()
        {
            contact = null;
        }

        public Contact contact { get; set; }
    }

    public class ContactsWrapper
    {
        public ContactsWrapper()
        {
            contacts = new List<Contact>();
        }

        public List<Contact> contacts { get; set; }
    }
}



