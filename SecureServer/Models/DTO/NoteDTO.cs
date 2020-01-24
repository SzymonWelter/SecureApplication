using System;

namespace SecureServer.Models.DTO
{
    public class NoteDTO
    {
        public Guid NoteId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsPublic{ get; set; }
    }
}