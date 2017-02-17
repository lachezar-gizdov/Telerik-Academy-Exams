using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Commands
{
    internal class InstallCommandFake : InstallCommand
    {
        public InstallCommandFake(IInstaller<IPackage> installer, IPackage package) : base(installer, package)
        {
        }

        //public IInstaller<IPackage> Installer
        //{
        //    get
        //    {
        //        return this.installer;
        //    }
        //}
    }
}
