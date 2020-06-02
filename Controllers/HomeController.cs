using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _03EfCoreDemo.Models;
using _03EfCoreDemo.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace _03EfCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EfCoreContext _context;

        public HomeController(ILogger<HomeController> logger,
            EfCoreContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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

        // Demo
        public IActionResult AddSingle()
        {
            var rand = new Random();

            var itemToAdd = new Author
            {
                Name = "Hello World " + rand.Next()
            };

            _context.Add(itemToAdd);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddBook()
        {
            var rand = new Random();

            var book = new Book
            {
                Title = "Test Book" + rand.Next(),
                PublishedOn = DateTime.Today,
                Reviews = new List<Review>()
                {
                    new Review
                    {
                        NumStars = 5,
                        Comment = "Great test book!" + rand.Next(),
                        VoterName = "Mr U Test" + rand.Next()
                    }
                }
            };

            _context.Add(book);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddBookWithExistedAuthor()
        {
            var rand = new Random();

            var author = _context.Authors.First();

            var book = new Book
            {
                Title = "Test Book" + rand.Next(),
                PublishedOn = DateTime.Today
            };

            book.AuthorsLink = new List<BookAuthor>
            {
                new BookAuthor
                {
                    Book = book,
                    Author = author
                }
            };

            _context.Add(book);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
