using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebAdminConsole.Models;
using WebAdminConsole.ViewModels;

namespace WebAdminConsole.DAL
{
    internal class DbInitializer
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<AppUser> userManager;

        public DbInitializer(RoleManager<IdentityRole> roleMgr, UserManager<AppUser> userMrg)
        {
            roleManager = roleMgr;
            userManager = userMrg;
        }

        internal static async Task Initialize(AppIdentityDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            context.Database.EnsureCreated();

            //Stages
            if (context.Stage.Any())
            {
                return;   // DB has been seeded
            }
            var stages = new Stage[]
            {
                new Stage { Number = "Stage 1", Name = "Hampton Court", Cutoff = TimeSpan.Parse("02:18") },
                new Stage { Number = "Stage 2", Name = "Staines", Cutoff = TimeSpan.Parse("01:41") },
                new Stage { Number = "Stage 3", Name = "Boveney Church", Cutoff = TimeSpan.Parse("02:01") },
                new Stage { Number = "Stage 4", Name = "Little Marlow", Cutoff = TimeSpan.Parse("02:20") },
                new Stage { Number = "Stage 5", Name = "Great Kingshill", Cutoff = TimeSpan.Parse("02:32") },
                new Stage { Number = "Stage 6", Name = "Chipperfield", Cutoff = TimeSpan.Parse("01:31") },
                new Stage { Number = "Stage 7", Name = "St.Albans", Cutoff = TimeSpan.Parse("02:07") },
                new Stage { Number = "Stage 8", Name = "Letty Green", Cutoff = TimeSpan.Parse("01:55") },
                new Stage { Number = "Stage 9", Name = "Dobbs Weir", Cutoff = TimeSpan.Parse("01:52") },
                new Stage { Number = "Stage 10", Name = "High Beach", Cutoff = TimeSpan.Parse("01:38") },
                new Stage { Number = "Stage 11", Name = "Toot Hill", Cutoff = TimeSpan.Parse("01:20") },
                new Stage { Number = "Stage 12", Name = "Blackmore", Cutoff = TimeSpan.Parse("01:57") },
                new Stage { Number = "Stage 13", Name = "Thorndon Park", Cutoff = TimeSpan.Parse("01:11") },
                new Stage { Number = "Stage 14", Name = "Cranham", Cutoff = TimeSpan.Parse("01:39") },
                new Stage { Number = "Stage 15", Name = "Stone Lodge", Cutoff = TimeSpan.Parse("01:43") },
                new Stage { Number = "Stage 16", Name = "Lullingstone Park", Cutoff = TimeSpan.Parse("02:31") },
                new Stage { Number = "Stage 17", Name = "Tatsfield", Cutoff = TimeSpan.Parse("01:55") },
                new Stage { Number = "Stage 18", Name = "Merstham", Cutoff = TimeSpan.Parse("01:49") },
                new Stage { Number = "Stage 19", Name = "Burford Bridge", Cutoff = TimeSpan.Parse("01:32") },
                new Stage { Number = "Stage 20", Name = "West Hanger", Cutoff = TimeSpan.Parse("01:04") },
                new Stage { Number = "Stage 21", Name = "Ripley", Cutoff = TimeSpan.Parse("01:30") },
                new Stage { Number = "Stage 22", Name = "Walton Bridge", Cutoff = TimeSpan.Parse("01:20") }
            };
            foreach (Stage s in stages)
            {
                context.Stage.Add(s);
            }
            context.SaveChanges();

            //Categories
            if (context.Category.Any())
            {
                return;   // DB has been seeded
            }
            var category = new Category[]
            {
                new Category { Name = "Senior Men" },
                new Category { Name = "Senior Women" },
                new Category { Name = "V35 Men" },
                new Category { Name = "V35 Women" },
                new Category { Name = "V45 Men" },
                new Category { Name = "V45 Women" },
                new Category { Name = "V55 Men" },
                new Category { Name = "V55 Women" },
                new Category { Name = "V65 Men" },
                new Category { Name = "V65 Women" }
            };
            foreach (Category s in category)
            {
                context.Category.Add(s);
            }
            context.SaveChanges();

            //TeamCategories
            if (context.TeamCategory.Any())
            {
                return;   // DB has been seeded
            }
            var teamcat = new TeamCategory[]
            {
                new TeamCategory { Name = "Open Men" },
                new TeamCategory { Name = "Open Women" },
                new TeamCategory { Name = "Open Mixed" },
                new TeamCategory { Name = "Veterans" },
                new TeamCategory { Name = "Super Vets" }
            };
            foreach (TeamCategory s in teamcat)
            {
                context.TeamCategory.Add(s);
            }
            context.SaveChanges();

            //Records
            if (context.Record.Any())
            {
                return;   // DB has been seeded
            }
            var records = new Record[]
            {
                new Record { Time = TimeSpan.Parse("01:10:01"), StageId = 1, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("01:13:04"), StageId = 1, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("01:13:16"), StageId = 1, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:13:04"), StageId = 1, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("01:17:21"), StageId = 1, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:26:41"), StageId = 1, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:21:10"), StageId = 1, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:33:36"), StageId = 1, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("01:37:34"), StageId = 1, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("01:44:07"), StageId = 1, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:54:16"), StageId = 2, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("01:00:34"), StageId = 2, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("00:56:14"), StageId = 2, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:00:34"), StageId = 2, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("00:58:05"), StageId = 2, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:07:23"), StageId = 2, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:08:15"), StageId = 2, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:13:13"), StageId = 2, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 2, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 2, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("01:02:23"), StageId = 3, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("01:10:33"), StageId = 3, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("01:02:23"), StageId = 3, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:10:33"), StageId = 3, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("01:14:04"), StageId = 3, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:19:22"), StageId = 3, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:18:20"), StageId = 3, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:19:22"), StageId = 3, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("01:52:09"), StageId = 3, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 3, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("01:11:10"), StageId = 4, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("01:23:21"), StageId = 4, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("01:14:29"), StageId = 4, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:26:52"), StageId = 4, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("01:18:02"), StageId = 4, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:32:44"), StageId = 4, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:25:26"), StageId = 4, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:44:42"), StageId = 4, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 4, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 4, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("01:13:50"), StageId = 5, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("01:26:01"), StageId = 5, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("01:16:45"), StageId = 5, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:28:09"), StageId = 5, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("01:16:45"), StageId = 5, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:42:48"), StageId = 5, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:29:06"), StageId = 5, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:43:35"), StageId = 5, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 5, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 5, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:50:06"), StageId = 6, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("00:53:50"), StageId = 6, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("00:50:06"), StageId = 6, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("00:55:29"), StageId = 6, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("00:54:33"), StageId = 6, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("00:59:29"), StageId = 6, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:01:15"), StageId = 6, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:26:54"), StageId = 6, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("01:20:51"), StageId = 6, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 6, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("01:02:21"), StageId = 7, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("01:14:05"), StageId = 7, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("01:06:19"), StageId = 7, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:15:39"), StageId = 7, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("01:09:16"), StageId = 7, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:20:47"), StageId = 7, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:19:39"), StageId = 7, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:41:30"), StageId = 7, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("01:25:29"), StageId = 7, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 7, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:58:02"), StageId = 8, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("01:03:51"), StageId = 8, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("01:00:10"), StageId = 8, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:08:23"), StageId = 8, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("01:04:06"), StageId = 8, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:12:02"), StageId = 8, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:05:33"), StageId = 8, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:24:22"), StageId = 8, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("01:30:18"), StageId = 8, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 8, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:58:23"), StageId = 9, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("01:01:59"), StageId = 9, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("00:58:23"), StageId = 9, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:07:50"), StageId = 9, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("01:01:14"), StageId = 9, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:12:25"), StageId = 9, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:07:59"), StageId = 9, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:19:50"), StageId = 9, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("01:26:10"), StageId = 9, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 9, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:54:25"), StageId = 10, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("01:02:01"), StageId = 10, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("00:58:24"), StageId = 10, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:06:05"), StageId = 10, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("00:58:58"), StageId = 10, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:07:18"), StageId = 10, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("00:58:58"), StageId = 10, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:35:14"), StageId = 10, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 10, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 10, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:43:22"), StageId = 11, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("00:46:49"), StageId = 11, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("00:44:15"), StageId = 11, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("00:46:49"), StageId = 11, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("00:46:22"), StageId = 11, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("00:52:57"), StageId = 11, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("00:47:58"), StageId = 11, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:20:00"), StageId = 11, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("00:54:59"), StageId = 11, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 11, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:59:36"), StageId = 12, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("01:08:39"), StageId = 12, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("01:02:38"), StageId = 12, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:08:39"), StageId = 12, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("01:05:23"), StageId = 12, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:15:33"), StageId = 12, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:09:20"), StageId = 12, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:21:37"), StageId = 12, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("01:24:59"), StageId = 12, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 12, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:35:38"), StageId = 13, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("00:41:58"), StageId = 13, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("00:38:36"), StageId = 13, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("00:43:57"), StageId = 13, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("00:40:04"), StageId = 13, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("00:43:57"), StageId = 13, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("00:41:04"), StageId = 13, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("00:51:26"), StageId = 13, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 13, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 13, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:51:06"), StageId = 14, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("00:56:00"), StageId = 14, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("00:57:22"), StageId = 14, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:00:23"), StageId = 14, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("01:00:49"), StageId = 14, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:10:03"), StageId = 14, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:03:51"), StageId = 14, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:27:19"), StageId = 14, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 14, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 14, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:53:17"), StageId = 15, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("00:59:19"), StageId = 15, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("00:55:44"), StageId = 15, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("00:59:19"), StageId = 15, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("01:03:07"), StageId = 15, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:11:17"), StageId = 15, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:11:38"), StageId = 15, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:30:41"), StageId = 15, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("01:11:38"), StageId = 15, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 15, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("01:15:33"), StageId = 16, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("01:27:53"), StageId = 16, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("01:16:19"), StageId = 16, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:29:58"), StageId = 16, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("01:19:41"), StageId = 16, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:39:42"), StageId = 16, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:39:33"), StageId = 16, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("02:03:04"), StageId = 16, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("02:19:08"), StageId = 16, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 16, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:55:08"), StageId = 17, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("01:05:28"), StageId = 17, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("00:59:24"), StageId = 17, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:07:37"), StageId = 17, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("01:02:02"), StageId = 17, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:14:49"), StageId = 17, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:11:53"), StageId = 17, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:27:20"), StageId = 17, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("01:27:45"), StageId = 17, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 17, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("01:00:22"), StageId = 18, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("01:06:14"), StageId = 18, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("01:00:22"), StageId = 18, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:15:39"), StageId = 18, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("01:05:45"), StageId = 18, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:20:20"), StageId = 18, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:25:35"), StageId = 18, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:40:53"), StageId = 18, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 18, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 18, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:52:54"), StageId = 19, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("01:01:02"), StageId = 19, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("00:55:32"), StageId = 19, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("01:04:01"), StageId = 19, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("00:58:55"), StageId = 19, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("01:04:27"), StageId = 19, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("01:13:26"), StageId = 19, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:33:39"), StageId = 19, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("01:23:00"), StageId = 19, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 19, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:31:07"), StageId = 20, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("00:35:32"), StageId = 20, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("00:32:30"), StageId = 20, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("00:35:32"), StageId = 20, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("00:35:28"), StageId = 20, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("00:39:36"), StageId = 20, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("00:35:28"), StageId = 20, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:04:00"), StageId = 20, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 20, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 20, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:45:35"), StageId = 21, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("00:54:10"), StageId = 21, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("00:47:59"), StageId = 21, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("00:54:10"), StageId = 21, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("00:50:37"), StageId = 21, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("00:55:57"), StageId = 21, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("00:51:48"), StageId = 21, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("01:08:10"), StageId = 21, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("01:03:48"), StageId = 21, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("01:10:49"), StageId = 21, CategoryId = 10 },
                new Record { Time = TimeSpan.Parse("00:39:10"), StageId = 22, CategoryId = 1 },
                new Record { Time = TimeSpan.Parse("00:42:07"), StageId = 22, CategoryId = 2 },
                new Record { Time = TimeSpan.Parse("00:39:10"), StageId = 22, CategoryId = 3 },
                new Record { Time = TimeSpan.Parse("00:42:07"), StageId = 22, CategoryId = 4 },
                new Record { Time = TimeSpan.Parse("00:40:24"), StageId = 22, CategoryId = 5 },
                new Record { Time = TimeSpan.Parse("00:49:42"), StageId = 22, CategoryId = 6 },
                new Record { Time = TimeSpan.Parse("00:53:14"), StageId = 22, CategoryId = 7 },
                new Record { Time = TimeSpan.Parse("00:52:34"), StageId = 22, CategoryId = 8 },
                new Record { Time = TimeSpan.Parse("01:08:20"), StageId = 22, CategoryId = 9 },
                new Record { Time = TimeSpan.Parse("00:00:00"), StageId = 22, CategoryId = 10 }

            };
            foreach (Record s in records)
            {
                context.Record.Add(s);
            }
            context.SaveChanges();

            //Captains
            if (context.Captain.Any())
            {
                return;   // DB has been seeded
            }
            var captain = new Captain[]
            {
                new Captain { Name = "jachang@hotmail.co.uk" },
                new Captain { Name = "Andrew.kew@me.com" },
                new Captain { Name = "fletcherpaul90@gmail.com" },
                new Captain { Name = "brynreynolds1@hotmail.com" },
                new Captain { Name = "breda.massimiliano@bcg.com" },
                new Captain { Name = "christkelly@yahoo.com" },
                new Captain { Name = "j.wadey@sky.com" },
                new Captain { Name = "joespraggins@hotmail.co.uk" },
                new Captain { Name = "catherine.E.L.hodge@gmail.com" },
                new Captain { Name = "claphamrunners@gmail.com" },
                new Captain { Name = "angenorris@googlemail.com" },
                new Captain { Name = "angeladuff81@gmail.com" },
                new Captain { Name = "secretary@epsomandewellharriers.org" },
                new Captain { Name = "cpfckev@yahoo.co.uk" },
                new Captain { Name = "andywood3@hotmail.com" },
                new Captain { Name = "julianandroman@me.com" },
                new Captain { Name = "nick_sille@hotmail.com" },
                new Captain { Name = "steve.wright@kelsey.co.uk" },
                new Captain { Name = "green.belt.relay@queensparkharriers.org.uk" },
                new Captain { Name = "ranelaghgbr@gmail.com" },
                new Captain { Name = "hanssale4@yahoo.co.uk" },
                new Captain { Name = "ian.fullen@hotmail.com" },
                new Captain { Name = "Atellett87@gmail.com" },
                new Captain { Name = "chancerowan01@yahoo.com" },
                new Captain { Name = "eliselawrenson@yahoo.com" },
                new Captain { Name = "zoe.a.riding@gmail.com" },
                new Captain { Name = "nick@nickaltmann.net" },
                new Captain { Name = "cat.una.os@gmail.com" },
                new Captain { Name = "coherich@gmail.com" }

            };
            var captainRole = new string[] { "Captain" };
            foreach (Captain s in captain)
            {
                context.Captain.Add(s);
                context.SaveChanges();
            }


            //TeamCreate
            if (context.Team.Any())
            {
                return;   // DB has been seeded
            }
            var team = new BulkTeamCreateViewModel[]
            {
                new BulkTeamCreateViewModel { StartNumber = 0, TeamName = "26.2 RRC 1", CaptainEmail = "jachang@hotmail.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 15, TeamName = "26.2 RRC 2", CaptainEmail = "jachang@hotmail.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 30, TeamName = "26.2 RRC 3", CaptainEmail = "jachang@hotmail.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 45, TeamName = "BeaRCat Running Club 1", CaptainEmail = "Andrew.kew@me.com" },
                new BulkTeamCreateViewModel { StartNumber = 60, TeamName = "BeaRCat Running Club 2", CaptainEmail = "Andrew.kew@me.com" },
                new BulkTeamCreateViewModel { StartNumber = 75, TeamName = "Beckenham RC 1", CaptainEmail = "fletcherpaul90@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 90, TeamName = "Beckenham RC 2", CaptainEmail = "fletcherpaul90@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 105, TeamName = "Beeches Track Squad", CaptainEmail = "brynreynolds1@hotmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 120, TeamName = "BCG 1", CaptainEmail = "breda.massimiliano@bcg.com" },
                new BulkTeamCreateViewModel { StartNumber = 135, TeamName = "BCG 2", CaptainEmail = "breda.massimiliano@bcg.com" },
                new BulkTeamCreateViewModel { StartNumber = 150, TeamName = "British Airways AC", CaptainEmail = "christkelly@yahoo.com" },
                new BulkTeamCreateViewModel { StartNumber = 165, TeamName = "Burgess Hill Runners 1", CaptainEmail = "j.wadey@sky.com" },
                new BulkTeamCreateViewModel { StartNumber = 180, TeamName = "Burgess Hill Runners 2", CaptainEmail = "j.wadey@sky.com" },
                new BulkTeamCreateViewModel { StartNumber = 195, TeamName = "Burgess Hill Runners 3", CaptainEmail = "j.wadey@sky.com" },
                new BulkTeamCreateViewModel { StartNumber = 210, TeamName = "Clapham Chasers 1", CaptainEmail = "joespraggins@hotmail.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 225, TeamName = "Clapham Chasers 2", CaptainEmail = "joespraggins@hotmail.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 240, TeamName = "Clapham Chasers 3", CaptainEmail = "joespraggins@hotmail.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 255, TeamName = "Clapham Chasers 4", CaptainEmail = "joespraggins@hotmail.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 270, TeamName = "Clapham Pioneers 1", CaptainEmail = "catherine.E.L.hodge@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 285, TeamName = "Clapham Pioneers 2", CaptainEmail = "catherine.E.L.hodge@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 300, TeamName = "Clapham Runners", CaptainEmail = "claphamrunners@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 315, TeamName = "Dulwich Runners 1", CaptainEmail = "angenorris@googlemail.com" },
                new BulkTeamCreateViewModel { StartNumber = 330, TeamName = "Dulwich Runners 2", CaptainEmail = "angenorris@googlemail.com" },
                new BulkTeamCreateViewModel { StartNumber = 345, TeamName = "Ealing Eagles 1", CaptainEmail = "angeladuff81@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 360, TeamName = "Ealing Eagles 2", CaptainEmail = "angeladuff81@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 375, TeamName = "Ealing Eagles 3", CaptainEmail = "angeladuff81@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 390, TeamName = "Epsom & Ewell Harriers", CaptainEmail = "secretary@epsomandewellharriers.org" },
                new BulkTeamCreateViewModel { StartNumber = 405, TeamName = "Hampton Wick Wanderers", CaptainEmail = "cpfckev@yahoo.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 420, TeamName = "Hillingdon AC", CaptainEmail = "andywood3@hotmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 435, TeamName = "London Front Runners 1", CaptainEmail = "julianandroman@me.com" },
                new BulkTeamCreateViewModel { StartNumber = 450, TeamName = "London Front Runners 2", CaptainEmail = "julianandroman@me.com" },
                new BulkTeamCreateViewModel { StartNumber = 465, TeamName = "London Front Runners 3", CaptainEmail = "julianandroman@me.com" },
                new BulkTeamCreateViewModel { StartNumber = 480, TeamName = "London Front Runners 4", CaptainEmail = "julianandroman@me.com" },
                new BulkTeamCreateViewModel { StartNumber = 495, TeamName = "London Front Runners 5", CaptainEmail = "julianandroman@me.com" },
                new BulkTeamCreateViewModel { StartNumber = 510, TeamName = "Maidenhead AC 1", CaptainEmail = "nick_sille@hotmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 525, TeamName = "Maidenhead AC 2", CaptainEmail = "nick_sille@hotmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 540, TeamName = "Maidenhead AC 3", CaptainEmail = "nick_sille@hotmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 555, TeamName = "Paddock Wood AC", CaptainEmail = "steve.wright@kelsey.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 570, TeamName = "Queens Park Harriers", CaptainEmail = "green.belt.relay@queensparkharriers.org.uk" },
                new BulkTeamCreateViewModel { StartNumber = 585, TeamName = "Ranelagh Harriers 1", CaptainEmail = "ranelaghgbr@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 600, TeamName = "Ranelagh Harriers 2", CaptainEmail = "ranelaghgbr@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 615, TeamName = "Ranelagh Harriers 3", CaptainEmail = "ranelaghgbr@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 630, TeamName = "Ranelagh Harriers 4", CaptainEmail = "ranelaghgbr@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 645, TeamName = "Serpentine 1", CaptainEmail = "hanssale4@yahoo.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 660, TeamName = "Serpentine 2", CaptainEmail = "hanssale4@yahoo.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 675, TeamName = "Serpentine 3", CaptainEmail = "hanssale4@yahoo.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 690, TeamName = "SHAEF Shifters", CaptainEmail = "ian.fullen@hotmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 705, TeamName = "St Neots Riverside Runners", CaptainEmail = "Atellett87@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 720, TeamName = "Stragglers 1", CaptainEmail = "chancerowan01@yahoo.com" },
                new BulkTeamCreateViewModel { StartNumber = 735, TeamName = "Stragglers 2", CaptainEmail = "chancerowan01@yahoo.com" },
                new BulkTeamCreateViewModel { StartNumber = 750, TeamName = "Stragglers 3", CaptainEmail = "chancerowan01@yahoo.com" },
                new BulkTeamCreateViewModel { StartNumber = 765, TeamName = "Sutton Striders 1", CaptainEmail = "eliselawrenson@yahoo.com" },
                new BulkTeamCreateViewModel { StartNumber = 780, TeamName = "Sutton Striders 2", CaptainEmail = "eliselawrenson@yahoo.com" },
                new BulkTeamCreateViewModel { StartNumber = 795, TeamName = "Team Bushy", CaptainEmail = "zoe.a.riding@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 810, TeamName = "Thames Hare & Hounds 1", CaptainEmail = "nick@nickaltmann.net" },
                new BulkTeamCreateViewModel { StartNumber = 825, TeamName = "Thames Hare & Hounds 2", CaptainEmail = "nick@nickaltmann.net" },
                new BulkTeamCreateViewModel { StartNumber = 840, TeamName = "VPH & THAC", CaptainEmail = "cat.una.os@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 855, TeamName = "Wimbledon Windmilers 1", CaptainEmail = "coherich@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 870, TeamName = "Wimbledon Windmilers 2", CaptainEmail = "coherich@gmail.com" }

            };
            foreach (BulkTeamCreateViewModel s in team)
            {
                var captainId = context.Captain
                    .Where(u => u.Name == s.CaptainEmail)
                    .FirstOrDefault();

                var newTeam = new Team
                {
                    TeamCategoryId = 1,
                    Name = s.TeamName,
                    CaptainId = captainId.CaptainId
                };
                context.Team.Add(newTeam);
                context.SaveChanges();

                for (int i = 0; i < 15; i++)
                {
                    var num = s.StartNumber + i;
                    var newBibNumber = new BibNumber
                    {
                        Name = num.ToString(),
                        TeamId = newTeam.TeamId
                    };

                    context.Add(newBibNumber);
                    context.SaveChanges();
                }
            }


        }

        internal static async Task SeedAdminUser(AppIdentityDbContext context)
        {

            string email = "allangbarrie@gmail.com";

            var user = new AppUser
            {
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<IdentityRole>(context);

            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "Administrator", NormalizedName = "ADMINISTRATOR" });
            }

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "xxxxxxxxxxxx");
                user.PasswordHash = hashed;
                var userStore = new UserStore<AppUser>(context);
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "Administrator");
            }

            await context.SaveChangesAsync();
        }

        internal static async Task SeedPeter(AppIdentityDbContext context)
        {

            string email = "greenbeltrelay@outlook.com";

            var user = new AppUser
            {
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<IdentityRole>(context);

            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "Administrator", NormalizedName = "ADMINISTRATOR" });
            }

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "xxxxxxxxxxxx");
                user.PasswordHash = hashed;
                var userStore = new UserStore<AppUser>(context);
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "Administrator");
            }

            await context.SaveChangesAsync();
        }

        //Copy bulk team data here to create captain user objects
        internal static async Task SeedCaptains(AppIdentityDbContext context)
        {
            var team = new BulkTeamCreateViewModel[]
            {
                new BulkTeamCreateViewModel { StartNumber = 0, TeamName = "26.2 RRC 1", CaptainEmail = "jachang@hotmail.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 15, TeamName = "26.2 RRC 2", CaptainEmail = "jachang@hotmail.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 30, TeamName = "26.2 RRC 3", CaptainEmail = "jachang@hotmail.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 45, TeamName = "BeaRCat Running Club 1", CaptainEmail = "Andrew.kew@me.com" },
                new BulkTeamCreateViewModel { StartNumber = 60, TeamName = "BeaRCat Running Club 2", CaptainEmail = "Andrew.kew@me.com" },
                new BulkTeamCreateViewModel { StartNumber = 75, TeamName = "Beckenham RC 1", CaptainEmail = "fletcherpaul90@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 90, TeamName = "Beckenham RC 2", CaptainEmail = "fletcherpaul90@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 105, TeamName = "Beeches Track Squad", CaptainEmail = "brynreynolds1@hotmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 120, TeamName = "BCG 1", CaptainEmail = "breda.massimiliano@bcg.com" },
                new BulkTeamCreateViewModel { StartNumber = 135, TeamName = "BCG 2", CaptainEmail = "breda.massimiliano@bcg.com" },
                new BulkTeamCreateViewModel { StartNumber = 150, TeamName = "British Airways AC", CaptainEmail = "christkelly@yahoo.com" },
                new BulkTeamCreateViewModel { StartNumber = 165, TeamName = "Burgess Hill Runners 1", CaptainEmail = "j.wadey@sky.com" },
                new BulkTeamCreateViewModel { StartNumber = 180, TeamName = "Burgess Hill Runners 2", CaptainEmail = "j.wadey@sky.com" },
                new BulkTeamCreateViewModel { StartNumber = 195, TeamName = "Burgess Hill Runners 3", CaptainEmail = "j.wadey@sky.com" },
                new BulkTeamCreateViewModel { StartNumber = 210, TeamName = "Clapham Chasers 1", CaptainEmail = "joespraggins@hotmail.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 225, TeamName = "Clapham Chasers 2", CaptainEmail = "joespraggins@hotmail.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 240, TeamName = "Clapham Chasers 3", CaptainEmail = "joespraggins@hotmail.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 255, TeamName = "Clapham Chasers 4", CaptainEmail = "joespraggins@hotmail.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 270, TeamName = "Clapham Pioneers 1", CaptainEmail = "catherine.E.L.hodge@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 285, TeamName = "Clapham Pioneers 2", CaptainEmail = "catherine.E.L.hodge@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 300, TeamName = "Clapham Runners", CaptainEmail = "claphamrunners@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 315, TeamName = "Dulwich Runners 1", CaptainEmail = "angenorris@googlemail.com" },
                new BulkTeamCreateViewModel { StartNumber = 330, TeamName = "Dulwich Runners 2", CaptainEmail = "angenorris@googlemail.com" },
                new BulkTeamCreateViewModel { StartNumber = 345, TeamName = "Ealing Eagles 1", CaptainEmail = "angeladuff81@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 360, TeamName = "Ealing Eagles 2", CaptainEmail = "angeladuff81@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 375, TeamName = "Ealing Eagles 3", CaptainEmail = "angeladuff81@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 390, TeamName = "Epsom & Ewell Harriers", CaptainEmail = "secretary@epsomandewellharriers.org" },
                new BulkTeamCreateViewModel { StartNumber = 405, TeamName = "Hampton Wick Wanderers", CaptainEmail = "cpfckev@yahoo.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 420, TeamName = "Hillingdon AC", CaptainEmail = "andywood3@hotmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 435, TeamName = "London Front Runners 1", CaptainEmail = "julianandroman@me.com" },
                new BulkTeamCreateViewModel { StartNumber = 450, TeamName = "London Front Runners 2", CaptainEmail = "julianandroman@me.com" },
                new BulkTeamCreateViewModel { StartNumber = 465, TeamName = "London Front Runners 3", CaptainEmail = "julianandroman@me.com" },
                new BulkTeamCreateViewModel { StartNumber = 480, TeamName = "London Front Runners 4", CaptainEmail = "julianandroman@me.com" },
                new BulkTeamCreateViewModel { StartNumber = 495, TeamName = "London Front Runners 5", CaptainEmail = "julianandroman@me.com" },
                new BulkTeamCreateViewModel { StartNumber = 510, TeamName = "Maidenhead AC 1", CaptainEmail = "nick_sille@hotmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 525, TeamName = "Maidenhead AC 2", CaptainEmail = "nick_sille@hotmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 540, TeamName = "Maidenhead AC 3", CaptainEmail = "nick_sille@hotmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 555, TeamName = "Paddock Wood AC", CaptainEmail = "steve.wright@kelsey.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 570, TeamName = "Queens Park Harriers", CaptainEmail = "green.belt.relay@queensparkharriers.org.uk" },
                new BulkTeamCreateViewModel { StartNumber = 585, TeamName = "Ranelagh Harriers 1", CaptainEmail = "ranelaghgbr@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 600, TeamName = "Ranelagh Harriers 2", CaptainEmail = "ranelaghgbr@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 615, TeamName = "Ranelagh Harriers 3", CaptainEmail = "ranelaghgbr@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 630, TeamName = "Ranelagh Harriers 4", CaptainEmail = "ranelaghgbr@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 645, TeamName = "Serpentine 1", CaptainEmail = "hanssale4@yahoo.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 660, TeamName = "Serpentine 2", CaptainEmail = "hanssale4@yahoo.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 675, TeamName = "Serpentine 3", CaptainEmail = "hanssale4@yahoo.co.uk" },
                new BulkTeamCreateViewModel { StartNumber = 690, TeamName = "SHAEF Shifters", CaptainEmail = "ian.fullen@hotmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 705, TeamName = "St Neots Riverside Runners", CaptainEmail = "Atellett87@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 720, TeamName = "Stragglers 1", CaptainEmail = "chancerowan01@yahoo.com" },
                new BulkTeamCreateViewModel { StartNumber = 735, TeamName = "Stragglers 2", CaptainEmail = "chancerowan01@yahoo.com" },
                new BulkTeamCreateViewModel { StartNumber = 750, TeamName = "Stragglers 3", CaptainEmail = "chancerowan01@yahoo.com" },
                new BulkTeamCreateViewModel { StartNumber = 765, TeamName = "Sutton Striders 1", CaptainEmail = "eliselawrenson@yahoo.com" },
                new BulkTeamCreateViewModel { StartNumber = 780, TeamName = "Sutton Striders 2", CaptainEmail = "eliselawrenson@yahoo.com" },
                new BulkTeamCreateViewModel { StartNumber = 795, TeamName = "Team Bushy", CaptainEmail = "zoe.a.riding@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 810, TeamName = "Thames Hare & Hounds 1", CaptainEmail = "nick@nickaltmann.net" },
                new BulkTeamCreateViewModel { StartNumber = 825, TeamName = "Thames Hare & Hounds 2", CaptainEmail = "nick@nickaltmann.net" },
                new BulkTeamCreateViewModel { StartNumber = 840, TeamName = "VPH & THAC", CaptainEmail = "cat.una.os@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 855, TeamName = "Wimbledon Windmilers 1", CaptainEmail = "coherich@gmail.com" },
                new BulkTeamCreateViewModel { StartNumber = 870, TeamName = "Wimbledon Windmilers 2", CaptainEmail = "coherich@gmail.com" }
            };
            foreach (BulkTeamCreateViewModel s in team)
            {
                var user = new AppUser
                {
                    UserName = s.CaptainEmail,
                    NormalizedUserName = s.CaptainEmail.ToUpper(),
                    Email = s.CaptainEmail,
                    NormalizedEmail = s.CaptainEmail.ToUpper(),
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == "Captain"))
                {
                    await roleStore.CreateAsync(new IdentityRole { Name = "Captain", NormalizedName = "CAPTAIN" });
                }

                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<AppUser>();
                    var hashed = password.HashPassword(user, "xxxxxxxxxxxx");
                    user.PasswordHash = hashed;
                    var userStore = new UserStore<AppUser>(context);
                    await userStore.CreateAsync(user);
                    await userStore.AddToRoleAsync(user, "Captain");
                }

                await context.SaveChangesAsync();
            }

        }

        internal static async Task SeedRunners(AppIdentityDbContext context)
        {

            //Captains
            if (context.Runner.Any())
            {
                return;   // DB has been seeded
            }

            var bibNumbers = await context.BibNumber.ToListAsync();
            var catId = 1;

            foreach (var bibNumber in bibNumbers)
            {
                if (catId > 6)
                { catId = 1; }

                var runner = new Runner
                {
                    First = "First",
                    Last = "Last",
                    BibNumberId = bibNumber.BibNumberId,
                    TeamId = bibNumber.TeamId,
                    CategoryId = catId
                };

                context.Runner.Add(runner);
                await context.SaveChangesAsync();

                catId++;
            }
        }
    }
}
