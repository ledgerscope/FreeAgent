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

        public enum Order { Earliest, Latest };

        public List<Expense> GetExpenseSorted(Order order)
        {
            var request = CreateBasicRequest(Method.GET);

            request.AddParameter("page", 1, ParameterType.GetOrPost);
            request.AddParameter("per_page", 1, ParameterType.GetOrPost);

            // To sort in descending order, the sort parameter can be prefixed with a hyphen
            var sort = order == Order.Earliest ? "dated_on" : "-dated_on";

            request.AddParameter("sort", sort, ParameterType.GetOrPost);

            var response = Client.Execute<ExpensesWrapper>(request);

            return response.expenses;
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

