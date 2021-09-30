using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;

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

        public enum Order { Earliest, Latest };

        public List<Bill> GetBillSorted(Order order)
        {
            var request = CreateBasicRequest(Method.GET);

            request.AddParameter("page", 1, ParameterType.GetOrPost);
            request.AddParameter("per_page", 1, ParameterType.GetOrPost);

            // To sort in descending order, the sort parameter can be prefixed with a hyphen
            var sort = order == Order.Earliest ? "dated_on" : "-dated_on";

            request.AddParameter("sort", sort, ParameterType.GetOrPost);

            var response = Client.Execute<BillsWrapper>(request);

            return response.bills;
        }

        public List<Bill> All(string from_date = "", string to_date = "")
        {
            return All((request) =>
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

