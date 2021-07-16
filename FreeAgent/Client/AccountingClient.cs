using System;
using System.Collections.Generic;
using RestSharp;

namespace FreeAgent
{
	public class AccountingClient : BaseClient
	{
		public AccountingClient(FreeAgentClient client) : base(client) {}

		public override string ResourceName
		{
			get
			{
				return "accounting";
			}
		}


		public List<TrialBalanceSummary> TrialBalanceSummary(DateTime? from = null, DateTime? to = null)
        {
            var path = getTrialBalanceRequestPath(from, to);
            var request = CreateBasicRequest(Method.GET, path);
            var response = Client.Execute<TrialBalanceSummaryWrapper>(request);

            if (response != null) return response.trial_balance_summary;

            return null;

        }

        private static string getTrialBalanceRequestPath(DateTime? from, DateTime? to)
        {
            var path = "/trial_balance/summary";
            var fromDateParam = "from_date";
            var toDateParam = "to_date";

            if (from.HasValue && to.HasValue) return $"{path}?{fromDateParam}={format(from)}&{toDateParam}={format(to)}";
            if (from.HasValue) return $"{path}?{fromDateParam}={format(from)}";
            if (to.HasValue) return $"{path}?{toDateParam}={format(to)}";

            return path;
        }

        private static string format(DateTime? date)
        {
            return date.Value.ToString("yyyy-MM-dd");
        }
    }
}

