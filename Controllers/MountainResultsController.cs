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
                    Stage4 = SelectTime(thisTeam, 4),
                    Stage5 = SelectTime(thisTeam, 5),
                    Stage16 = SelectTime(thisTeam, 16),
                    Stage18 = SelectTime(thisTeam, 18)
                };

                mountainTeam.TotalTime = mountainTeam.Stage4 + 
                    mountainTeam.Stage5 + mountainTeam.Stage16 + 
                    mountainTeam.Stage18;

                viewModel.Add(mountainTeam);
            }

            viewModel.OrderBy(u => u.TotalTime);
            int position = 1;

            foreach (var row in viewModel)
            {
                row.Position = position;
                position++;
            }


            return View(viewModel);
        }

        public TimeSpan SelectTime(List<LeaderBoard> thisTeam, int stageId) 
        {
            return thisTeam
                .Where(u => u.StageId == stageId)
                .Select(u => u.Time)
                .FirstOrDefault();
        }
    }
}
