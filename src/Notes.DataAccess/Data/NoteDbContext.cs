﻿using Microsoft.EntityFrameworkCore;
using Notes.DataAccess.Models;

namespace Notes.DataAccess.Data
{
	internal class NoteDbContext : DbContext
	{
		public NoteDbContext(DbContextOptions<NoteDbContext> options)
			: base(options)
		{
		}

		public DbSet<Note> Notes { get; set; }
	}
}
