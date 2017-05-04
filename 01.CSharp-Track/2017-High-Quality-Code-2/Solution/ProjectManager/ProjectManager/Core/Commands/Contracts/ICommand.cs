using System.Collections.Generic;

namespace ProjectManager.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(List<string> parameters);
    }
}