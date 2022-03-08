﻿using Serilog.Core;
using Serilog.Events;

namespace CodeHollow.FeedReader.ConsoleSample.Instance;

/// <summary>
/// Serilog enricher that converts the log event's timestamp to UTC.
/// </summary>
public class UtcTimestampEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory lepf)
    {
        logEvent.AddPropertyIfAbsent(lepf.CreateProperty("UtcTimestamp", logEvent.Timestamp.UtcDateTime));
    }
}
