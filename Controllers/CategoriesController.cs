using ContentsLimitInsurance.Interfaces;
using ContentsLimitInsurance.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContentsLimitInsurance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private ISvcCategories SvcCategories { get; set; }

        public CategoriesController(ISvcCategories svcCategories)
        {
            SvcCategories = svcCategories;
        }

        [HttpGet]
        public List<Category> GetCategories()
        {
            return SvcCategories.GetCategories();
        }
    }
}
