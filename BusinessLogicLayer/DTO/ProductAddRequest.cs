namespace BusinessLogicLayer.DTO
{
    public class ProductAddRequest
    {
        public string? ProductName;
        public CategoryOptions Category;
        public double? UnitPrice;
        public int? QuantityInStock; 
    }

}
