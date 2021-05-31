using interfaces.spinFrameMvc;
using spinFrameMvc.Models;
using spinFrameMvc.Models.Errors;
using spinFrameMvc.Models.Exceptions;
using spinFrameMvc.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace spinFrameMvc.Controllers
{
    public class HomeController : Controller
    {
        ICarManager carManager;
        public HomeController(ICarManager _carManager)
        {
            carManager = _carManager;
        }

        public ActionResult Index()
         {
            return View(carManager.GetAllCars());
        }

        public ActionResult AddCar(string plate, CarColor color, CarManufactor manufactor, string model, int year)
        {
            Car newCar = new Car()
            {
                CarPlate = plate,
                Color = color,
                Manufactor = manufactor,
                Model = model,
                Year = year
            };
            try
            {
                carManager.AddNewCar(newCar);

                return RedirectToAction("Index");
            }
            catch (PlateAlreadyExistException)
            {
                TempData["carAlreadyExist"] = true;

                return RedirectToAction("Index");
            }
        }

        public ActionResult UpdateCar(string plate, CarColor Color, CarManufactor manufactor, string model, int year)
        {
            try
            {
                carManager.UpdateCar(plate, Color, manufactor, model, year);
                return RedirectToAction("Index");
            }
            catch (CarNotFoundException)
            {
                TempData["carNotFound"] = true;

                return RedirectToAction("Index");
            }
        }

        public ActionResult DeleteCar(string carPlate)
        {
            carManager.DeleteCar(carPlate);
            return RedirectToAction("Index");
        }

        public ActionResult OpenAddNewCar()
        {
            return PartialView("addCarPartialView", new Car());
        }

        public ActionResult OpenDeleteCar(string carPlate)
        {
            return PartialView("deleteCarPartialView", carPlate);
        }

        public ActionResult OpenDetails(string carPlate)
        {
            return PartialView("detailsPartialView", carManager.GetCarByPlate(carPlate));
        }

        public List<Car> GetAllCars()
        {
            return carManager.GetAllCars();
        }
    }
}