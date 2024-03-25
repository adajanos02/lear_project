namespace lear_project.Models
{
    public class Order
    {
        public string Id { get; set; }
        public List<Food> Foods { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Order()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
