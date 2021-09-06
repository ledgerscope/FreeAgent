using FreeAgent.Models;
using RestSharp;

namespace FreeAgent.Client
{
    public class PayrollClient : BaseClient
    {
        public PayrollClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "payroll";

        public Periods AllPeriods(int year)
        {
            var request = CreateBasicRequest(Method.GET, "/{year}");
            request.AddParameter("year", year, ParameterType.UrlSegment);

            var response = Client.Execute<Periods>(request);

            return response;
        }

        public Period AllPayslipsForAPeriod(int year, byte period)
        {
            var request = CreateBasicRequest(Method.GET, "/{year}/{period}");
            request.AddParameter("year", year, ParameterType.UrlSegment);
            request.AddParameter("period", period, ParameterType.UrlSegment);

            var response = Client.Execute<Period>(request);

            return response;
        }
    }
}

