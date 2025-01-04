namespace BusinessLogicLayer.DTO
{
    public class ProductUpdateRequest
    {
        public Guid ProductID;  
        public string? ProductName;
        public CategoryOptions CategoryOptions;
        public double? UnitPrice;
        public int? QuanityInStock;
    }

}
