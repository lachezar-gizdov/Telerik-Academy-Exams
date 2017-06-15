using System;
using Ninject.Extensions.Interception;
using ProjectManager.Framework.Core.Common.Contracts;

namespace ProjectManager.ConsoleClient.Interceptors
{
    public class PrintInfo : IInterceptor
    {
        private readonly IWriter writer;

        public PrintInfo(IWriter writer)
        {
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            this.writer.WriteLine($"Calling method {invocation.Request.Method.Name} of type {invocation.Request.Method.DeclaringType.Name}...");
        }
    }
}
