using Serilog;
using Serilog.Events;

namespace Anshan.Framework.Core.Serilog
{
    public class SeriLogFactory
    {
        public static ILogger Create()
        {
            return new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.RollingFile("logs/log-{Date}.txt")
                .CreateLogger();
        }
    }
}