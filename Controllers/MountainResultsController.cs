using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAdminConsole.Migrations;
using WebAdminConsole.Models;
using WebAdminConsole.ViewModels;

namespace WebAdminConsole.Controllers
{
    
    public class MountainResultsController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public MountainResultsController(AppIdentityDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var viewModel = new List<MountainResultsViewModel>();

            foreach (Team team in await _context.Team
                .ToListAsync())
            {
                var thisTeam = await _context.LeaderBoard
                    .Where(u => u.Equals(team))
                    .ToListAsync();

                var mountainTeam = new MountainResultsViewModel()
                {
                    TeamName = team.Name,
                    Stage4 = thisTeam
                    .Where(u => u.StageId == 4)
                    .Select(u => u.Time)
                    .FirstOrDefault(),
                    Stage5 = thisTeam
                    .Where(u => u.StageId == 5)
                    .Select(u => u.Time)
                    .FirstOrDefault(),
                    Stage16 = thisTeam
                    .Where(u => u.StageId == 16)
                    .Select(u => u.Time)
                    .FirstOrDefault(),
                    Stage18 = thisTeam
                    .Where(u => u.StageId == 18)
                    .Select(u => u.Time)
                    .FirstOrDefault()
                };

                mountainTeam.TotalTime = mountainTeam.Stage4 + 
                    mountainTeam.Stage5 + mountainTeam.Stage16 + 
                    mountainTeam.Stage18;

            }

            return View(viewModel);
        }
    }
}
