using AustPIC.Models;
using AustPIC.Models.ViewModels;
using AustPICWeb.Repositories.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AustPICWeb.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogRepository _testService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(IBlogRepository testService, IWebHostEnvironment webHostEnvironment)
        {
            _testService = testService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(string category, string date)
        {
            //var blogTop2 = await _testService.GetTop2BlogList();
            //var topblog = await _testService.GetTopBlog();
            var categoryList = await _testService.GetBlogCategoryList();
            var dateList = await _testService.GetBlogDateList();
            if (category != null)
            {
                ViewBag.Category = category;
                var blogList = await _testService.GetBlogListByCategory(category);
                var model = new BlogViewModel { blogList = blogList, category = categoryList, date = dateList };

                return View(model);
            }
            else if (date != null)
            {
                ViewBag.Date = date;
                var blogList = await _testService.GetBlogListByDate(date);
                var model = new BlogViewModel { blogList = blogList, category = categoryList, date = dateList };

                return View(model);
            }
            else
            {
                var blogList = await _testService.GetBlogList();
                var model = new BlogViewModel { blogList = blogList, category = categoryList, date = dateList };

                return View(model);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var categoryList = await _testService.GetBlogCategoryList();
            var dateList = await _testService.GetBlogDateList();
            ViewBag.Category = categoryList;
            ViewBag.Date = dateList;
            var detail = await _testService.GetBlogDetail(id);
            return View(detail);
        }

        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(BlogModel blog, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && img.Length > 0)
                {
                    string folder = "blogs/image/";
                    folder += Guid.NewGuid().ToString() + "_" + img.FileName;

                    blog.BlogImg = folder;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await img.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                await _testService.AddBlogDetail(blog);
                return Ok();
            }

            return View(blog);
        }


    }
}
