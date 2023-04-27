using AustPICWeb.Repositories.Contest;
using Microsoft.AspNetCore.Mvc;

namespace AustPICWeb.Controllers
{
    public class NewsController : Controller
    {
        private readonly IContestRepository _testService;

        public NewsController(IContestRepository testService)
        {
            _testService = testService;
        }

        public async Task<IActionResult> Index()
        {
            var contests = await _testService.GetContestList();
            return View(contests);
        }

    }
}
