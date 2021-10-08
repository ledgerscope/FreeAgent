using FreeAgent.Models;
using RestSharp;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class PayrollClient : BaseClient
    {
        public PayrollClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "payroll";

        public async Task<PeriodsWrapper> AllPeriods(int year)
        {
            var request = CreateBasicRequest(Method.GET, "/{year}");
            request.AddParameter("year", year, ParameterType.UrlSegment);

            return await Client.Execute<PeriodsWrapper>(request);
        }

        public async Task<PeriodWrapper> AllPayslipsForYearPeriod(int year, byte period)
        {
            var request = CreateBasicRequest(Method.GET, "/{year}/{period}");
            request.AddParameter("year", year, ParameterType.UrlSegment);
            request.AddParameter("period", period, ParameterType.UrlSegment);

            return await Client.Execute<PeriodWrapper>(request);
        }
    }
}

