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

        [HttpGet]
        public IActionResult All()
        {
            var posts = context.Posts
                .Where(p => p.IsDelete == false)
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToList();

            return View(posts);
        }

        [HttpGet]
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


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = context.Posts.Find(id);

            return View(new PostViewModel()
            {
                Title = post.Title,
                Content = post.Content,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var post = await context.Posts.FindAsync(id);

            if (post != null)
            {
                post.Title = model.Title;
                post.Content = model.Content;
            }

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) 
        {
            var post = await context.Posts.FindAsync(id);

            if (post != null)
            {
                post.IsDelete = true;  // Set IsDelete Flag = True
                await context.SaveChangesAsync();

                //context.Posts.Remove(post); Delete directly from database
                //context.SaveChanges();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
