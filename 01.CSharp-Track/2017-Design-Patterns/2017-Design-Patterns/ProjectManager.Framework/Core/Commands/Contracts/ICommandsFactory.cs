using System;

namespace ProjectManager.Framework.Core.Commands.Contracts
{
    public interface ICommandsFactory
    {
        ICommand GetCommandFromString(Type type);
    }
}
