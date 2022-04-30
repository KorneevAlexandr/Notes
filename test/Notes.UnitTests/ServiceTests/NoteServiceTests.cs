using ModelsDTO.Models;
using Moq;
using Notes.BusinessLogic.Services;
using Notes.DataAccess.Interfaces.Repositories;
using Notes.DataAccess.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Notes.UnitTests.ServiceTests
{
	public class NoteServiceTests
	{
		private Mock<IRepository<Note>> _mockNoteRepository;
		private Note _note = new Note
		{
			Id = 1, 
			Title = "Main",
			Description = "Desc",
			CreateDate = new DateTime(2010, 10, 10),
			Content = "Message"
		};
		private NoteDto _noteDto = new NoteDto
		{
			Id = 1,
			Title = "Main",
			Description = "Desc",
			CreateDate = new DateTime(2010, 10, 10),
			Content = "Message"
		};

		[SetUp]
		public void Setup()
		{
			_mockNoteRepository = new Mock<IRepository<Note>>();

			_mockNoteRepository.Setup(method => method.GetAll()).Returns(new List<Note> { _note }.AsQueryable());
			_mockNoteRepository.Setup(method => method.Get(It.IsAny<int>())).Returns(_note);
		}

		[Test]
		public void GetAll_WhenAllValid_SameCollection()
		{
			// Arrange 
			var service = GetNoteService();

			// Act
			var notes = service.GetAll();

			// Assert
			Assert.AreEqual(_noteDto.Id, notes.FirstOrDefault().Id);
		}

		[Test]
		public void Get_WhenAllValid_SameCollection()
		{
			// Arrange 
			var service = GetNoteService();

			// Act
			var note = service.Get(0);

			// Assert
			Assert.AreEqual(_noteDto.Id, note.Id);
		}


		private NoteService GetNoteService()
		{
			return new NoteService(_mockNoteRepository.Object);
		}
	}
}
