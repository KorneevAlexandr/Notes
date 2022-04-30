using ModelsDTO.Models;
using System.Collections.Generic;

namespace Notes.BusinessLogic.Intefaces.Services
{
	public interface INoteService
	{
		IEnumerable<NoteDto> GetAll();

		NoteDto Get(int id);

		int Count();

		void Create(NoteDto note);

		void Update(NoteDto note);

		void Delete(int id);
	}
}
