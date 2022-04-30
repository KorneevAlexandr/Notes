using Microsoft.AspNetCore.Mvc;
using ModelsDTO.Models;
using Notes.BusinessLogic.Intefaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.NoteApi.Controllers
{
	[ApiController]
	[Route("note")]
	public class NoteController : Controller
	{
		private readonly INoteService _noteService;

		public NoteController(INoteService noteService)
		{
			_noteService = noteService;
		}

		[HttpGet("getNotes")]
		public async Task<IActionResult> GetAll()
		{
			IEnumerable<NoteDto> notes = null;
			try
			{
				notes = _noteService.GetAll();
			}
			catch (Exception ex)
			{ 
			}
			await Task.CompletedTask;
			return Ok(notes);
		}

		[HttpGet("getNote")]
		public async Task<IActionResult> Get([FromHeader] int id)
		{
			var note = _noteService.Get(id);
			await Task.CompletedTask;
			return Ok(note);
		}

		[HttpGet("getCount")]
		public async Task<IActionResult> Count()
		{
			var count = _noteService.Count();
			await Task.CompletedTask;
			return Ok(count);
		}

		[HttpPost("createNote")]
		public async Task<IActionResult> Create([FromBody] NoteDto note)
		{
			_noteService.Create(note);
			await Task.CompletedTask;
			return Ok();
		}

		[HttpDelete("deleteNote")]
		public async Task<IActionResult> Delete([FromHeader] int id)
		{
			_noteService.Delete(id);
			await Task.CompletedTask;
			return Ok();
		}

		[HttpPut("updateNote")]
		public async Task<IActionResult> Update([FromBody] NoteDto note)
		{
			_noteService.Update(note);
			await Task.CompletedTask;
			return Ok();
		}
	}
}
