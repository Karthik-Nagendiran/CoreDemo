﻿using CoreBookStore.Services;
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

        public BookController(IBookService bookService, IBookLanguageService bookLanguageService, IPublisherService publisherService)
        {
            _bookService = bookService;
            _bookLanguageService = bookLanguageService;
            _publisherService = publisherService;
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
                Publishers = _publisherService.GetAllPublishers().Result
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
