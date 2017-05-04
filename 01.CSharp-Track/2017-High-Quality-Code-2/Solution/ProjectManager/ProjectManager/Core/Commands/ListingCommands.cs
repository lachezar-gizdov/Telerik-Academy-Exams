using ProjectManager.Core.Commands.Abstractions;
using ProjectManager.Core.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using System;
using System.Collections.Generic;

namespace ProjectManager.Core.Commands
{
    public sealed class ListProjectsCommand : Command, ICommand
    {
        private const int CommandsCount = 0;

        public ListProjectsCommand(Database database)
            : base(database)
        {
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count != CommandsCount)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            return string.Join(Environment.NewLine, this.Database.Projects);
        }
    }
}