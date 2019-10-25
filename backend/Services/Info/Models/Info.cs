using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BrainShark.Api.Services.Info{
    [DataContract]
    public class Info {
        internal Info(ApplicationInfo application, EnvironmentInfo environment, IReadOnlyDictionary<string, object> services) {
            Application = application;
            Environment = environment;
            Services = services;
        }

        [DataMember(Name = "environment")]
        public EnvironmentInfo Environment { get; }

        [DataMember(Name = "application")]
        public ApplicationInfo Application { get; }

        [DataMember(Name = "services")]
        public IReadOnlyDictionary<string, object> Services { get; }
    }
}
