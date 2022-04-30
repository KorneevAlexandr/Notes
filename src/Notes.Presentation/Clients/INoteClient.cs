using ModelsDTO.Models;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Presentation.Clients
{
	public interface INoteClient
	{
		[Get("note/getNotes")]
		Task<IEnumerable<NoteDto>> GetAll();

		[Get("note/getNote")]
		Task<NoteDto> Get([Header("id")] int id);

		[Post("note/createNote")]
		Task Create([Body] NoteDto note);

		[Delete("note/deleteNote")]
		Task Delete([Header("id")] int id);
	}
}
