namespace BoardGameDB.ViewModels
{
    public class GameSearchVM
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public bool IsAvailable { get; set; }
        public List<SelectItem> CategoryList { get; set; }
        public List<GameListVM> SearchResult { get; set; }
    }
}