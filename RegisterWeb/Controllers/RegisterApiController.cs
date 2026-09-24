using Microsoft.AspNetCore.Mvc;
using RegisterWeb.Models;
using RegisterWeb.Repositories;
using RegisterWeb.ViewModels;

namespace RegisterWeb.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class RegisterApiController : ControllerBase
    {
        private readonly PersonRepository _personRepository;

        public RegisterApiController(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpPost]
        public IActionResult Create(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = new Person
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone,
                BirthDate = model.BirthDate,
                OccupationId = model.OccupationId,
                Sex = model.Sex,
                Profile = model.Profile
            };

            var personId = _personRepository.Create(person);

            return Ok(new
            {
                id = personId,
                message = "Save succeeded."
            });
        }
    }
}