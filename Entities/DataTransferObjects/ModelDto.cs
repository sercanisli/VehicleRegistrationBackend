namespace Entities.DataTransferObjects
{
    public record ModelDto
    {
        public int Id { get; init; }
        public int BrandId { get; init; }
        public string ModelName { get; init; }
        public string ModelYear { get; init; }
    }
}
