using BoardGameDB.Data;
using BoardGameDB.Models;
using BoardGameDB.ViewModels;

namespace BoardGameDB.Service
{
    public class BoardGameService
    {
        private readonly GameDbContext _context;

        public BoardGameService(GameDbContext context)
        {
            _context = context;
        }

        public void AddGame(GameVM vm)
        {
            var newGame = new BoardGame
            {
                Name = vm.Name,
                Publisher = vm.Publisher,
                MinPlayers = vm.MinPlayers,
                MaxPlayers = vm.MaxPlayers,
                IsAvailable = vm.IsAvailable,
                CategoryId = vm.CategoryId
            };
            _context.BoardGames.Add(newGame);
            _context.SaveChanges();
        }
    }
}