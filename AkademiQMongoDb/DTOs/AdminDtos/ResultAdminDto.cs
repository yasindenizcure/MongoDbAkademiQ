using MongoDB.Bson.Serialization.Attributes;

namespace AkademiQMongoDb.DTOs.AdminDtos
{
    public class ResultAdminDto
    {
        [BsonElement("UserName")]
        public string UserName { get; set; }
        [BsonElement("FirstName")]

        public string FirstName { get; set; }
        [BsonElement("LastName")]
        public string LastName { get; set; }
        public bool IsVerified { get; set; }

    }
}
