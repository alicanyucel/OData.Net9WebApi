namespace ODataWebApi.Models
{
    public class Category
    {
        public Category()
        {
            Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = default;
       
    }
}
