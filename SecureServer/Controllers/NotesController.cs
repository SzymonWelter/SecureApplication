using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecureServer.Models.DTO;
using SecureServer.Services;

namespace SecureServer.Controllers
{
    [ApiController]
    [Route("api")]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;
        private readonly IMapService _mapService;

        public NotesController(INotesService notesService, IMapService mapService)
        {
            _notesService = notesService;
            _mapService = mapService;
        }

        [HttpGet("public/notes")]
        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetPublicNotes()
        {
            var notes = await _notesService.GetPublicNotes();
            var notesDTO = notes.Select(n => _mapService.Map(n));
            return Ok(notesDTO);
        }

        [Authorize]
        [HttpGet("{userId}/notes")]
        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetUserNotes(Guid userId)
        {
            var notes = await _notesService.GetUserNotes(userId);
            var notesDTO = notes.Select(n => _mapService.Map(n));
            return Ok(notesDTO);
        }

        [Authorize]
        [HttpPost("{userId}/notes")]
        public async Task<ActionResult<RequestResultDTO>> Add([FromForm] NoteDTO noteDTO, Guid userId)
        {
            var noteModel = _mapService.Map(noteDTO);
            var result = await _notesService.AddNotes(noteModel, userId);
            return Ok(result);
        }

    }
}