using NpgsqlTypes;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace Persistence.CustomLog.Serilog
{
    public class RequestColumnWriter : ColumnWriterBase
    {
        public RequestColumnWriter() : base(NpgsqlDbType.Text)
        {
        }

        public override object GetValue(LogEvent logEvent, IFormatProvider formatProvider = null)
        {
            var (request, value) = logEvent.Properties.FirstOrDefault(p => p.Key == "request");
            return value?.ToString() ?? null;
        }
    }
}

