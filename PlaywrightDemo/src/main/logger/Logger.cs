using Microsoft.Extensions.Logging;

class Logger
{
    readonly static ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
    
    public Logger() {}

    public static ILogger Create(string className)
    {
        ILogger logger = factory.CreateLogger(className);
        return logger;
    }
}