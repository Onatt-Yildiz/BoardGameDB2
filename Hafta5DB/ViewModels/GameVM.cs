using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BoardGameDB.ViewModels
{
    public class GameVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int CategoryId { get; set; }
        public bool IsAvailable { get; set; }
        
        [ValidateNever]
        public List<SelectItem> CategoryList { get; set; }
    }
}
