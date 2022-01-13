namespace XPS.Test.Services.Implementation
{
    using System;
    using XPS.Test.Services.Interfaces;

    public class ConsoleLogger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine(message);
        }

        public void Info(string message)
        {
            Console.WriteLine(message);
        }
    }
}
