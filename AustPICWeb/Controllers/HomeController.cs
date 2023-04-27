using AustPIC.db.DbOperations;
using AustPIC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AustPIC.Models.ViewModels;
using AustPICWeb.Repositories.Committee;

namespace AustPICWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommitteeRepository _testService;
        public HomeController(ICommitteeRepository testService)
        {
            _testService = testService;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public async Task<IActionResult> Index()
        {
            //var committee = repository.GetCommitteeData();
            var committee = await _testService.GetTopMemberList();
            //ViewData["NavbarColor"] = "#37517e";

            return View(committee);
        }

        //public IActionResult Index()
        //{
        //    var committee = repository.GetCommitteeData();
        //    return View(committee);
        //}     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}