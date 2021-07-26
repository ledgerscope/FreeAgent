using System.Collections.Generic;

namespace FreeAgent.Models
{
    /// <summary>
    /// Verified sender email address
    /// </summary>
    public class EmailAddress
    {
        public List<string> EmailAddresses { get; set; }
    }

    public class EmailAddressesWrapper
    {
        public EmailAddressesWrapper()
        {
            emailAddresses = new List<EmailAddress>();
        }

        public List<EmailAddress> emailAddresses { get; set; }
    }
}
