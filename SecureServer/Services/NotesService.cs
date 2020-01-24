using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecureServer.Models.Domain;
using Server.DAO;

namespace SecureServer.Services
{
    internal class NotesService : INotesService
    {
        private readonly SecureContext _secureContext;
        private readonly IMapService _mapService;

        public NotesService(SecureContext secureContext, IMapService mapService)
        {
            _secureContext = secureContext;
            _mapService = mapService;
        }

        public async Task<IEnumerable<NoteModel>> GetPublicNotes()
        {
            return await Task.Run(() =>
                _secureContext.Notes
                    .Where(n => n.IsPublic)
                    .Select(n => _mapService.Map(n))
                    .AsEnumerable());
        }
    }
}