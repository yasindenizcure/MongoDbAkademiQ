using AkademiQMongoDb.Entities.Common;

namespace AkademiQMongoDb.Entities
{
    public class Booking: BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
