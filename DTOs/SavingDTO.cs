namespace HouseholdManagerApi.DTOs
{
    public class SavingDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public uint Amount { get; set; }

        public int? Goal { get; set; }

        public string? Icon { get; set; }

        public string Currency { get; set; } = null!;

        public Guid Tag { get; set; }

    }
}
