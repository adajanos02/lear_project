using System.ComponentModel.DataAnnotations;

namespace lear_project.Models
{
    
    public class Food
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }

        public byte[] Data { get; set; }
        public Food(string name, string description, Category category)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Category = category;
            this.Name = name;
            this.Description = description;
        }
    }
}
