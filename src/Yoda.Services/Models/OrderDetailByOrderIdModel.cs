namespace Yoda.Services.Models
{
    public class OrderDetailByOrderIdModel
    {
        public int Id { get; set; }
        public DateTimeOffset CreateDateUtc { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
    }
}
