using Microsoft.AspNetCore.Mvc;
using ModelsDTO.Models;
using Notes.Presentation.Clients;
using System.Threading.Tasks;

namespace Notes.Presentation.Controllers
{
	public class HomeController : Controller
	{
		private readonly INoteClient _noteClient;

		public HomeController(INoteClient noteClient)
		{
			_noteClient = noteClient;
		}
		
		[HttpGet]
		public async Task<IActionResult> Notes()
		{
			var notes = await _noteClient.GetAll();
			return View(notes);
		}

		[HttpGet]
		public async Task<IActionResult> Note(int id)
		{
			var note = await _noteClient.Get(id);
			return View(note);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(NoteDto note)
		{
			await _noteClient.Create(note);
			return RedirectToAction("Notes");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await _noteClient.Delete(id);
			return RedirectToAction("Notes");
		}
	}
}
