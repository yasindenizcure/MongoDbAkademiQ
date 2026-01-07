using AkademiQMongoDb.Entities.Common;

namespace AkademiQMongoDb.Entities
{
    public class Testimonial: BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Fullname { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }

    }
}
