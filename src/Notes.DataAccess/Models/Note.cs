using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notes.DataAccess.Models
{
	[Table("Notes")]
	public class Note
	{
		[Key]
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string Content { get; set; }

		public DateTime CreateDate { get; set; }
	}
}
