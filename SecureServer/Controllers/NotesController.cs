using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecureServer.Models.DTO;
using SecureServer.Services;

namespace SecureServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;
        private readonly IMapService _mapService;

        public NotesController(INotesService notesService, IMapService mapService)
        {
            _notesService = notesService;
            _mapService = mapService;
        }

        [HttpGet("public")]
        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetPublicNotes()
        {
            var notes = await _notesService.GetPublicNotes();
            var notesDTO = notes.Select(n => _mapService.Map(n));
            return Ok(notesDTO);
        }
    }
}