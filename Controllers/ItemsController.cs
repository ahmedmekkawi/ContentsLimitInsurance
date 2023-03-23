using ContentsLimitInsurance.Interfaces;
using ContentsLimitInsurance.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContentsLimitInsurance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private ISvcItems SvcItems { get; set; }

        public ItemsController(ISvcItems svcItems)
        {
            SvcItems = svcItems;
        }

        [HttpGet]
        public List<Item> GetItems()
        {
            return SvcItems.GetItems();
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteItem(int id)
        {
            SvcItems.DeleteItem(id);
        }

        [HttpPut]
        public void AddItem([FromBody] Item item)
        {
            SvcItems.AddItem(item);
        }

    }
}
