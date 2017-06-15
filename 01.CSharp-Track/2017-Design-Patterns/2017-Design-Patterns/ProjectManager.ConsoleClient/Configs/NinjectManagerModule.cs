using System;
using System.Configuration;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using ProjectManager.ConsoleClient.Configs;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Data;
using ProjectManager.Framework.Core;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Creational;
using ProjectManager.Framework.Core.Commands.Factories;
using ProjectManager.Framework.Core.Commands.Listing;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;
using ProjectManager.Framework.Services;

namespace ProjectManager.Configs
{
    public class NinjectManagerModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IConfigurationProvider>().To<ConfigurationProvider>();
            this.Bind<ILogger>().To<FileLogger>().InSingletonScope().WithConstructorArgument("filePath", ConfigurationManager.AppSettings["LogFilePath"]);
            this.Bind<IEngine>().To<Engine>().InSingletonScope().Intercept().With<LogErrorInterceptor>();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<ICommandsFactory>().To<CommandsFactory>().InSingletonScope();
            this.Bind<IModelsFactory>().To<ModelsFactory>().InSingletonScope();
            this.Bind<IProcessor>().To<CommandProcessor>().InSingletonScope(); // .Intercept().With<PrintInfo>();
            this.Bind<IConfigurationProvider>().To<ConfigurationProvider>();
            this.Bind<ICachingService>().To<CachingService>().WithConstructorArgument("duration", TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["CacheTime"])));
            this.Bind<IDatabase>().To<Database>().InSingletonScope();
            this.Bind<IValidator>().To<Validator>().InSingletonScope();

            this.Bind<ICommand>().To<CreateProjectCommand>().InSingletonScope().Named("Project");
            this.Bind<ICommand>().To<CreateTaskCommand>().InSingletonScope().Named("Task");
            this.Bind<ICommand>().To<CreateUserCommand>().InSingletonScope().Named("User");
            this.Bind<ICommand>().To<ListProjectsCommand>().InSingletonScope().Named("ListProjects");
            this.Bind<ICommand>().To<ListProjectDetailsCommand>().InSingletonScope().Named("ListProjectDetails");
        }
    }
}