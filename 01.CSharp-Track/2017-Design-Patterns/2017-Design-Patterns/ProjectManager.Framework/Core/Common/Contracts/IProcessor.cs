namespace ProjectManager.Framework.Core.Common.Contracts
{
    public interface IProcessor
    {
        void ProcessCommand(string commandLine);
    }
}
