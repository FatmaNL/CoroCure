using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public class DescriptionDTO
    {
        public int Id { get; set; }
        public string Segment { get; set; }

        public LesionDTO Lesion { get; set; }
    }
}