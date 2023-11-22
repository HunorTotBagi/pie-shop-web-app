using BethanysPieShop.Models.Interfaces;
using Microsoft.AspNetCore.Http;
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

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

        }
    }
}
