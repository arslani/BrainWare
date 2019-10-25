using System;
using System.Runtime.Serialization;

namespace BrainShark.Api.Services.Health
{ 

    [DataContract]
    public class HealthReportItem
    {
        public HealthReportItem(string name, bool isSuccessful, double duration, Exception exception = null) {

            Name = name;
            IsSuccessful = isSuccessful;
            Duration = duration;
            Exception = exception;
        }

        [DataMember(Name = "name")]
        public string Name { get; }

        [DataMember(Name = "isSuccessful")]
        public bool IsSuccessful { get; }

        [DataMember(Name = "duration")]
        public double Duration { get; }

        [DataMember(Name = "exception")]
        public Exception Exception { get; }
    }
}
