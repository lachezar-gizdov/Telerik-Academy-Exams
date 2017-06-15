using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Abstracts;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Services;

namespace ProjectManager.Framework.Core.Commands.Listing
{
    public class ListProjectsCommand : Command, ICommand
    {
        private const int ParameterCountConstant = 0;
        private readonly ICachingService cachingService;

        public ListProjectsCommand(IDatabase database, ICachingService cachingService) :
            base(database)
        {
            Guard.WhenArgument(cachingService, "ListProjectsCommand Caching Service").IsNull().Throw();

            this.cachingService = cachingService;
        }

        public override int ParameterCount
        {
            get
            {
                return ParameterCountConstant;
            }
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var projects = this.Database.Projects;

            if (projects.Count == 0)
            {
                return "No projects in the database!";
            }

            return string.Join(Environment.NewLine, projects);
        }
    }
}
