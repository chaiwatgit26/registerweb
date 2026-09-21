using Microsoft.AspNetCore.Mvc;
using RegisterWeb.Repositories;

namespace RegisterWeb.Controllers
{
    public class RegisterController : Controller
    {
        private readonly OccupationRepository _occupationRepository;

        public RegisterController(
            OccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        public IActionResult Index()
        {
            var occupations = _occupationRepository.GetAll();

            return View(occupations);
        }
    }
}