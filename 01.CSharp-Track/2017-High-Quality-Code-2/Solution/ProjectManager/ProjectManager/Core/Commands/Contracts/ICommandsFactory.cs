namespace ProjectManager.Core.Commands.Contracts
{
    /// <summary>
    /// Interface for Commands Factory for building commands
    /// </summary>
    public interface ICommandsFactory
    {
        ICommand CreateCommandFromString(string commandName);
    }
}