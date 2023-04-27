using AustPIC.db.DbOperations;
using AustPICWeb.Repositories.Gallery;
using Microsoft.AspNetCore.Mvc;

namespace AustPICWeb.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IGalleryRepository _testService;

        public GalleryController(IGalleryRepository testService)
        {
            _testService = testService;
        }

        public async Task<IActionResult> Index()
        {
            var gallery = await _testService.GetGalleryList();

            return View(gallery);
        }
    }
}
