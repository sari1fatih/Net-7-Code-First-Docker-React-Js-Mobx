using NpgsqlTypes;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace Persistence.Log.Serilog
{
    public class IpAddressColumnWriter : ColumnWriterBase
    {
        public IpAddressColumnWriter() : base(NpgsqlDbType.Text)
        {
        }

        public override object GetValue(LogEvent logEvent, IFormatProvider formatProvider = null)
        {
            var (request, value) = logEvent.Properties.FirstOrDefault(p => p.Key == "ip_address");
            return value?.ToString() ?? null;
        }
    }
}

