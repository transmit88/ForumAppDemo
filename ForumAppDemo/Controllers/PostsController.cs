using ForumAppDemo.Data;
using ForumAppDemo.Data.Models;
using ForumAppDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumAppDemo.Controllers
{
    public class PostsController : Controller
    {
        private readonly ForumAppDemoDbContext context;

        public PostsController(ForumAppDemoDbContext _context)
            => this.context = _context;

        public IActionResult All()
        {
            var posts = context.Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToList();

            return View(posts);
        }

        public IActionResult Add()
            => View();

        [HttpPost]
        public IActionResult Add(PostViewModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content,
            };

            context.Posts.Add(post);
            context.SaveChanges();

            return RedirectToAction("All");
        }
    }
}
