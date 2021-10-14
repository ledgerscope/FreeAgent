using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class AccountingClient : ResourceClient<TrialBalanceSummaryWrapper, TrialBalancesSummaryWrapper, TrialBalanceSummary>
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
        public Task<List<TrialBalanceSummary>> AllForPeriodAsync(string from_date = "", string to_date = "")
        {
            return AllAsync((request) =>
            {
                // If we put '/trial_balance/summary' on the ResourceName, it get's url-encoded and we get 404 upon making a request
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
    }
}

