using System.Collections.Generic;
using gregslist2.Models.cs;
using Microsoft.AspNetCore.Mvc;

namespace gregslist2.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                return Ok(FakeDB.Cars);
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                FakeDB.Cars.Add(newCar);
                return Ok(newCar);
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpGet("{carId}")]
        public ActionResult<Car> GetCar(string carId)
        {
            try
            {
                Car carFound = FakeDB.Cars.Find(c => c.Id == carId);
                if (carFound == null)
                {
                    throw new System.Exception("Car does not exist");
                }
                return Ok(carFound);
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{carId}")]
        public ActionResult<string> DeleteCar(string carId)
        {
            try
            {
                Car carToDelete = FakeDB.Cars.Find(c => c.Id == carId);
                if (FakeDB.Cars.Remove(carToDelete))
                {
                    return Ok("Car Removed");
                }
                else
                {
                    throw new System.Exception("This car does not exist yo.");
                }
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpPut("{carId}")]
        public ActionResult<string> EditCar(string carId, Car otherCar)
        {
            try
            {
                Car updatedCar = FakeDB.Cars.Find(c => c.Id == carId);
                if (updatedCar == null)
                {
                    throw new System.Exception("Car does not exist");
                }
                updatedCar.Make = otherCar.Make;
                updatedCar.Model = otherCar.Model;
                updatedCar.Year = otherCar.Year;
                updatedCar.Color = otherCar.Color;

                return Ok(updatedCar);
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }

    }

}