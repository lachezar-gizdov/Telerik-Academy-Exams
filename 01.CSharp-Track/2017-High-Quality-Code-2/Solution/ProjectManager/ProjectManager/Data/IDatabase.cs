using ProjectManager.Models.Contracts;
using System.Collections.Generic;

namespace ProjectManager.Data
{
    // You are not allowed to modify this interface (except to add documentation)

    /// <summary>
    /// Interface for the Database
    /// The Database should store projects
    /// </summary>
    public interface IDatabase
    {
        IList<IProject> Projects { get; }
    }
}
