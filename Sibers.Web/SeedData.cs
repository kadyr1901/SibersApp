using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sibers.Data;

namespace Sibers.Web
{
    public static class SeedData
    {
        private static SibersDbContext _ctx;
        public static async Task CreateInitialData(IServiceProvider provider)
        {
            var _db=provider.GetRequiredService<SibersDbContext>();
            await _db.Database.MigrateAsync();
            var roleMngr=provider.GetRequiredService<RoleManager<IdentityRole>>();
            foreach (var roleName in RoleNames.AllRoles)
            {
                var role = await roleMngr.FindByNameAsync(roleName);
                if (role == null)
                {
                    var res = await roleMngr.CreateAsync(new IdentityRole
                    {
                        Name = roleName,
                    });
                    if (!res.Succeeded) { throw new Exception(res.Errors.First().Description); }
                }
            }

            var userMngr=provider.GetRequiredService<UserManager<IdentityUser>>();
            string adminUsername = "admin";
            if(await userMngr.FindByNameAsync(adminUsername) == null)
            {
               var admin = await userMngr.CreateAsync(new IdentityUser
                {
                    UserName = adminUsername,
                },"12345");
                if (!admin.Succeeded) { throw new Exception(admin.Errors.First().Description); }
                var createdUser = await userMngr.FindByNameAsync(adminUsername);
                await userMngr.AddToRoleAsync(createdUser, RoleNames.Supervisor);
            }
        }
    }

    public static class RoleNames
    {
        public const string Supervisor = "Руководитель";
        public const string ProjectManager = "Менеджер проекта";
        public const string Worker = "Сотрудник";

        public static IEnumerable<string> AllRoles
        {
            get
            {
                yield return Supervisor;
                yield return ProjectManager;
                yield return Worker;
            }
        }
    }
}
