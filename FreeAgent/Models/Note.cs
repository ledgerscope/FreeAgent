using FreeAgent.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FreeAgent.Models
{
    /// <summary>
    /// Contacts and Projects can both have Notes
    /// </summary>
    public class Note : UpdatableModel, IRemoveUrlOnSerialization
    {
        [JsonProperty("note")]
        public string NoteContent { get; set; }
        [JsonProperty("parent_url")]
        public Uri ParentUrl { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
    }

    public class NoteWrapper
    {
        public NoteWrapper()
        {
            note = null;
        }

        public Note note { get; set; }
    }

    public class NotesWrapper
    {
        public NotesWrapper()
        {
            notes = new List<Note>();
        }

        public List<Note> notes { get; set; }
    }
}

