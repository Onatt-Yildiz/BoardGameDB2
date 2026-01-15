using BoardGameDB.Data;
using BoardGameDB.Models;
using BoardGameDB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoardGameDB.Service;
using Microsoft.AspNetCore.Authorization; 

namespace BoardGameDB.Controllers
{
    public class BoardGameController : BaseController
    {
        private readonly BoardGameService _gameService;

        public BoardGameController(GameDbContext dbContext, BoardGameService gameService) : base(dbContext)
        {
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            var games = _dbContext.BoardGames.Include(x => x.Category).ToList();
            var list = new List<GameListVM>();

            foreach (var item in games)
            {
                list.Add(new GameListVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    CategoryName = item.Category.Name,
                    PlayerRange = $"{item.MinPlayers}-{item.MaxPlayers}",
                    Status = item.IsAvailable ? "Rafta" : "Ödünçte"
                });
            }
            return View(list);
        }

        public IActionResult Create()
        {
            var vm = new GameVM();
            vm.CategoryList = GetCategoryList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(GameVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.CategoryList = GetCategoryList();
                return View(vm);
            }

            _gameService.AddGame(vm);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var game = _dbContext.BoardGames.Find(id);
            if (game == null) return NotFound();

            var vm = new GameVM
            {
                Name = game.Name,
                Publisher = game.Publisher,
                MinPlayers = game.MinPlayers,
                MaxPlayers = game.MaxPlayers,
                IsAvailable = game.IsAvailable,
                CategoryId = game.CategoryId,
                CategoryList = GetCategoryList()
            };

            ViewBag.Id = game.Id;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, GameVM vm)
        {
            var game = _dbContext.BoardGames.Find(id);

            if (game != null)
            {
                game.Name = vm.Name;
                game.Publisher = vm.Publisher;
                game.MinPlayers = vm.MinPlayers;
                game.MaxPlayers = vm.MaxPlayers;
                game.IsAvailable = vm.IsAvailable;
                game.CategoryId = vm.CategoryId;

                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var game = _dbContext.BoardGames.Find(id);
            if (game != null)
            {
                _dbContext.BoardGames.Remove(game);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

       
        [AllowAnonymous]
        public IActionResult Search()
        {
            var vm = new GameSearchVM();
            vm.CategoryList = GetCategoryList();
            return View(vm);
        }

        
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Search(GameSearchVM vm)
        {
            vm.CategoryList = GetCategoryList();
            var query = _dbContext.BoardGames.Include(x => x.Category).AsQueryable();

            if (!string.IsNullOrEmpty(vm.Name))
                query = query.Where(x => x.Name.Contains(vm.Name));

            if (vm.CategoryId > 0)
                query = query.Where(x => x.CategoryId == vm.CategoryId);

            vm.SearchResult = query.Select(item => new GameListVM
            {
                Id = item.Id,
                Name = item.Name,
                CategoryName = item.Category.Name,
                PlayerRange = $"{item.MinPlayers}-{item.MaxPlayers}",
                Status = item.IsAvailable ? "Rafta" : "Ödünçte"
            }).ToList();

            return View(vm);
        }

        private List<SelectItem> GetCategoryList()
        {
            return _dbContext.Categories.Select(x => new SelectItem
            {
                Id = x.Id.ToString(),
                Name = x.Name
            }).ToList();
        }
    }
}