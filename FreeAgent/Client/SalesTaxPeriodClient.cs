using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class SalesTaxPeriodClient : ResourceClient<SalesTaxPeriodWrapper, SalesTaxPeriodsWrapper, SalesTaxPeriod>
    {
        public SalesTaxPeriodClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "sales_tax_periods";

        public override SalesTaxPeriodWrapper WrapperFromSingle(SalesTaxPeriod single)
        {
            return new SalesTaxPeriodWrapper { sales_tax_period = single };
        }

        public override List<SalesTaxPeriod> ListFromWrapper(SalesTaxPeriodsWrapper wrapper)
        {
            return wrapper.sales_tax_periods;
        }

        public override SalesTaxPeriod SingleFromWrapper(SalesTaxPeriodWrapper wrapper)
        {
            return wrapper.sales_tax_period;
        }
    }
}

