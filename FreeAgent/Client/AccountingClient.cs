using FreeAgent.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class AccountingClient : BaseClient
    {
        public AccountingClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "accounting";

        /// <summary>
        /// If no dates are specified, the summary is for the current date.
        /// If only to is specified, the summary is for a period containing the specified date.
        /// The trial balance figures are from the beginning of the accounting period up to the specified date.
        /// If both from and to are specified, the summary is for a period with the specified custom range.
        /// </summary>
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
            const string path = "/trial_balance/summary";
            const string fromDateParam = "from_date";
            const string toDateParam = "to_date";

            if (from.HasValue && to.HasValue)
                return $"{path}?{fromDateParam}={format(from)}&{toDateParam}={format(to)}";

            if (from.HasValue)
                return $"{path}?{fromDateParam}={format(from)}";

            if (to.HasValue)
                return $"{path}?{toDateParam}={format(to)}";

            return path;
        }

        private static string format(DateTime? date)
        {
            return date.Value.ToString("yyyy-MM-dd");
        }
    }
}

