using CoreBookStore.Models;
using CoreBookStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreBookStore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: AuthorController
        public async Task<IActionResult> Index()
        {
            return View(await _authorService.GetAuthorsAsync());
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.IsDeleted = false;
                    model.CreatedOn = model.ModifiedOn = DateTime.UtcNow;
                    model.CreatedBy = model.ModifiedBy = "BookStoreAdmin";

                    await _authorService.CreateAuthorAsync(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {            
            return View(await _authorService.GetAuthorByIdAsync(id));
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Edit(Author model)
        {
            try
            {
                model.ModifiedOn = DateTime.UtcNow;
                model.ModifiedBy = "BookStoreAdmin";
                await _authorService.UpdateAuhtorAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            await _authorService.DeleteAuthorAsync(author);
            return RedirectToAction(nameof(Index)); 
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
