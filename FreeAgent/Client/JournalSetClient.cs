using FreeAgent.Models;
using System.Collections.Generic;

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
    }
}

