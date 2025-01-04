namespace BusinessLogicLayer.DTO
{
    public class ProductResponse
    {
        public Guid ProductID;
        public string? ProductName;
        public CategoryOptions Category;
        public double? UnitPrice;
        public int? QuantityInStock;
    }

}
