using interfaces.spinFrameMvc;
using spinFrameMvc.DB;
using spinFrameMvc.Models;
using spinFrameMvc.Models.Errors;
using spinFrameMvc.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spinFrameMvc.Repository
{
    public class CarsManager : ICarManager
    {
        public void AddNewCar(Car newCar)
        {
            using (var dbContext = new CarDbContext())
            {
                if (dbContext.Cars.FirstOrDefault(c => c.CarPlate == newCar.CarPlate) != null)
                {
                    throw new PlateAlreadyExistException();
                }
                dbContext.Cars.Add(newCar);
                dbContext.SaveChanges();
            }
        }

        public void DeleteCar(string carPlate)
        {
            using (var dbContext = new CarDbContext())
            {
                Car carToDelete = dbContext.Cars.FirstOrDefault(c => c.CarPlate == carPlate);
                if (carToDelete == null)
                {
                    throw new CarNotFoundException();
                }

                dbContext.Cars.Remove(carToDelete);
                dbContext.SaveChanges();
            }
        }

        public Car GetCarByPlate(string carPlate)
        {
            Car result;
            using (var dbContext = new CarDbContext())
            {
                result = dbContext.Cars.FirstOrDefault(c => c.CarPlate == carPlate);
                if (result == null)
                {
                    throw new CarNotFoundException();
                }
            }

            return result;
        }

        public List<Car> GetAllCars()
        {
            List<Car> cars;

            using (var dbCoontext = new CarDbContext())
            {
                cars = dbCoontext.Cars.ToList();
            }

            return cars;
        }

        public void UpdateCar(string plate, CarColor color, CarManufactor manufactor, string model, int year)
        {
            using (var dbCoontext = new CarDbContext())
            {
                Car car = dbCoontext.Cars.FirstOrDefault(c => c.CarPlate == plate);
                if (car == null)
                {
                    throw new CarNotFoundException();
                }

                car.Color = color;
                car.Manufactor = manufactor;
                car.Model = model;
                car.Year = year;

                dbCoontext.SaveChanges();
            }
        }
    }
}