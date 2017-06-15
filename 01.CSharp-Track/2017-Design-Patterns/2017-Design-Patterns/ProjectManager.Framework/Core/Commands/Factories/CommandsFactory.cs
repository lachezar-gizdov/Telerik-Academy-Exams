using Ninject;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;
using ProjectManager.Framework.Services;

namespace ProjectManager.Framework.Core.Commands.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IDatabase database;
        private readonly IModelsFactory factory;
        private readonly ICachingService cachingService;
        private readonly IKernel kernel;

        public CommandsFactory(IDatabase database, IModelsFactory modelsFactory, ICachingService cachingService, IKernel kernel)
        {
            this.factory = modelsFactory;
            this.database = database;
            this.cachingService = cachingService;
            this.kernel = kernel;
        }

        public ICommand GetCommandFromString(string commandName)
        {
            switch (commandName.ToLower())
            {
                case "createproject":
                    return this.CreateProjectCommand();
                case "createuser":
                    return this.CreateUserCommand();
                case "createtask":
                    return this.CreateTaskCommand();
                case "listprojects":
                    return this.ListProjectCommand();
                case "listprojectdetails":
                    return this.ListProjectDetailsCommand();
                default:
                    throw new UserValidationException("No such command!");
            }
        }


        public ICommand CreateProjectCommand()
        {
            return kernel.Get<ICommand>("Project");
        }

        public ICommand CreateUserCommand()
        {
            return kernel.Get<ICommand>("User");
        }

        public ICommand CreateTaskCommand()
        {
            return kernel.Get<ICommand>("Task");
        }

        public ICommand ListProjectCommand()
        {
            return kernel.Get<ICommand>("ListProjects");
        }

        public ICommand ListProjectDetailsCommand()
        {
            return kernel.Get<ICommand>("ListProjectDetails");
        }
    }
}