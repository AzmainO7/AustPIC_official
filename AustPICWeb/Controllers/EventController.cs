using AustPIC.db.DbOperations;
using AustPICWeb.Repositories.Event;
using AustPICWeb.Repositories.Gallery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AustPICWeb.Controllers
{
    [Authorize] 
    public class EventController : Controller
    {
        private readonly IEventRepository _testService;

        public EventController(IEventRepository testService)
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
