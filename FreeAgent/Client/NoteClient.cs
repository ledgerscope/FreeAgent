using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAgent.Client
{
    public class NoteClient : ResourceClient<NoteWrapper, NotesWrapper, Note>
    {
        public NoteClient(FreeAgentClient client) : base(client) { }

        public override string ResourceName => "notes";

        public override NoteWrapper WrapperFromSingle(Note single)
        {
            return new NoteWrapper { note = single };
        }

        public override List<Note> ListFromWrapper(NotesWrapper wrapper)
        {
            return wrapper.notes;
        }

        public override Note SingleFromWrapper(NoteWrapper wrapper)
        {
            return wrapper.note;
        }

        public IAsyncEnumerable<Note> AllForContactAsync(string contact)
        {
            return AllAsync((request) => request.AddParameter("contact", contact, ParameterType.GetOrPost));
        }

        public IAsyncEnumerable<Note> AllForProjectAsync(string project)
        {
            return AllAsync((request) => request.AddParameter("project", project, ParameterType.GetOrPost));
        }
    }
}

