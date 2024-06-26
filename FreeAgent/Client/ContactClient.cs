using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class ContactClient : ResourceClient<ContactWrapper, ContactsWrapper, Contact>
    {
        public ContactClient(FreeAgentClient client) : base(client) { }

        public override void CustomizeAllRequest(RestRequest request)
        {
            request.AddParameter("view", "all", ParameterType.GetOrPost);
        }

        public override string ResourceName => "contacts";

        public override ContactWrapper WrapperFromSingle(Contact single)
        {
            return new ContactWrapper { contact = single };
        }

        public override List<Contact> ListFromWrapper(ContactsWrapper wrapper)
        {
            return wrapper.contacts;
        }

        public override Contact SingleFromWrapper(ContactWrapper wrapper)
        {
            return wrapper.contact;
        }
    }
}

