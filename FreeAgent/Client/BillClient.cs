using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class BillClient : ResourceClient<BillWrapper, BillsWrapper, Bill>
    {
        public BillClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "bills";

        public override void CustomizeAllRequest(RestRequest request)
        {
            // By supplying the header FreeAgent-Feature: bill_items we're able to retrieve, create and update bills with the new schema
            request.AddHeader("FreeAgent-Features", "bill_items");

            request.AddParameter("nested_bill_items", "true", ParameterType.GetOrPost);
        }

        public override BillWrapper WrapperFromSingle(Bill single)
        {
            return new BillWrapper { bill = single };
        }

        public override List<Bill> ListFromWrapper(BillsWrapper wrapper)
        {
            return wrapper.bills;
        }

        public override Bill SingleFromWrapper(BillWrapper wrapper)
        {
            return wrapper.bill;
        }

        public IAsyncEnumerable<Bill> AllAsync(string from_date = "", string to_date = "")
        {
            return AllAsync((request) =>
            {
                if (!string.IsNullOrEmpty(from_date))
                {
                    request.AddParameter("from_date", from_date, ParameterType.GetOrPost);
                }
                if (!string.IsNullOrEmpty(to_date))
                {
                    request.AddParameter("to_date", to_date, ParameterType.GetOrPost);
                }
            });
        }
    }
}

