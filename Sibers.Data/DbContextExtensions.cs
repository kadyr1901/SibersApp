using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Data
{
    public static class DbContextExtensions
    {
        public static void ApplyConfigEntities(this ModelBuilder pBuilder)
        {
            var assemblies = GetEntitiesAssemblies();
            assemblies.ForEach(assembly => pBuilder.ApplyConfigurationsFromAssembly(assembly));
        }

        public static List<Assembly> GetEntitiesAssemblies()
        {
            return Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => !type.IsAbstract && IsEntity(type) && HasConfigure(type))
                .Select(type => type.Assembly)
                .ToList();
        }

        private static bool IsEntity(Type pType)
        {
            return pType.FullName != null && pType.FullName.Contains("Entities");
        }

        private static bool HasConfigure(Type pType)
        {
            return pType.GetMethod("CustomConfigure") != null;
        }

        public static SibersDbContext NewContext(this SibersDbContext pDb)
        {
            var connectionString = pDb.Database.GetConnectionString();
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));

            var context = new SibersDbContext(connectionString);
            context.Database.SetCommandTimeout(60);
            return context;
        }
    }
}
