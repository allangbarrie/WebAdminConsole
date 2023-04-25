using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace WebAdminConsole.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppIdentityDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppIdentityDbContext>>()))
            {

                SeedUsers(serviceProvider, context);

                Thread.Sleep(30000);
                
                // Look for any Stages.
                if (context.Stage.Any())
                {
                    return;   // DB has been seeded
                }
                context.Stage.AddRange(
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
                    new Stage { Number = "Stage 14", Name = "Cranham", Cutoff = TimeSpan.Parse("01:34") },
                    new Stage { Number = "Stage 15", Name = "Stone Lodge", Cutoff = TimeSpan.Parse("01:43") },
                    new Stage { Number = "Stage 16", Name = "Lullingstone Park", Cutoff = TimeSpan.Parse("02:31") },
                    new Stage { Number = "Stage 17", Name = "Tatsfield", Cutoff = TimeSpan.Parse("01:55") },
                    new Stage { Number = "Stage 18", Name = "Merstham", Cutoff = TimeSpan.Parse("01:49") },
                    new Stage { Number = "Stage 19", Name = "Burford Bridge", Cutoff = TimeSpan.Parse("01:32") },
                    new Stage { Number = "Stage 20", Name = "West Hanger", Cutoff = TimeSpan.Parse("01:04") },
                    new Stage { Number = "Stage 21", Name = "Ripley", Cutoff = TimeSpan.Parse("01:30") },
                    new Stage { Number = "Stage 22", Name = "Walton Bridge", Cutoff = TimeSpan.Parse("01:20") }

                );
                context.SaveChanges();

                // Look for any Categories.
                if (context.Category.Any())
                {
                    return;   // DB has been seeded
                }
                context.Category.AddRange(
                    new Category { Name = "Senior Men" },
                    new Category { Name = "Senior Women" },
                    new Category { Name = "V40 Men"},
                    new Category { Name = "V35 Women" },
                    new Category { Name = "V50 Men" },
                    new Category { Name = "V45 Women" }
                );
                context.SaveChanges();

                // Look for any TeamCategories.
                if (context.TeamCategory.Any())
                {
                    return;   // DB has been seeded
                }
                context.TeamCategory.AddRange(
                    new TeamCategory { Name = "Open Men" },
                    new TeamCategory { Name = "Open Women" },
                    new TeamCategory { Name = "Open Mixed" },
                    new TeamCategory { Name = "Veteran Men" },
                    new TeamCategory { Name = "Veteran Women" },
                    new TeamCategory { Name = "Veteran Mixed" }
                );
                context.SaveChanges();

                // Look for any Records.
                if (context.Record.Any())
                {
                    return;   // DB has been seeded
                }
                context.Record.AddRange(
                    new Record { Time = TimeSpan.Parse("01:10:09"), StageId = 1, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:13:04"), StageId = 1, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:13:04"), StageId = 1, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("01:14:43"), StageId = 1, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:26:41"), StageId = 1, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:17:21"), StageId = 1, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:55:36"), StageId = 2, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:00:34"), StageId = 2, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:00:34"), StageId = 2, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("00:56:14"), StageId = 2, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:07:23"), StageId = 2, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:00:22"), StageId = 2, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("01:04:12"), StageId = 3, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:18:38"), StageId = 3, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:22:49"), StageId = 3, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("01:06:23"), StageId = 3, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:22:49"), StageId = 3, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:17:30"), StageId = 3, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("01:11:10"), StageId = 4, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:23:21"), StageId = 4, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:26:52"), StageId = 4, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("01:14:29"), StageId = 4, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:32:44"), StageId = 4, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:18:02"), StageId = 4, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("01:13:54"), StageId = 5, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:29:44"), StageId = 5, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:32:30"), StageId = 5, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("01:20:54"), StageId = 5, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:42:48"), StageId = 5, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:31:45"), StageId = 5, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:50:06"), StageId = 6, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("00:55:29"), StageId = 6, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("00:55:29"), StageId = 6, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("00:50:06"), StageId = 6, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("00:59:29"), StageId = 6, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:01:39"), StageId = 6, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("01:02:21"), StageId = 7, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:14:05"), StageId = 7, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:15:39"), StageId = 7, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("01:06:19"), StageId = 7, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:26:57"), StageId = 7, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:09:44"), StageId = 7, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:58:02"), StageId = 8, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:03:51"), StageId = 8, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:08:23"), StageId = 8, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("01:00:10"), StageId = 8, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:12:02"), StageId = 8, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:05:53"), StageId = 8, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:58:23"), StageId = 9, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:05:33"), StageId = 9, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:07:50"), StageId = 9, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("00:58:23"), StageId = 9, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:13:54"), StageId = 9, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:05:13"), StageId = 9, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:54:25"), StageId = 10, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:06:05"), StageId = 10, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:06:05"), StageId = 10, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("00:58:37"), StageId = 10, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:07:18"), StageId = 10, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:01:49"), StageId = 10, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:43:22"), StageId = 11, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("00:46:49"), StageId = 11, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("00:46:49"), StageId = 11, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("00:44:15"), StageId = 11, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("00:53:40"), StageId = 11, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("00:48:34"), StageId = 11, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:59:36"), StageId = 12, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:08:39"), StageId = 12, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:08:39"), StageId = 12, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("01:02:38"), StageId = 12, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:17:26"), StageId = 12, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:05:23"), StageId = 12, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:35:38"), StageId = 13, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("00:41:58"), StageId = 13, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("00:45:29"), StageId = 13, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("00:38:36"), StageId = 13, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("00:47:08"), StageId = 13, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("00:40:04"), StageId = 13, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:53:39"), StageId = 14, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:07:24"), StageId = 14, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:16:41"), StageId = 14, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("00:59:01"), StageId = 14, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:16:41"), StageId = 14, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:02:52"), StageId = 14, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:53:17"), StageId = 15, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:05:45"), StageId = 15, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:05:45"), StageId = 15, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("01:03:07"), StageId = 15, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:11:17"), StageId = 15, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:03:07"), StageId = 15, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("01:15:48"), StageId = 16, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:29:28"), StageId = 16, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:29:58"), StageId = 16, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("01:19:41"), StageId = 16, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:39:42"), StageId = 16, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:28:53"), StageId = 16, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:55:08"), StageId = 17, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:05:28"), StageId = 17, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:08:10"), StageId = 17, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("00:59:24"), StageId = 17, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:14:49"), StageId = 17, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:04:27"), StageId = 17, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("01:00:22"), StageId = 18, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:07:36"), StageId = 18, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:15:39"), StageId = 18, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("01:00:22"), StageId = 18, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:30:10"), StageId = 18, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("01:10:49"), StageId = 18, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:53:02"), StageId = 19, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("01:02:00"), StageId = 19, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("01:02:54"), StageId = 19, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("00:55:48"), StageId = 19, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("01:03:19"), StageId = 19, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("00:59:35"), StageId = 19, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:31:07"), StageId = 20, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("00:35:32"), StageId = 20, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("00:37:32"), StageId = 20, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("00:32:30"), StageId = 20, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("00:40:01"), StageId = 20, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("00:39:07"), StageId = 20, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:46:41"), StageId = 21, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("00:54:10"), StageId = 21, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("00:54:10"), StageId = 21, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("00:47:59"), StageId = 21, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("00:55:57"), StageId = 21, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("00:53:02"), StageId = 21, CategoryId = 5 },
                    new Record { Time = TimeSpan.Parse("00:39:10"), StageId = 22, CategoryId = 1 },
                    new Record { Time = TimeSpan.Parse("00:47:15"), StageId = 22, CategoryId = 2 },
                    new Record { Time = TimeSpan.Parse("00:47:15"), StageId = 22, CategoryId = 4 },
                    new Record { Time = TimeSpan.Parse("00:39:10"), StageId = 22, CategoryId = 3 },
                    new Record { Time = TimeSpan.Parse("00:54:20"), StageId = 22, CategoryId = 6 },
                    new Record { Time = TimeSpan.Parse("00:44:53"), StageId = 22, CategoryId = 5 }

                );
                context.SaveChanges();


                
            }
        }

        public static async void SeedUsers(IServiceProvider serviceProvider, AppIdentityDbContext context)
        {


            var user = new AppUser
            {
                Email = "allangbarrie@gmail.com",
                NormalizedEmail = "ALLANGBARRIE@GMAIL.COM",
                UserName = "allangbarrie@gmail.com",
                NormalizedUserName = "ALLANGBARRIE@GMAIL.COM",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "Ch4ngeMeNow!");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(context);
                var userresult = await userStore.CreateAsync(user);

            }



            string[] roles = new string[] { "Administrator" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    var newRole = new IdentityRole(role);

                    newRole.NormalizedName = "ADMINISTRATOR";

                    await roleStore.CreateAsync(newRole);
                }
            }

            UserManager<AppUser> _userManager = serviceProvider.GetService<UserManager<AppUser>>();
            user = await _userManager.FindByEmailAsync(user.Email);
            var result = await _userManager.AddToRolesAsync(user, roles);


            await context.SaveChangesAsync();
        }

     
    }
}
