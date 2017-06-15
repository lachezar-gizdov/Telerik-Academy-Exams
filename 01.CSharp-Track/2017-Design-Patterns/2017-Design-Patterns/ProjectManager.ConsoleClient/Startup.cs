using Ninject;
using ProjectManager.Configs;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Services;

namespace ProjectManager.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new NinjectManagerModule());

            // This is an example of how to create the caching service.Think about how and where to use it in the project.
            ICachingService cacheService = kernel.Get<ICachingService>();

            IEngine engine = kernel.Get<IEngine>();

            engine.Start(); 
        }
    }
}
