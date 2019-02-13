// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------
using Everis.Polar.Mvc.Infrastructure;
using Everis.Polar.Mvc.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Everis.Polar.Mvc.ViewModels;
using Everis.Polar.Mvc.Models;
using AutoMapper;

namespace Everis.Polar.Mvc.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IHttpClient _httpClient;
        private readonly IOptions<AppSettings> _settings;
        private readonly IMapper _mapper;
        private readonly string _serviceUrl;

        public AuthorsController(IOptions<AppSettings> settings, IHttpClient httpClient, IMapper mapper)
        {
            _settings = settings;
            _httpClient = httpClient;
            _mapper = mapper;
            _serviceUrl = $"{_settings.Value.Services.BaseUrl}/authors";
        }

        // TODO: Uncomment to use Caching !!!
        // [ResponseCache(Duration =15, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStringAsync(_serviceUrl);
            var authors = JsonConvert.DeserializeObject<IEnumerable<Author>>(response);
            ViewBag.ShowActions = true;
            return View(authors);
        }

        private async Task<Author> GetAuthor(int id)
        {
            var response = await _httpClient.GetStringAsync($"{_serviceUrl}/{id}");
            var author = JsonConvert.DeserializeObject<Author>(response);
            return author;
        }

        public async Task<IActionResult> Details(int id)
        {
            Author author = await GetAuthor(id);
            return View(author);
        }

        public async Task<IActionResult> Edit(int id)
        {
            return await Details(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(nameof(Author.AuthorId), "Name", "Email", "Gender", "IsDeleted")] Author author)
        {
            await _httpClient.PutAsync($"{_serviceUrl}/{id}", author);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            Author author = new Author() { };
            await Task.CompletedTask;
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind(nameof(Author.AuthorId), nameof(Author.Name), nameof(Author.Email), nameof(Author.Gender), nameof(Author.IsDeleted))] Author author)
        {
            await _httpClient.PostAsync($"{_serviceUrl}/{id}", author);
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]        
        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"{_serviceUrl}/{id}");
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
