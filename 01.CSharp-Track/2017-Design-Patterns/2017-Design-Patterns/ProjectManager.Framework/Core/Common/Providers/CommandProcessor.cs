using System.Linq;
using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;

namespace ProjectManager.Framework.Core.Common.Providers
{
    public class CommandProcessor : IProcessor
    {
        private ICommandsFactory commandsFactory;
        private ILogger logger;
        private IWriter writer;

        public CommandProcessor(ICommandsFactory commandsFactory, ILogger logger, IWriter writer)
        {
            Guard.WhenArgument(commandsFactory, "CommandProcessor CommandsFactory").IsNull().Throw();
            Guard.WhenArgument(logger, "CommandProcessor Logger").IsNull().Throw();

            this.commandsFactory = commandsFactory;
            this.logger = logger;
            this.writer = writer;
        }

        public void ProcessCommand(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine))
            {
                this.logger.Error("No command has been provided!");
                 throw new UserValidationException("No command has been provided!");
            }

            var commandName = commandLine.Split(' ')[0];
            var commandParameters = commandLine
                .Split(' ')
                .Skip(1)
                .ToList();

            var command = this.commandsFactory.GetCommandFromString(commandName);

            this.writer.WriteLine(command.Execute(commandParameters));
        }
    }
}
