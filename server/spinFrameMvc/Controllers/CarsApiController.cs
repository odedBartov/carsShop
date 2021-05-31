using interfaces.spinFrameMvc;
using spinFrameMvc.Models;
using spinFrameMvc.Models.Exceptions;
using spinFrameMvc.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace spinFrameMvc.Controllers
{
    public class CarsApiController : ApiController
    {
        ICarManager carManager;
        public CarsApiController(ICarManager _carManager)
        {
            carManager = _carManager;
        }

        public List<Car> GetAllCars()
        {
            return carManager.GetAllCars();
        }

        public IHttpActionResult GetCarByPlate(string plate)
        {
            try
            {
                return Ok(carManager.GetCarByPlate(plate));
            }
            catch (CarNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
