// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------
using AutoMapper;
using Everis.Polar.Mvc.Infrastructure;
using Everis.Polar.Mvc.Models;
using Everis.Polar.Mvc.Settings;
using Everis.Polar.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everis.Polar.Mvc.Controllers
{
    public class BooksController : Controller
    {
        private readonly IHttpClient _httpClient;
        private readonly IOptions<AppSettings> _settings;
        private readonly IMapper _mapper;
        private readonly string _serviceUrl;


        public BooksController(IOptions<AppSettings> settings, IHttpClient httpClient, IMapper mapper)
        {
            _settings = settings;
            _httpClient = httpClient;
            _mapper = mapper;

            _serviceUrl = $"{_settings.Value.Services.BaseUrl}/books";
        }

        // TODO: Uncomment to use Caching !!!
        // [ResponseCache(Duration =15, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStringAsync(_serviceUrl);
            var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(response);
            ViewBag.ShowActions = true;
            return View(books);
        }

        private async Task<Book> GetBook(int id)
        {
            var response = await _httpClient.GetStringAsync($"{_serviceUrl}/{id}");
            var book = JsonConvert.DeserializeObject<Book>(response);
            return book;
        }

        public async Task<IActionResult> Details(int id)
        {
            Book book = await GetBook(id);
            return View(book);
        }

        public async Task<IActionResult> Edit(int id)
        {         
            return await Details(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, 
            [Bind(nameof(Book.BookId), nameof(Book.Title), nameof(Book.Language), nameof(Book.NumPages), nameof(Book.Format), nameof(Book.Isbn))] Book book)
        {
            // await _httpClient.PutAsync($"{_serviceUrl}/{id}", book);

            book.Authors = null;
            await _httpClient.PatchAsync($"{_serviceUrl}/{id}", book);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            Book book = new Book() { };
            await Task.CompletedTask;
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            int id,
            [Bind(nameof(Book.BookId), nameof(Book.Title), nameof(Book.Language), nameof(Book.NumPages), nameof(Book.Format), nameof(Book.Isbn))] Book book)
        {
            await _httpClient.PostAsync($"{_serviceUrl}/{id}", book);
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]        
        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"{_serviceUrl}/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
