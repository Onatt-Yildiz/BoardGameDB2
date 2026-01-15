namespace BoardGameDB.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public virtual ICollection<BoardGame> BoardGames { get; set; }
    }
}