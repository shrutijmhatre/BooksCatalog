using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BookCatalogNew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogNew.Controllers
{
  

    [Route("Review")]
    public class ReviewController : Controller
    {
        private readonly ReviewDataContext _db;

        public ReviewController(ReviewDataContext db)
        {
            _db = db;
        }

        [Route("")]
        public IActionResult Index()
        {
            var posts = _db.Posts.OrderByDescending(x => x.Posted).Take(5).ToArray();
            
            return View(posts);
        }

       
        [Route("{year:min(2020)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = _db.Posts.FirstOrDefault(x => x.Key == key);
            return View(post);
        }

        
        [Authorize]
        [HttpGet, Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost, Route("Create")]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View();

            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;

            _db.Posts.Add(post);
            _db.SaveChanges();

            return RedirectToAction("Post", "Review", new
            {
                year = post.Posted.Year,
                month = post.Posted.Month,
                key = post.Key
            }
                );
        }

    }
}
