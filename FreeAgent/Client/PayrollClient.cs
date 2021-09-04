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

    //public class PayrollClient : ResourceClient<PeriodWrapper, PeriodsWrapper, Period>
    //{
    //    public PayrollClient(FreeAgentClient client) : base(client) { }

    //    public override string ResourceName => "payroll";

    //    public override PeriodWrapper WrapperFromSingle(Period single)
    //    {
    //        return new PeriodWrapper { period = single };
    //    }

    //    public override List<Period> ListFromWrapper(PeriodsWrapper wrapper)
    //    {
    //        return wrapper.periods;
    //    }

    //    public override Period SingleFromWrapper(PeriodWrapper wrapper)
    //    {
    //        return wrapper.period;
    //    }

    //    public List<Period> AllPeriods(int year)
    //    {
    //        return All((request) => request.AddParameter("year", year, ParameterType.GetOrPost));
    //    }
    //}
}

