using AkademiQMongoDb.Entities.Common;

namespace AkademiQMongoDb.Entities
{
    public class Contact: BaseEntity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }

    }
}
