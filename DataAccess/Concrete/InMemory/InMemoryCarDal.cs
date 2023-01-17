using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {

            new Car { Id = 1, BrandId = "Audi", ColorId = 1, ModelYear = 2018, DailyPrice = 1000000, Description = "Şık ve Sade..." },
            new Car { Id = 2, BrandId = "Renault", ColorId = 2, ModelYear = 2014, DailyPrice = 280000, Description = "Dosta Gider..." },
            new Car { Id = 3, BrandId = "BMW", ColorId = 1, ModelYear = 2017, DailyPrice = 900000, Description = "Canavar..." },
            new Car { Id = 4, BrandId = "Mercedes", ColorId = 3, ModelYear = 2023, DailyPrice = 1000000, Description = "Krallara Layık..." },
            new Car { Id = 5, BrandId = "Fiat", ColorId = 4, ModelYear = 2011, DailyPrice = 250000, Description = "Aile Aracı..." }

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}

