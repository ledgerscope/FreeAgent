using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class BankTransactionExplanationClient : ResourceClient<BankTransactionExplanationWrapper, BankTransactionExplanationsWrapper, BankTransactionExplanation>
    {
        public BankTransactionExplanationClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "bank_transaction_explanations";

        public override BankTransactionExplanationWrapper WrapperFromSingle(BankTransactionExplanation single)
        {
            return new BankTransactionExplanationWrapper { bank_transaction_explanation = single };
        }

        public override List<BankTransactionExplanation> ListFromWrapper(BankTransactionExplanationsWrapper wrapper)
        {
            return wrapper.bank_transaction_explanations;
        }

        public override BankTransactionExplanation SingleFromWrapper(BankTransactionExplanationWrapper wrapper)
        {
            return wrapper.bank_transaction_explanation;
        }

        public List<BankTransactionExplanation> AllForAccount(string bankAccount, string from_date = "", string to_date = "")
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

