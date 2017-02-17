using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;

namespace PackageManager.Tests.Models.Mocks
{
    internal class ProjectFake : Project
    {
        public ProjectFake(string name, string location, IRepository<IPackage> packages = null) : base(name, location, packages)
        {
        }
    }
}
