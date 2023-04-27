using AustPICWeb.Repositories.Contest;
using AustPICWeb.Repositories.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AustPICWeb.Controllers
{
    [Authorize]
    public class ContestController : Controller
    {
        private readonly IContestRepository _testService;

        public ContestController(IContestRepository testService)
        {
            _testService = testService;
        }

        public async Task<IActionResult> Index()
        {
            var contests = await _testService.GetContestList();
            return View(contests);
        }

        public async Task<IActionResult> Details(int id)
        {
            var detail = await _testService.GetContestDetail(id);
            return View(detail);
        }
    }
}
