using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class BankAccountClient : ResourceClient<BankAccountWrapper, BankAccountsWrapper, BankAccount>
    {
        public BankAccountClient(FreeAgentClient client) : base(client)
        {
        }

        public override string ResourceName => "bank_accounts";

        public override BankAccountWrapper WrapperFromSingle(BankAccount single)
        {
            return new BankAccountWrapper { bank_account = single };
        }

        public override List<BankAccount> ListFromWrapper(BankAccountsWrapper wrapper)
        {
            return wrapper.bank_accounts;
        }

        public override BankAccount SingleFromWrapper(BankAccountWrapper wrapper)
        {
            return wrapper.bank_account;
        }
    }
}

