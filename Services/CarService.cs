using System;
using System.Collections.Generic;
using gregslist2.Models.cs;
using gregslist2.Repositories;

namespace gregslist2.Services
{
    public class CarService
    {

        private readonly CarRepository _repo;

        public CarService(CarRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Car> Get()
        {
            return _repo.Get();
        }

        internal Car Create(Car newCar)
        {
            return _repo.Create(newCar);
        }

        internal Car Get(int id)
        {
            Car car = _repo.Get(id);
            if (car == null)
            {
                throw new Exception("invalid id");
            }
            return car;
        }

        internal object EditCar(Car editCar)
        {
            throw new NotImplementedException();
        }
        internal Car Delete(int id)
        {
            Car original = Get(id);
            _repo.Delete(id);
            return original;
        }

    }
}