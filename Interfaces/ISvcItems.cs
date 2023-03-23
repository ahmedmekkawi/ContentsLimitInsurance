using ContentsLimitInsurance.Models;

namespace ContentsLimitInsurance.Interfaces
{
    public interface ISvcItems : ISvc<Item>
    {
        List<Item> GetItems();
        void DeleteItem(int itemId);
        void AddItem(Item item);
    }
}
