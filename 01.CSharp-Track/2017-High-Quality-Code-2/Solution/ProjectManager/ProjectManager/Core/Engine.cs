using Bytes2you.Validation;
using ProjectManager.Common;
using ProjectManager.Common.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Core.Contracts;
using System;

namespace ProjectManager.Core
{
    public class Engine : IEngine
    {
        private const string LoggerCheck = "Engine Logger provider";
        private const string CommandParserCheck = "Engine Parser provider";

        private ILogger logger;
        private IParser commandParser;
        private IReader reader;
        private IWriter writer;

        public Engine(ILogger logger, IParser commandParser, IReader reader, IWriter writer)
        {
            Guard.WhenArgument(logger, LoggerCheck).IsNull().Throw();
            Guard.WhenArgument(commandParser, CommandParserCheck).IsNull().Throw();

            this.logger = logger;
            this.commandParser = commandParser;
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            while (true)
            {
                var fullCommand = reader.Read();

                if (fullCommand.ToLower() == "exit")
                {
                    writer.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.commandParser.Process(fullCommand);
                    Console.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    writer.WriteLine("Opps, something happened. :(");
                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}