using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAdminConsole.Models;
using WebAdminConsole.ViewModels;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using System.Threading.Tasks;

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

            foreach (Team team in await _context.Team.ToListAsync())
            {
                var thisTeam = await _context.LeaderBoard
                    .Where(u => u.TeamId == team.TeamId)
                    .ToListAsync();

                var mountainTeam = new MountainResultsViewModel()
                {
                    TeamName = team.Name,
                    Stage4 = await SelectTime(team.TeamId, 4),
                    Stage5 = await SelectTime(team.TeamId, 5),
                    Stage16 = await SelectTime(team.TeamId, 16),
                    Stage18 = await SelectTime(team.TeamId, 18)
                };

                mountainTeam.TotalTime = mountainTeam.Stage4 + 
                    mountainTeam.Stage5 + mountainTeam.Stage16 + 
                    mountainTeam.Stage18;

                viewModel.Add(mountainTeam);
            }

            var sortedList = viewModel.OrderBy(u => u.TotalTime).ToList();
            int position = 1;

            foreach (var row in sortedList)
            {
                row.Position = position;
                position++;
            }

            return View(sortedList);
        }

        public async Task<TimeSpan> SelectTime(int teamId, int stageId) 
        {
            TimeSpan time = await _context.Result
                .Where(u => u.StageId == stageId)
                .Where(u => u.BibNumber.TeamId == teamId)
                .Select(u => u.Time)
                .FirstOrDefaultAsync();

            return time;
        }
    }
}
