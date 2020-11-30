namespace ECommerce.Api.Products.Entities
{
    /// <summary>
    /// Product entity.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique identifyer of the product.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Inventory number of the product.
        /// </summary>
        public int Inventory { get; set; }
    }
}
