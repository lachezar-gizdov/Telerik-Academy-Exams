using ProjectManager.Core.Commands.Abstractions;
using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Core.Commands
{
    public class CreateTaskCommand : Command, ICommand
    {
        private const int CommandsCount = 4;

        public CreateTaskCommand(Database database, ModelsFactory factory)
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

            var project = this.Database.Projects[int.Parse(parameters[0])];

            var owner = project.Users[int.Parse(parameters[1])];

            var task = this.Factory.CreateTask(owner, parameters[2], parameters[3]);
            project.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}