using ProjectManager.Core.Commands.Abstractions;
using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Core.Commands
{
    public class CreateUserCommand : Command, ICommand
    {
        private const int CommandsCount = 3;

        public CreateUserCommand(Database database, ModelsFactory factory)
            : base(database, factory)
        {
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count != CommandsCount)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            if (this.Database.Projects[int.Parse(parameters[0])].Users.Any() &&
                this.Database.Projects[int.Parse(parameters[0])].Users.Any(x => x.UserName == parameters[1]))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            var projectId = int.Parse(parameters[0]);
            var userName = parameters[1];
            var userEmail = parameters[2];

            this.Database.Projects[projectId].Users.Add(this.Factory.CreateUser(userName, userEmail));

            return "Successfully created a new user!";
        }
    }
}