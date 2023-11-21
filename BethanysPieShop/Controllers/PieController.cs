using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRespotory;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRespotory = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            ViewBag.CurrentCategory = "Cheese cakes";
            return View(_pieRespotory.AllPies);
        }
    }
}
