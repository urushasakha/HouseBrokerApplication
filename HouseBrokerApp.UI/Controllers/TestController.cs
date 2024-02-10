using HouseBroker.Application.Interfaces;
using HouseBroker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HouseBrokerApp.UI.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestRepository _testRepository;

        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public IActionResult Index()
        {
            var data = _testRepository.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Create(TestTable model)
        {
            int result = _testRepository.Create(model);
            if (result>0)
            {
                TempData["message"] = "Record saved successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Failed to add record";
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _testRepository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(TestTable model)
        {
            return RedirectToAction("Index");
        }
    }
}
