using System;

namespace SecureServer.Models.Domain
{
    public class NoteModel
    {
        public Guid NoteId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsPublic{ get; set; }
    }
}