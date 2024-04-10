namespace HouseholdManagerApi.DTOs
{
    public class ItemDTO
    {
        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public int? Tag { get; set; }

        public string? Quantity { get; set; }

        public string? UnitOfMeasure { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
