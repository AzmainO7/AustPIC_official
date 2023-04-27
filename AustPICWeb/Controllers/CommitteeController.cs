using AustPICWeb.Repositories;
using AustPICWeb.Repositories.Committee;
using Microsoft.AspNetCore.Mvc;

namespace AustPICWeb.Controllers
{
    public class CommitteeController : Controller
    {
        private readonly ICommitteeRepository _testService;
        public CommitteeController(ICommitteeRepository testService)
        {
            _testService = testService;
        }

        //public async Task<IActionResult> Index()
        //{
        //    //var committee = repository.GetCommitteeData();
        //    var committee = await _testService.GetMemberList();

        //    return View(committee);
        //}

        public async Task<IActionResult> Index(String id)
        {
            ViewBag.Semester = id;
            var committee = await _testService.GetMemberListBySemester(id);
            return View(committee);
        }
    }
}
