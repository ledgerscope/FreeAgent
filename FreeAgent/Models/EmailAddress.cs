using System.Collections.Generic;

namespace FreeAgent.Models
{
    public class EmailAddressesWrapper
    {
        public EmailAddressesWrapper()
        {
            emailAddresses = new List<string>();
        }

        public List<string> emailAddresses { get; set; }
    }
}
