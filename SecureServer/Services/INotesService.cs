using System.Collections.Generic;
using System.Threading.Tasks;
using SecureServer.Models.Domain;

namespace SecureServer.Services
{
    public interface INotesService
    {
        Task<IEnumerable<NoteModel>> GetPublicNotes();
    }
}