using System.Collections.Generic;
using gregslist2.Models.cs;
using gregslist2.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslist2.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {

        private readonly CarService _service;

        public CarsController(CarService service)
        {
            _service = service;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                return Ok(_service.Get());
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
                return Ok(_service.Create(newCar));
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Car> DeleteCar(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Car> Edit([FromBody] Car editCar, int id)
        {
            try
            {
                editCar.Id = id;
                return Ok(_service.Edit(editCar));
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }

    }

}