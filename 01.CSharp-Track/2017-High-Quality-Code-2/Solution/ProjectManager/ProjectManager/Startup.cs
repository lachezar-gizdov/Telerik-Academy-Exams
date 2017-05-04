using ProjectManager.Core.Commands;
using ProjectManager.Common;
using ProjectManager.Core;
using ProjectManager.Core.Providers;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager
{
    public class Startup
    {
        public static void Main()
        {
            var fileLogger = new FileLogger();
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var modelsFactory = new ModelsFactory();
            var db = new Database();
            var commandsFactory = new CommandsFactory(db, modelsFactory);
            var commandParser = new CommandParser(commandsFactory);
            var engine = new Engine(fileLogger, commandParser, reader, writer);

            engine.Start();
        }
    }
}