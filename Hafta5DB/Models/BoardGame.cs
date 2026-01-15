namespace BoardGameDB.Models
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; } 
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public bool IsAvailable { get; set; } 

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}