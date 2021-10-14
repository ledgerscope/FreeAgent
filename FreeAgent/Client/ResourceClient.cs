using FreeAgent.Exceptions;
using FreeAgent.Extensions;
using FreeAgent.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using SystemTask = System.Threading.Tasks.Task;

namespace FreeAgent.Client
{
    public abstract class ResourceClient<TSingleWrapper, TListWrapper, TSingle> : BaseClient
        where TSingle : BaseModel
        where TListWrapper : new()
        where TSingleWrapper : new()
    {
        public ResourceClient(FreeAgentClient client) : base(client)
        {
        }

        public abstract TSingleWrapper WrapperFromSingle(TSingle single);
        public abstract List<TSingle> ListFromWrapper(TListWrapper wrapper);
        public abstract TSingle SingleFromWrapper(TSingleWrapper wrapper);

        private const int PageSize = 50;

        public async Task<List<TSingle>> AllAsync(Action<RestRequest> customizeRequest = null)
        {
            int page = 1;

            List<TSingle> allItems = new List<TSingle>();

            while (true)
            {
                var request = CreateAllRequest();
                if (customizeRequest != null) customizeRequest(request);

                AddPaging(request, page);

                var response = await Client.ExecuteAsync<TListWrapper>(request);

                if (response != null)
                {
                    var newItems = ListFromWrapper(response);
                    allItems.AddRange(newItems);

                    if (newItems.Count < PageSize) return allItems;
                }
                else if (response == null && page == 1)
                {
                    return null;
                }
                else
                {
                    return allItems;
                }

                page++;
            }
        }

        public async Task<TSingle> GetModelSortedAsync(Order order, string bankAccountUrl = null)
        {
            var request = CreateBasicRequest(Method.GET);

            request.AddParameter("page", 1, ParameterType.GetOrPost);
            request.AddParameter("per_page", 1, ParameterType.GetOrPost);

            // To sort in descending order, the sort parameter can be prefixed with a hyphen
            var sort = order == Order.Earliest ? "dated_on" : "-dated_on";

            if (!string.IsNullOrEmpty(bankAccountUrl))
            {
                request.AddParameter("bank_account", bankAccountUrl, ParameterType.GetOrPost);
            }

            request.AddParameter("sort", sort, ParameterType.GetOrPost);

            var response = await Client.ExecuteAsync<TListWrapper>(request);

            if (response != null)
            {
                var items = ListFromWrapper(response);

                if (items.Count > 0)
                {
                    return items[0];
                }
            }

            return null;
        }

        public async Task<TSingle> GetAsync(string id)
        {
            try
            {
                var request = CreateGetRequest(id);
                var response = await Client.ExecuteAsync<TSingleWrapper>(request);

                if (response != null) return SingleFromWrapper(response);

                return null;
            }
            catch (FreeAgentException fex)
            {
                if (fex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw;
            }
        }

        public async Task<TSingle> PutAsync(TSingle c)
        {
            var request = CreatePutRequest(c);
            var response = await Client.ExecuteAsync<TSingleWrapper>(request);

            if (response != null) return SingleFromWrapper(response);

            return null;
        }

        public SystemTask DeleteAsync(string id)
        {
            var request = CreateDeleteRequest(id);

            return Client.ExecuteAsync(request);
        }

        protected RestRequest CreateAllRequest()
        {
            var request = CreateBasicRequest(Method.GET);
            CustomizeAllRequest(request);

            return request;
        }

        protected RestRequest CreateGetRequest(string id)
        {
            var request = CreateBasicRequest(Method.GET, "/{id}");
            request.AddParameter("id", id, ParameterType.UrlSegment);

            return request;
        }

        protected RestRequest CreatePutRequest(TSingle item)
        {
            bool isNewRecord = string.IsNullOrEmpty(item.Url.ToString());
            var request = CreateBasicRequest(isNewRecord ? Method.POST : Method.PUT, isNewRecord ? "" : "/{id}");

            if (item is IRemoveUrlOnSerialization || item is IRemoveRecurringOnSerialization)
            {
                request.JsonSerializer = new UrlParsingJsonSerializer();
            }

            request.RequestFormat = DataFormat.Json;

            if (!isNewRecord) request.AddParameter("id", item.Id(), ParameterType.UrlSegment);
            request.AddBody(WrapperFromSingle(item));

            return request;
        }

        protected RestRequest CreateDeleteRequest(string id)
        {
            var request = CreateBasicRequest(Method.DELETE, "/{id}");

            request.AddParameter("id", id, ParameterType.UrlSegment);

            return request;
        }

        public virtual void AddPaging(RestRequest request, int page = 1)
        {
            request.AddParameter("page", page, ParameterType.GetOrPost);
            request.AddParameter("per_page", PageSize, ParameterType.GetOrPost);
        }
    }
}

