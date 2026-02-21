namespace AkademiQMongoDb.DTOs.ContactDtos
{
    public class UpdateContactDto
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
