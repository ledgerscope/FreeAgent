using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class FinalAccountsReportClient : ResourceClient<FinalAccountsReportWrapper, FinalAccountsReportsWrapper, FinalAccountsReport>
    {
        public FinalAccountsReportClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "final_accounts_reports";

        public override FinalAccountsReportWrapper WrapperFromSingle(FinalAccountsReport single)
        {
            return new FinalAccountsReportWrapper { final_accounts_report = single };
        }

        public override List<FinalAccountsReport> ListFromWrapper(FinalAccountsReportsWrapper wrapper)
        {
            return wrapper.final_accounts_reports;
        }

        public override FinalAccountsReport SingleFromWrapper(FinalAccountsReportWrapper wrapper)
        {
            return wrapper.final_accounts_report;
        }
    }
}

