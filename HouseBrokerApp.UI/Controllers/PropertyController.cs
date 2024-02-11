using HouseBroker.Application.Interfaces;
using HouseBroker.Domain.Entities;
using HouseBroker.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HouseBrokerApp.UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IPropertyTypeRepository _propertyTypeRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PropertyController(IPropertyRepository propertyRepository, ILocationRepository locationRepository, IPropertyTypeRepository propertyTypeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _propertyRepository = propertyRepository;
            _locationRepository = locationRepository;
            _propertyTypeRepository = propertyTypeRepository;
            _hostingEnvironment = webHostEnvironment;
        }

        public IActionResult Index(int? propertyTypeId, int? locationId)
        {
            List<Location> locationList = _locationRepository.GetAllLocations();
            ViewBag.LocationList = locationList;

            List<PropertyType> propertyTypes = _propertyTypeRepository.GetAllPropertyTypes();
            ViewBag.PropertyTypeList = propertyTypes;
            //ViewBag.PropertyTypeList = new SelectList(propertyTypes, "PropertyTypeId", "PropertyTypeName");

            var data = _propertyRepository.GetAllPropertyList();

            if (propertyTypeId.HasValue)
            {
                var pData = data.Where(p => p.PropertyTypeId == propertyTypeId).ToList();
                if(pData.Count()>0)
                {
                    data= pData;
                }
                else
                {
                    TempData["ErrorMessage"] = "No record found";
                }
            }

            if (locationId.HasValue)
            {
                var lData = data.Where(p => p.LocationId == locationId).ToList();
                if (lData.Count() > 0)
                {
                    data = lData;
                }
                else
                {
                    TempData["ErrorMessage"] = "No record found";
                }

            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Location> locationList = _locationRepository.GetAllLocations();
            var locationLists = new SelectList(locationList, "LocationId", "LocationName");
            ViewBag.LocationList = locationLists;
            List<PropertyType> propertyTypes = _propertyTypeRepository.GetAllPropertyTypes();
            var proprtyTypeList = new SelectList(propertyTypes, "Id", "PropertyTypeName");
            ViewBag.PropertyTypeList = proprtyTypeList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Property model)
        {
            int result = _propertyRepository.AddProperty(model);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }

            else
            {
                TempData["message"] = "Failed to add record";
                return View(model);
            }

            //var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

            //if (!Directory.Exists(uploadsDirectory))
            //{
            //    Directory.CreateDirectory(uploadsDirectory);
            //}

            //var fileName = "test";
            //var filePath = Path.Combine(uploadsDirectory, model.Image.FileName);

            //using (var fileStream = new FileStream(filePath, FileMode.Create))
            //{
            //    model.Image.CopyTo(fileStream);
            //}

            //int result = _propertyRepository.AddProperty(model);
            //if (result > 0)
            //{
            //    return RedirectToAction("Index");
            //}

            //else
            //{
            //    TempData["message"] = "Failed to add record";
            //    return View(model);
            //}

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            List<Location> locationList = _locationRepository.GetAllLocations();
            var locationLists = new SelectList(locationList, "LocationId", "LocationName");
            ViewBag.LocationList = locationLists;
            List<PropertyType> propertyTypes = _propertyTypeRepository.GetAllPropertyTypes();
            var proprtyTypeList = new SelectList(propertyTypes, "Id", "PropertyTypeName");
            ViewBag.PropertyTypeList = proprtyTypeList;
            var data = _propertyRepository.GetPropertyById(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Property model)
        {
            int result = _propertyRepository.UpdateProperty(model);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }

            else
            {
                TempData["message"] = "Failed to update record. Please review data and try again";
                return View(model);
            }

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            int result = _propertyRepository.DeleteProperty(id);
            if (result > 0)
            {
                TempData["message"] = "Record deleted successfully";
                
            }
            else
            {
                TempData["message"] = "Failed to delete record";
                
            }
            return RedirectToAction("Index");
        }

        private string UploadImage(IFormFile image)
        {
            var uploadsDirectory = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            var filePath = Path.Combine(uploadsDirectory, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
    }
}
