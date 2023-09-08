using System.Reflection;

namespace TravelMap.Api.Register
{
    public static class AutoMapperRegister
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            var assemblies = GetAssemblies();
            services.AddAutoMapper(assemblies);
        }

        private static List<Assembly> GetAssemblies()
        {
            var assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            var referenceAssemblies = assemblyNames.Select(an => Assembly.Load(an)).ToList();
            referenceAssemblies.Add(Assembly.GetExecutingAssembly());
            return referenceAssemblies;
        }
    }
}