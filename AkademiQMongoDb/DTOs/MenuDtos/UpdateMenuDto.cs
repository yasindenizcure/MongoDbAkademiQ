namespace AkademiQMongoDb.DTOs.MenuDtos
{
    public class UpdateMenuDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
    }
}
