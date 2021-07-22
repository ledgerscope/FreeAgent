using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    public class ExpenseClient : ResourceClient<ExpenseWrapper, ExpensesWrapper, Expense>
    {
        public ExpenseClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "expenses";

        public override ExpenseWrapper WrapperFromSingle(Expense single)
        {
            return new ExpenseWrapper { expense = single };
        }

        public override List<Expense> ListFromWrapper(ExpensesWrapper wrapper)
        {
            return wrapper.expenses;
        }

        public override Expense SingleFromWrapper(ExpenseWrapper wrapper)
        {
            return wrapper.expense;
        }

        public List<Expense> All(string view = "", string from_date = "", string to_date = "")
        {
            return All((request) =>
            {
                if (!string.IsNullOrEmpty(from_date))
                {
                    request.AddParameter("from_date", from_date, ParameterType.GetOrPost);
                }
                if (!string.IsNullOrEmpty(to_date))
                {
                    request.AddParameter("to_date", to_date, ParameterType.GetOrPost);
                }
                if (!string.IsNullOrEmpty(view))
                {
                    request.AddParameter("view", view, ParameterType.GetOrPost);
                }
            });
        }
    }
}

