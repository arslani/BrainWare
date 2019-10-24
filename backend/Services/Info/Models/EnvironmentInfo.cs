using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime;
using System.Runtime.Serialization;

namespace BrainShark.Api.Services.Info
{
    [DataContract]
    public sealed class EnvironmentInfo
    {
        internal EnvironmentInfo()
        {
        }

        private static string[] GetIpAddresses()
        {
            var hostName = Dns.GetHostName();
            if (string.IsNullOrWhiteSpace(hostName))
                return Array.Empty<string>();

            var hostEntry = Dns.GetHostEntry(hostName);
            return hostEntry.AddressList.Where(a => a.AddressFamily == AddressFamily.InterNetwork).Select(a => a.ToString()).ToArray();
        }

        [DataMember(Name = "userName")]
        public string UserName => Environment.UserName;
        [DataMember(Name = "is64BitOperatingSystem")]
        public bool Is64BitOperatingSystem => Environment.Is64BitOperatingSystem;
        [DataMember(Name = "is64BitProcess")]
        public bool Is64BitProcess => Environment.Is64BitProcess;
        [DataMember(Name = "machineName")]
        public string MachineName => Environment.MachineName;
        [DataMember(Name = "operatingSystemVersion")]
        public string OperatingSystemVersion => Environment.OSVersion.VersionString;
        [DataMember(Name = "processorCount")]
        public int ProcessorCount => Environment.ProcessorCount;
        [DataMember(Name = "systemDirectory")]
        public string SystemDirectory => Environment.SystemDirectory;
        [DataMember(Name = "userDomainName")]
        public string UserDomainName => Environment.UserDomainName;
        [DataMember(Name = "ipAddresses")]
        public string[] IpAddresses => GetIpAddresses();
        [DataMember(Name = "isServerGC")]
        public bool IsServerGC => GCSettings.IsServerGC;
    }
}
