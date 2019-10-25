using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BrainShark.Api.Services.Info;

namespace BrainShark.Api.Services.Health
{
    public sealed class HealthReport
    {
        internal HealthReport(ApplicationInfo application, IReadOnlyCollection<HealthReportItem> items, bool isSuccessful, double duration, DateTimeOffset time)
        {
            Application = application;
            Items = items;
            IsSuccessful = isSuccessful;
            Duration = duration;
            Time = time;
        }


        [DataMember(Name = "application")]
        public ApplicationInfo Application { get; }

        [DataMember(Name = "items")]
        public IReadOnlyCollection<HealthReportItem> Items { get; }

        [DataMember(Name = "isSuccessful")]
        public bool IsSuccessful { get; }

        [DataMember(Name = "duration")]
        public double Duration { get; }

        [DataMember(Name = "time")]
        public DateTimeOffset Time { get; }
    }
}
