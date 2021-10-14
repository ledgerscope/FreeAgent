using FreeAgent.Models;
using RestSharp;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class PayrollClient : BaseClient
    {
        public PayrollClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "payroll";

        public async Task<PeriodsWrapper> AllPeriodsAsync(int year)
        {
            var request = CreateBasicRequest(Method.GET, "/{year}");
            request.AddParameter("year", year, ParameterType.UrlSegment);

            return await Client.ExecuteAsync<PeriodsWrapper>(request);
        }

        public async Task<PeriodWrapper> AllPayslipsForYearPeriodAsync(int year, byte period)
        {
            var request = CreateBasicRequest(Method.GET, "/{year}/{period}");
            request.AddParameter("year", year, ParameterType.UrlSegment);
            request.AddParameter("period", period, ParameterType.UrlSegment);

            return await Client.ExecuteAsync<PeriodWrapper>(request);
        }
    }
}

