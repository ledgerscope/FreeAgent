using FreeAgent.Models;
using RestSharp;
using System.Collections.Generic;

namespace FreeAgent.Client
{
    // test test test
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

        public List<Note> AllForContact(string contact)
        {
            return All((request) => request.AddParameter("contact", contact, ParameterType.GetOrPost));
        }

        public List<Note> AllForProject(string project)
        {
            return All((request) => request.AddParameter("project", project, ParameterType.GetOrPost));
        }
    }
}

