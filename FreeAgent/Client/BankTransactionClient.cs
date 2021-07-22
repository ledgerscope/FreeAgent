using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class BankTransactionClient : ResourceClient<BankTransactionWrapper, BankTransactionsWrapper, BankTransaction>
    {
        public BankTransactionClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "bank_transactions";

        public override BankTransactionWrapper WrapperFromSingle(BankTransaction single)
        {
            return new BankTransactionWrapper { bank_transaction = single };
        }

        public override List<BankTransaction> ListFromWrapper(BankTransactionsWrapper wrapper)
        {
            return wrapper.bank_transactions;
        }

        public override BankTransaction SingleFromWrapper(BankTransactionWrapper wrapper)
        {
            return wrapper.bank_transaction;
        }

        public List<BankTransaction> AllForAccount(string bankAccount, string from_date = "", string to_date = "")
        {
            return All((request) =>
            {
                request.AddParameter("bank_account", bankAccount, ParameterType.GetOrPost);

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

