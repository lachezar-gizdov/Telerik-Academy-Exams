using System;
using Bytes2you.Validation;
using Ninject.Extensions.Interception;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;

namespace ProjectManager.ConsoleClient.Interceptors
{
    public class LogErrorInterceptor : IInterceptor
    {
        private readonly IWriter writer;
        private readonly ILogger logger;

        public LogErrorInterceptor(IWriter writer, ILogger logger)
        {
            Guard.WhenArgument(writer, "LogErrorInterceptor Writer").IsNull().Throw();
            Guard.WhenArgument(logger, "LogErrorInterceptor Logger").IsNull().Throw();

            this.writer = writer;
            this.logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (UserValidationException ex)
            {
                this.writer.WriteLine(ex.Message);
                this.logger.Error(ex.Message);
            }
            catch (Exception ex)
            {
                this.writer.WriteLine("Opps, something happened. Check the log file :(");
                this.logger.Error(ex.Message);
            }
        }
        }
}
