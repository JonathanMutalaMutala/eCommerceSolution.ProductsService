namespace BusinessLogicLayer.DTO
{
    public class ProductUpdateRequest
    {
        public Guid ProductID;  
        public string? ProductName;
        public CategoryOptions Category;
        public double? UnitPrice;
        public int? QuantityInStock;
    }

}
