using ModelsDTO.Models;
using Notes.BusinessLogic.Intefaces.Services;
using Notes.DataAccess.Interfaces.Repositories;
using Notes.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace Notes.BusinessLogic.Services
{
	public class NoteService : INoteService
	{
		private readonly IRepository<Note> _noteRepository;

		public NoteService(IRepository<Note> noteRepository)
		{
			_noteRepository = noteRepository;
		}

		public IEnumerable<NoteDto> GetAll()
		{
			var notes = _noteRepository.GetAll().AsEnumerable();
			return Map(notes);
		}

		public NoteDto Get(int id)
		{
			var note = _noteRepository.Get(id);
			return Map(note);
		}

		public int Count()
		{
			return _noteRepository.Count();
		}

		public void Create(NoteDto note)
		{
			_noteRepository.Create(Map(note));
		}

		public void Delete(int id)
		{
			_noteRepository.Delete(id);
		}

		public void Update(NoteDto note)
		{
			_noteRepository.Update(Map(note));
		}

		private Note Map(NoteDto note)
		{
			return new Note
			{
				Id = note.Id,
				Description = note.Description,
				CreateDate = note.CreateDate,
				Title = note.Title,
				Content = note.Content,
			};
		}

		private NoteDto Map(Note note)
		{
			return new NoteDto
			{
				Id = note.Id,
				Description = note.Description,
				CreateDate = note.CreateDate,
				Title = note.Title,
				Content = note.Content,
			};
		}

		private IEnumerable<Note> Map(IEnumerable<NoteDto> notes)
		{
			return notes.Select(note => Map(note));
		}

		private IEnumerable<NoteDto> Map(IEnumerable<Note> notes)
		{
			return notes.Select(note => Map(note));
		}
	}
}
