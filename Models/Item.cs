namespace ContentsLimitInsurance.Models
{
    public class Item
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Value { get; set; }
        public Category? Category { get; set; }
    }
}
