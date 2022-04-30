using ModelsDTO.Models;
using Notes.BusinessLogic.Intefaces.Services;
using Notes.BusinessLogic.Services;
using Notes.DataAccess.Data;
using Notes.IntegrationTests.Stubs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.IntegrationTests.ServiceTests
{
	public class NoteServiceTests
	{
		private INoteService _service;

		[SetUp]
		public void Setup()
		{
			var noteRepository = new NoteRepositoryStub();
			_service = new NoteService(noteRepository);
		}


		[Test]
		public void GetAll_WhenAddedNewNote_ReturnUpdatedCollection()
		{
			// Arrange
			var note = new NoteDto
			{
				Description = "test",
				Content = "test",
				Title = "uniqueTitle"
			};

			_service.Create(note);

			// Act
			var notes = _service.GetAll().ToList();

			// Assert
			_service.Delete(notes[notes.Count - 1].Id);
			Assert.IsNotNull(notes.FirstOrDefault(note => note.Title.Equals(note.Title)));
		}

	}
}
