using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class PayrollClient : BaseClient
    {
        public PayrollClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "payroll";

        // TODO_FA: If this is (not) working, try to redo this PayrollClient to be like BankTransactionClient
        // (using ResourceClient<PeriodWrapper, PeriodsWrapper, Period> + see how AllForAccount works)

        public List<Period> AllPeriods(int year)
        {
            var request = CreateBasicRequest(Method.GET, "/{year}");
            request.AddParameter("year", year, ParameterType.UrlSegment);

            var response = Client.Execute<List<Period>>(request);

            if (response != null) return response;

            return null;
        }

        public Period AllPayslipsForAPeriod(int year, byte period)
        {
            var request = CreateBasicRequest(Method.GET, "/{year}/{period}");
            request.AddParameter("year", year, ParameterType.UrlSegment);
            request.AddParameter("period", period, ParameterType.UrlSegment);

            var response = Client.Execute<Period>(request);

            if (response != null) return response;

            return null;
        }
    }
}

