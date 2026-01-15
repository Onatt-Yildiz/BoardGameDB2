using BoardGameDB.Data;
using BoardGameDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardGameDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGamesApiController : ControllerBase
    {
        private readonly GameDbContext _context;

        public BoardGamesApiController(GameDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetBoardGames()
        {
            var games = _context.BoardGames.Include(x => x.Category).ToList();
            return Ok(games);
        }

       
        [HttpPost]
        public IActionResult AddBoardGame([FromBody] BoardGame game)
        {
            if (game == null) return BadRequest();
            _context.BoardGames.Add(game);
            _context.SaveChanges();
            return Ok(game);
        }
    }
}