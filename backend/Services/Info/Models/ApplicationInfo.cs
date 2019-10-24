using System.Reflection;
using System.Runtime.Serialization;

namespace BrainShark.Api.Services.Info
{
    [DataContract]
    public class ApplicationInfo
    {
        internal ApplicationInfo(string stage)
        {
            Stage = stage;
        }

        private static string GetName() => ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;
        private static string GetVesion() => ((AssemblyFileVersionAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false)[0]).Version;

        [DataMember(Name = "name")]
        public string Name => GetName();
        [DataMember(Name = "version")]
        public string Version = GetVesion();
        [DataMember(Name = "stage")]
        public string Stage { get; }
    }
}
