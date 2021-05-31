using spinFrameMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaces.spinFrameMvc
{
    public interface ICarManager
    {
        void AddNewCar(Car newCar);
        void DeleteCar(string carPlate);
        Car GetCarByPlate(string carPlate);
        void UpdateCar(string plate, CarColor color, CarManufactor manufactor, string model, int year);
        List<Car> GetAllCars();
    }
}
