using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecureServer.Models.DAL;
using SecureServer.Models.Domain;
using SecureServer.Models.DTO;
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

        public async Task<RequestResultModel> AddNotes(NoteModel note, Guid userId)
        {
            NoteDAL noteDAL = _mapService.MapToDAL(note);
            noteDAL.UserId = userId;
            try
            {
                await _secureContext.AddAsync(noteDAL);
                await _secureContext.SaveChangesAsync();
            }
            catch
            {
                return new RequestResultModel
                {
                    IsSuccess = false,
                        Message = "Can not save the note"
                };
            }
            return new RequestResultModel
            {
                IsSuccess = true,
                    Message = "Note uploaded"
            };
        }

        public async Task<IEnumerable<NoteModel>> GetPublicNotes()
        {
            return await Task.Run(() =>
                _secureContext.Notes
                .Where(n => n.IsPublic)
                .OrderBy(n => n.Title)
                .Select(n => _mapService.Map(n))
                .AsEnumerable());
        }

        public async Task<IEnumerable<NoteModel>> GetUserNotes(Guid userId)
        {
            return await Task.Run(() =>
                _secureContext.Notes
                .Where(n => n.UserId == userId)
                .OrderBy(n => n.Title)
                .Select(n => _mapService.Map(n))
                .AsEnumerable());
        }
    }
}