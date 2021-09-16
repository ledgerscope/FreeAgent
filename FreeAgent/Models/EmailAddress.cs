using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class EmailAddressesWrapper
    {
        public EmailAddressesWrapper()
        {
            email_addresses = new List<string>();
        }

        public List<string> email_addresses { get; set; }
    }
}
