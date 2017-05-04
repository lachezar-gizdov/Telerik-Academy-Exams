using ProjectManager.Core.Commands.Abstractions;
using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Core.Commands
{
    public class ListProjectDetailsCommand : Command, ICommand
    {
        private const int CommandsCount = 1;

        public ListProjectDetailsCommand(Database database)
            : base(database)
        {
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count != 1)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("The passed parameter is empty!");
            }

            var projectID = int.Parse(parameters[0]);

            return string.Join(Environment.NewLine, this.Database.Projects[projectID]);
        }
    }
}