using CoreBookStore.Services;
using CoreBookStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreBookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IBookLanguageService _bookLanguageService;
        private readonly IPublisherService _publisherService;
        private readonly IAuthorService _authorService;

        public BookController(IBookService bookService, IBookLanguageService bookLanguageService, IPublisherService publisherService, IAuthorService authorService)
        {
            _bookService = bookService;
            _bookLanguageService = bookLanguageService;
            _publisherService = publisherService;
            _authorService = authorService;
        }
        // GET: BookController
        public async Task<IActionResult> Index()
        {
            return View(await _bookService.GetAllBooks());
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {

            BookViewModel bookViewModel = new BookViewModel
            {

                Languages = _bookLanguageService.GetBookLanguages().Result,
                Publishers = _publisherService.GetAllPublishers().Result,
                Authors = _authorService.GetAllAuthors().Result
                
            };

            return View(bookViewModel);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public async Task<IActionResult> Create(BookViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var book = model.BookModel;
                    book.AuthorId = model.SelectedAuthor;
                    book.PublisherId = model.SelectedPublisher;
                    book.LanguageId = model.SelectedLanguage;

                    book.CreatedBy = "BookStoreAdmin";
                    book.CreatedOn = DateTime.UtcNow;
                    book.ModifiedBy = "BookStoreAdmin";
                    book.ModifiedOn = DateTime.UtcNow;

                    await _bookService.CreateBookAsync(book);

                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(model.BookModel);
        }

        // GET: BookController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookById(id);
            BookViewModel bookViewModel = new()
            {
                BookModel = book,
                Languages = _bookLanguageService.GetBookLanguages().Result,
                Publishers = _publisherService.GetAllPublishers().Result,
                Authors = _authorService.GetAllAuthors().Result,
                SelectedAuthor = book.AuthorId,
                SelectedLanguage = book.LanguageId,
                SelectedPublisher = book.PublisherId                
            };

            return View(bookViewModel);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookViewModel model)
        {
            try
            {
                var book = model.BookModel;
                book.AuthorId = model.SelectedAuthor;
                book.PublisherId = model.SelectedPublisher;
                book.LanguageId = model.SelectedLanguage;
                book.ModifiedOn = DateTime.UtcNow;
                book.ModifiedBy = "BookStoreAdmin";

                await _bookService.UpdateBookAsync(book);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var book = await _bookService.GetBookById(id);
                await _bookService.DeleteBookAsync(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: BookController/Delete/5
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
