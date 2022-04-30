using System;

namespace ModelsDTO.Models
{
	public class NoteDto
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string Content { get; set; }

		public DateTime CreateDate { get; set; }
	}
}
