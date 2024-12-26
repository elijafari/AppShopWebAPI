namespace AppShop.Business.DataModel
{
   public class InProduct
    {
        public int CategoryId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public byte[]? image { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }
    }
}
