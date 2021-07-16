using System.Collections.Generic;

namespace FreeAgent
{
    public class Company
    {
        public string url { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string subdomain { get; set; }
        public string type { get; set; }
        public string currency { get; set; }
        public string mileage_units { get; set; }
        public string company_start_date { get; set; }
        public string trading_start_date { get; set; }
        public string first_accounting_year_end { get; set; }
        public string freeagent_start_date { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string town { get; set; }
        public string region { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
        public string company_registration_number { get; set; }
        public string contact_email { get; set; }
        public string contact_phone { get; set; }
        public string website { get; set; }
        public string business_type { get; set; }
        //public string business_category { get; set; }
        //public string short_date_format { get; set; }
        public string sales_tax_name { get; set; }
        public string sales_tax_registration_number { get; set; }
        public string sales_tax_registration_status { get; set; }
        //public string sales_tax_effective_date { get; set; }
        //public string sales_tax_rates { get; set; }
        //public string sales_tax_is_value_added { get; set; }
        //public string cis_enabled { get; set; }
        //public string locked_attributes { get; set; }
        //public string created_at { get; set; }
        //public string updated_at { get; set; }
    }

    public class CompanyWrapper
    {
        public CompanyWrapper()
        {
            company = new Company();
        }

        public Company company { get; set; }
    }

    public class TaxTimeline
    {
        public string description { get; set; }
        public string nature { get; set; }
        public string dated_on { get; set; }
        public float amount_due { get; set; }
        public bool is_personal { get; set; }
    }

    public class TaxTimelineWrapper
    {
        public TaxTimelineWrapper()
        {
            timeline_items = new List<TaxTimeline>();
        }
        public List<TaxTimeline> timeline_items { get; set; }
    }
}
