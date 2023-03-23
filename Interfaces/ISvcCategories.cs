using ContentsLimitInsurance.Models;

namespace ContentsLimitInsurance.Interfaces
{
    public interface ISvcCategories : ISvc<Category>
    {
        List<Category> GetCategories();
    }
}
