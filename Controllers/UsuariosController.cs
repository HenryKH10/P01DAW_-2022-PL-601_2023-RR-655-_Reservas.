using Microsoft.AspNetCore.Mvc;

namespace P01_2022_PL_601_2023_RR_655.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
