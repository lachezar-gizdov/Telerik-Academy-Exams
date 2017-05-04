using Bytes2you.Validation;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager.Core.Commands.Abstractions
{
    public abstract class Command
    {
        private readonly string databaseCheck = "Database";
        private readonly string factoryCheck = "ModelsFactory";

        private Database database;
        private ModelsFactory factory;

        protected Command(Database database, ModelsFactory factory)
        {
            Guard.WhenArgument(database, this.databaseCheck).IsNull().Throw();
            Guard.WhenArgument(factory, this.factoryCheck).IsNull().Throw();

            this.Database = database;
            this.Factory = factory;
        }

        protected Command(Database database)
        {
            Guard.WhenArgument(database, this.databaseCheck).IsNull().Throw();

            this.Database = database;
        }

        protected Database Database
        {
            get
            {
                return this.database;
            }

            set
            {
                this.database = value;
            }
        }

        protected ModelsFactory Factory
        {
            get
            {
                return this.factory;
            }

            set
            {
                this.factory = value;
            }
        }
    }
}