using FreeAgent.Extensions;
using FreeAgent.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class TimeslipClient : ResourceClient<TimeslipWrapper, TimeslipsWrapper, Timeslip>
    {
        public TimeslipClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "timeslips";

        public override TimeslipWrapper WrapperFromSingle(Timeslip single)
        {
            return new TimeslipWrapper { timeslip = single };
        }

        public override List<Timeslip> ListFromWrapper(TimeslipsWrapper wrapper)
        {
            return wrapper.timeslips;
        }

        public override Timeslip SingleFromWrapper(TimeslipWrapper wrapper)
        {
            return wrapper.timeslip;
        }

        public Task<List<Timeslip>> AllAsync(string from_date, string to_date)
        {
            return AllAsync((request) =>
            {
                request.AddParameter("from_date", from_date, ParameterType.GetOrPost);
                request.AddParameter("to_date", to_date, ParameterType.GetOrPost);
            });
        }

        public Task<List<Timeslip>> AllRecentAsync()
        {
            DateTime now = DateTime.Now;

            return AllAsync((request) =>
            {
                request.AddParameter("from_date", now.AddDays(-20).ModelDate(), ParameterType.GetOrPost);
                request.AddParameter("to_date", now.ModelDate(), ParameterType.GetOrPost);
            });
        }
    }
}

