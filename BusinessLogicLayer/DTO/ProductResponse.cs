namespace BusinessLogicLayer.DTO
{
    public class ProductResponse
    {
        public Guid ProductID;
        public string? ProductName;
        public CategoryOptions CategoryOptions;
        public double? UnitPrice;
        public int? QuanityInStock;
    }

}
