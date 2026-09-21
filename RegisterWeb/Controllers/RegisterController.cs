using Microsoft.AspNetCore.Mvc;
using RegisterWeb.Repositories;
using RegisterWeb.Models;
using RegisterWeb.ViewModels;

namespace RegisterWeb.Controllers
{
    public class RegisterController : Controller
    {
        private readonly OccupationRepository _occupationRepository;
        private readonly PersonRepository _personRepository;

        public RegisterController(
            OccupationRepository occupationRepository,
            PersonRepository personRepository)
        {
            _occupationRepository = occupationRepository;
            _personRepository = personRepository;
        }

        public IActionResult Index()
        {
            var occupations = _occupationRepository.GetAll();

            return View(occupations);
        }

        [HttpPost]
        public IActionResult Create(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var occupations = _occupationRepository.GetAll();

                return View("Index", occupations);
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

            return RedirectToAction("Index");
        }
    }
}