using ProjectManager.Core.Commands.Abstractions;
using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Core.Commands
{
    public class CreateProjectCommand : Command, ICommand
    {
        private const int CommandsCount = 4;

        public CreateProjectCommand(Database database, ModelsFactory factory)
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

            if (this.Database.Projects.Any(x => x.Name == parameters[0]))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            var project = this.Factory.CreateProject(parameters[0], parameters[1], parameters[2], parameters[3]);
            this.Database.Projects.Add(project);

            return "Successfully created a new project!";
        }
    }
}