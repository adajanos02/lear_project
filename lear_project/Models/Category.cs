namespace lear_project.Models
{
    public class Category
    {
        public string Id { get; private set; }
        public string Name { get; set; }

        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
