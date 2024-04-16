using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class JournalSetClient : ResourceClient<JournalSetWrapper, JournalSetsWrapper, JournalSet>
    {
        public JournalSetClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "journal_sets";

        public override JournalSetWrapper WrapperFromSingle(JournalSet single)
        {
            return new JournalSetWrapper { journal_set = single };
        }

        public override List<JournalSet> ListFromWrapper(JournalSetsWrapper wrapper)
        {
            return wrapper.journal_sets;
        }

        public override JournalSet SingleFromWrapper(JournalSetWrapper wrapper)
        {
            return wrapper.journal_set;
        }

        public IAsyncEnumerable<JournalSet> AllAsync(string from_date = "", string to_date = "", string tag = "")
        {
            return AllAsync((request) =>
            {
                if (!string.IsNullOrEmpty(from_date))
                {
                    request.AddParameter("from_date", from_date, ParameterType.GetOrPost);
                }
                if (!string.IsNullOrEmpty(to_date))
                {
                    request.AddParameter("to_date", to_date, ParameterType.GetOrPost);
                }
                if (!string.IsNullOrEmpty(tag))
                {
                    request.AddParameter("tag", tag, ParameterType.GetOrPost);
                }
            });
        }
    }
}

