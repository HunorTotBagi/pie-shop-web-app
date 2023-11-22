using BethanysPieShop.Models;
using BethanysPieShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository _pieRepositroy;

        public SearchController(IPieRepository pieRepositroy)
        {
            _pieRepositroy = pieRepositroy;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allPies = _pieRepositroy.AllPies;
            return Ok(allPies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_pieRepositroy.AllPies.Any(p => p.PieId == id))
                return NotFound();
            return Ok(_pieRepositroy.AllPies.Where(p => p.PieId == id));
        }

        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchQuery)
        {
            IEnumerable<Pie> pies = new List<Pie>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                pies = _pieRepositroy.SearchPies(searchQuery);
            }
            return new JsonResult(pies);
        }
    }
}
