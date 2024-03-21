namespace lear_project.Models
{
    public class Category
    {
        private static int nextId = 0;

        public string Id { get; private set; }
        public string Name { get; set; }

        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            
        }
    }
}
