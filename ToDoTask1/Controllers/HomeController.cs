using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoApp.Business.Interfaces;
using ToDoApp.Dtos1.Dtos;
using ToDoTask1.Models;
using ToDoApp.Extention;


namespace ToDoTask1.Controllers
{
    public class HomeController : Controller
    {

        private readonly INoteService _workService;

        public HomeController(INoteService noteService)
        {
            _workService = noteService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _workService.GetAll();
            return this.ResponseView(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NoteCreateDto dto)
        {
            var response = await _workService.Create(dto);
            return this.ResponseRedirectToAction(response, "Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var response = await _workService.GetByİd<NoteUpdateDto>(id);

            return this.ResponseView(response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(NoteUpdateDto dto)
        {
            var response = await _workService.Update(dto);

            return this.ResponseRedirectToAction(response, "Index");

        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _workService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult NotFound(int code)
        {
            return View();
        }
    }


}
