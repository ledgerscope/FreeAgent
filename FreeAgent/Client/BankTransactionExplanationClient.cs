﻿using FreeAgent.Models;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class BankTransactionExplanationClient : ResourceClient<BankTransactionExplanationWrapper, BankTransactionExplanationsWrapper, BankTransactionExplanation>
    {
        public BankTransactionExplanationClient(FreeAgentClient client) : base(client)
        {
        }

        //need to add in the GET to have a parameter for the date filter

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
    }
}

