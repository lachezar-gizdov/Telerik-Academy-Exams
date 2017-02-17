using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Enums;

namespace PackageManager.Tests.Models.Mocks
{
    internal class PackageVersionFake : PackageVersion
    {
        public PackageVersionFake(int major, int minor, int patch, VersionType type) : base(major, minor, patch, type)
        {

        }
    }
}
