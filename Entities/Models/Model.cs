namespace Entities.Models
{
    public class Model
    {
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public string ModelName { get; set; }
        public string ModelYear { get; set; }

        public virtual Brand? Brand { get; set; }
    }
}
