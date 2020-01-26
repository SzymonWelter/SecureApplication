using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SecureServer.Models.Domain;

namespace SecureServer.Services
{
    public interface INotesService
    {
        Task<IEnumerable<NoteModel>> GetPublicNotes();
        Task<IEnumerable<NoteModel>> GetUserNotes(Guid userId);
        Task<RequestResultModel> AddNotes(NoteModel noteDTO, Guid userId);
    }
}