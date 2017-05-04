namespace ProjectManager.Models.Contracts
{
    public interface IModelsFactory
    {
        ITask CreateTask(IUser owner, string name, string state);

        IProject CreateProject(string name, string startingDate, string endingDate, string state);

        IUser CreateUser(string username, string email);
    }
}
