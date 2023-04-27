using AustPIC.db.DbOperations;
using AustPIC.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace AustPICWeb.Controllers
{
    public class ContactController : Controller
    {
        ContactRepository ContactRepository = null;

        public ContactController()
        {
            ContactRepository = new ContactRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                int id = ContactRepository.AddContact(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.success = "Data Added";
                }
            }
            return View();
        }
    }
}
