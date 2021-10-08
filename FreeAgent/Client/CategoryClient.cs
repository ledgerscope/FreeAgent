using FreeAgent.Models;
using RestSharp;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class CategoryClient : BaseClient
    {
        public CategoryClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "categories";

        public async Task<Categories> All(bool includeSubAccounts = false)
        {
            var request = CreateBasicRequest(Method.GET);

            if (includeSubAccounts)
            {
                request.AddParameter("sub_accounts", "true", ParameterType.GetOrPost);
            }

            var response = await Client.Execute<Categories>(request);

            if (response != null) return response;

            return null;
        }

        // Slow? Caching?
        private Categories all;

        public async Task<Category> Single(string id)
        {
            if (all == null) all = await All();

            foreach (var cat in all.admin_expenses_categories)
            {
                if (cat.NominalCode == id) return cat;
            }
            foreach (var cat in all.cost_of_sales_categories)
            {
                if (cat.NominalCode == id) return cat;
            }

            foreach (var cat in all.general_categories)
            {
                if (cat.NominalCode == id) return cat;
            }

            foreach (var cat in all.income_categories)
            {
                if (cat.NominalCode == id) return cat;
            }

            return null;
        }

        /* Disabled
         * 
         * The API comes back with a different root node based on the type.
         * FFS. This is insane. 
         * 
        public Categories Single(string id)
        {
            var request = CreateBasicRequest(Method.GET, "/{id}");
            request.AddParameter("id", id, ParameterType.UrlSegment);

            var response = Client.Execute<Categories>(request);

            if (response != null) return response;

            return null;    
        
        }
        */
    }
}

