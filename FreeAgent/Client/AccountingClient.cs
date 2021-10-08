using FreeAgent.Extensions;
using FreeAgent.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class AccountingClient : ResourceClient<TrialBalanceSummaryWrapper, TrialBalancesSummaryWrapper, TrialBalanceSummary> //BaseClient
    {
        public AccountingClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "accounting";

        public override TrialBalanceSummaryWrapper WrapperFromSingle(TrialBalanceSummary single)
        {
            return new TrialBalanceSummaryWrapper { trial_balance_summary = single };
        }

        public override List<TrialBalanceSummary> ListFromWrapper(TrialBalancesSummaryWrapper wrapper)
        {
            return wrapper.trial_balance_summary;
        }

        public override TrialBalanceSummary SingleFromWrapper(TrialBalanceSummaryWrapper wrapper)
        {
            return wrapper.trial_balance_summary;
        }

        /// <summary>
        /// If no dates are specified, the summary is for the current date.
        /// If only to is specified, the summary is for a period containing the specified date.
        /// The trial balance figures are from the beginning of the accounting period up to the specified date.
        /// If both from and to are specified, the summary is for a period with the specified custom range.
        /// </summary>
        /// <param name="from_date">Date in YYYY-MM-DD format (optional)</param>
		/// <param name="to_date">Date in YYYY-MM-DD format</param>
        public List<TrialBalanceSummary> AllForPeriod(string from_date = "", string to_date = "")
        {
            return All((request) =>
            {
                request.Resource += "/trial_balance/summary";

                if (!string.IsNullOrEmpty(from_date))
                {
                    request.AddParameter("from_date", from_date, ParameterType.GetOrPost);
                }

                if (!string.IsNullOrEmpty(to_date))
                {
                    request.AddParameter("to_date", to_date, ParameterType.GetOrPost);
                }
            });
        }

        /// <summary>
        /// If no dates are specified, the summary is for the current date.
        /// If only to is specified, the summary is for a period containing the specified date.
        /// The trial balance figures are from the beginning of the accounting period up to the specified date.
        /// If both from and to are specified, the summary is for a period with the specified custom range.
        /// </summary>
        public List<TrialBalanceSummary> TrialBalanceSummary(DateTime? from = null, DateTime? to = null)
        {
            //var path = getTrialBalanceRequestPath(from, to);
            //var request = CreateBasicRequest(Method.GET, path);
            //var response = Client.Execute<TrialBalanceSummaryWrapper>(request);

            //if (response != null) return response.trial_balance_summary;

            return null;
        }

        private static string getTrialBalanceRequestPath(DateTime? from, DateTime? to)
        {
            const string path = "/trial_balance/summary";
            const string fromDateParam = "from_date";
            const string toDateParam = "to_date";

            var fromFilter = from.ToTrialBalanceFilterTime();
            var toFilter = to.ToTrialBalanceFilterTime();

            if (from.HasValue && to.HasValue)
                return $"{path}?{fromDateParam}={fromFilter}&{toDateParam}={toFilter}";

            if (from.HasValue)
                return $"{path}?{fromDateParam}={fromFilter}";

            if (to.HasValue)
                return $"{path}?{toDateParam}={toFilter}";

            return path;
        }
    }
}

