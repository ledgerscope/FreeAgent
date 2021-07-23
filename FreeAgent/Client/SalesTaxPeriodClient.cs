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
            return new SalesTaxPeriodWrapper { salesTaxPeriod = single };
        }

        public override List<SalesTaxPeriod> ListFromWrapper(SalesTaxPeriodsWrapper wrapper)
        {
            return wrapper.salesTaxPeriods;
        }

        public override SalesTaxPeriod SingleFromWrapper(SalesTaxPeriodWrapper wrapper)
        {
            return wrapper.salesTaxPeriod;
        }
    }
}

