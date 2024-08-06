using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MyTodoApp.Models;
using MyTodoApp.Services;
using System.Threading.Tasks;

namespace MyTodoApp.Controllers
{
    public class TodosController : Controller
    {
        private readonly TodoService _todoService;

        public TodosController(TodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<IActionResult> Index()
        {
            var todos = await _todoService.GetAsync();
            return View(todos);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Todo todo)
        {
            if (ModelState.IsValid)
            {
                await _todoService.CreateAsync(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var todo = await _todoService.GetAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Todo todo)
        {
            if (new ObjectId(id) != todo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _todoService.UpdateAsync(id, todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var todo = await _todoService.GetAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            await _todoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ToggleCompleted(string id)
        {
            var todo = await _todoService.GetAsync(id);
            if (todo != null)
            {
                todo.Completed = !todo.Completed;
                await _todoService.UpdateAsync(id, todo);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
