using System;
using ProjectManager.Core.Contracts;

namespace ProjectManager.Core.Providers
{
    class ConsoleReader : IReader
    {
        public virtual string Read()
        {
            return Console.ReadLine();
        }
    }
}