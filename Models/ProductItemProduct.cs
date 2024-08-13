namespace web_ban_do_an.Models
{
    public class ProductItemProduct
    {
        public int productItemId { get; set; }
        public ProductItem productItem { get; set; }

        public int productId {  get; set; }
        public Products product { get; set; }
    }
}
