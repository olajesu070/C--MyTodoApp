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
            ViewBag.currentView = "Index";
            var todos = await _todoService.GetAsync();
            return View(todos);
        }

        public IActionResult Create()
        {
            ViewBag.currentView = "Create";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Todo todo)
        {
            ViewBag.currentView = "Create";
            if (ModelState.IsValid)
            {
                await _todoService.CreateAsync(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.currentView = "Edit";
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
            ViewBag.currentView = "Edit";
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
            ViewBag.currentView = "Delete";
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
            ViewBag.currentView = "Index"; // Toggle action returns to Index view
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
