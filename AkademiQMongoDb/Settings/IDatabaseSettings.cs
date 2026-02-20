namespace AkademiQMongoDb.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string MenuCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string BookingCollectionName { get; set; }
        public string ChefCollectionName { get; set; }
    }
}
