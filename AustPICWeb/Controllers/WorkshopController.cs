using AustPIC.db.DbOperations;
using AustPICWeb.Repositories.Event;
using Microsoft.AspNetCore.Mvc;

namespace AustPICWeb.Controllers
{
    public class WorkshopController : Controller
    {
        private readonly IEventRepository _testService;

        public WorkshopController(IEventRepository testService)
        {
            _testService = testService;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _testService.GetEventList();
            return View(events);
        }

        public async Task<IActionResult> Details(int id)
        {
            var detail = await _testService.GetEventDetail(id);
            return View(detail);
        }
    }
}
