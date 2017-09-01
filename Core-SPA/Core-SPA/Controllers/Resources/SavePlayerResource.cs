namespace Core.Controllers.Resources
{
    public class SavePlayerResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsRegistered { get; set; }
        public int TeamId { get; set; }
    }
}
