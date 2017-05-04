namespace ProjectManager.Models.Contracts
{
    public interface ITask
    {
        string Name { get; set; }

        IUser Owner { get; set; }

        string State { get; set; }

        string ToString();
    }
}