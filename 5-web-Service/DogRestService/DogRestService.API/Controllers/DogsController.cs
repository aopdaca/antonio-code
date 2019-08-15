using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogRestService.API.Models;
using DogRestService.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogRestService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly DogRepository dogRepository;

        public DogsController(DogRepository dogRepository)
        {
            this.dogRepository = dogRepository ?? throw new ArgumentNullException(nameof(dogRepository));
        }

        // GET: api/Dogs
        [HttpGet]
        public IActionResult Get()
        {
            var dogs = dogRepository.GetAll().Select(dog => new ApiDog {
                Id = dog.Id,
                Name = dog.Name
            });
            return Ok(dogs); // "OkResult" - 200 OK, with response body (automatically serialized).
        }

        // GET: api/Dogs/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<ApiDog> Get(int id)
        {
            if (dogRepository.Get(id) is Dog dog)
            {
                // convenience of ActionResult<T> return type (implemented via custom implicit cast)...
                // can return an IActionResult, or, a T (wrapped in OkResult)
                return new ApiDog
                {
                    Id = dog.Id,
                    Name = dog.Name
                };
            }
            return NotFound();
        }

        // POST: api/Dogs
        [HttpPost]
        public IActionResult Post([FromBody] ApiDog apiDog) // model binding still works the time
        {
            // via [ApiController] attribute, we automatically get server-side validation based on ModelState
            // from any DataAnnotations, resulting in automatic 400 response.
            var dog = new Dog { Name = apiDog.Name };
            var newId = dogRepository.Create(dog);
            return CreatedAtRoute("Get", new { id = newId }, dogRepository.Get(newId));
        }

        // PUT: api/Dogs/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {
            NoContent();
            BadRequest();//if failed validation
            NotFound();//if id does not exist
            var dog = dogRepository.Get(id);
            dog.Name = name;
            //return Put
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            NoContent();
            BadRequest();//if failed validation
        }
    }
}
