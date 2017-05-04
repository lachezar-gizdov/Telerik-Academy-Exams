using ProjectManager.Core.Commands;
using ProjectManager.Common.Contracts;
using System;
using System.Linq;

namespace ProjectManager.Common
{
    public class CommandParser : IParser
    {
        private CommandsFactory factory;

        public CommandParser(CommandsFactory factory)
        {
            this.factory = factory;
        }

        public string Process(string fullCommand)
        {
            if (string.IsNullOrWhiteSpace(fullCommand))
            {
                throw new Exceptions.UserValidationException("No command has been provided!");
            }

            var command = this.factory.CreateCommandFromString(fullCommand.Split(' ')[0]);
            return command.Execute(fullCommand.Split(' ').Skip(1).ToList());
        }
    }
}