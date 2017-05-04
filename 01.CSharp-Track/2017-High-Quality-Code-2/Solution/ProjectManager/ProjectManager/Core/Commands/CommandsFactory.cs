using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager.Core.Commands
{
    public class CommandsFactory : ICommandsFactory
    {
        private Database database;
        private ModelsFactory factory;

        public CommandsFactory(Database database, ModelsFactory factory)
        {
            this.database = database;
            this.factory = factory;
        }

        public ICommand CreateCommandFromString(string commandName)
        {
            var command = commandName.ToLower();

            switch (command)
            {
                case "createproject": return new CreateProjectCommand(this.database, this.factory);
                case "createuser": return new CreateUserCommand(this.database, this.factory);
                case "createtask": return new CreateTaskCommand(this.database, this.factory);
                case "listprojects": return new ListProjectsCommand(this.database);
                case "listprojectdetails": return new ListProjectDetailsCommand(this.database);
                default: throw new UserValidationException("The passed command is not valid!");
            }
        }
    }
}