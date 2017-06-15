using Bytes2you.Validation;
using ProjectManager.Framework.Core.Common.Contracts;

namespace ProjectManager.Framework.Core
{
    public class Engine : IEngine
    {
        private IProcessor processor;
        private IWriter writer;
        private IReader reader;

        public Engine(IProcessor processor, IWriter writer, IReader reader)
        {
            Guard.WhenArgument(processor, "Engine Processor provider").IsNull().Throw();
            Guard.WhenArgument(writer, "Engine Logger writer").IsNull().Throw();
            Guard.WhenArgument(reader, "Engine Logger reader").IsNull().Throw();

            this.processor = processor;
            this.writer = writer;
            this.reader = reader;
        }

        public void Start()
        {
            while (true)
            {
                var commandLine = this.reader.ReadLine();

                if (commandLine.ToLower() == "exit")
                {
                    this.writer.WriteLine("Program terminated.");
                    break;
                }

                this.processor.ProcessCommand(commandLine);
            }
        }
    }
}
