using Microsoft.AspNetCore.Mvc;

namespace PetGateway.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
