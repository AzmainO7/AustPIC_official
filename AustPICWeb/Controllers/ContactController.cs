using AustPIC.db.DbOperations;
using AustPIC.Models;
using AustPICWeb.Repositories.CssVariable;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace AustPICWeb.Controllers
{
    public class ContactController : Controller
    {
        //ContactRepository ContactRepository = null;
        private readonly ICssRepository _cssRepository;

        //public ContactController()
        //{
        //    ContactRepository = new ContactRepository();
        //}

        public ContactController(ICssRepository cssRepository)
        {
            _cssRepository = cssRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cssVariables = await _cssRepository.GetCssVariablesList();
            ViewBag.CssVariables = cssVariables;
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(ContactModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        int id = ContactRepository.AddContact(model);
        //        if (id > 0)
        //        {
        //            ModelState.Clear();
        //            ViewBag.success = "Data Added";
        //        }
        //    }
        //    var cssVariables = await _cssRepository.GetCssVariablesList();
        //    ViewBag.CssVariables = cssVariables;
        //    return View();
        //}
    }
}
