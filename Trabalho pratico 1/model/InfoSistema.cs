using System;
using System.Management;

namespace Trabalho_pratico_1.model
{
    internal class InfoSistema
    {
        public string processorModel { get; }
        public uint processorSpeed { get; }
        public ulong totalMemory { get; }
        public string osName { get; }
        public string osVersion {  get; }

        public InfoSistema()
        {
            this.processorModel = GetProcessorModel();
            this.processorSpeed = GetProcessorSpeed();
            this.totalMemory = GetTotalMemory();
            this.osName = GetOSName();
            this.osVersion = GetOSVersion();
        }

        private string GetProcessorModel()
        {
            ManagementObjectSearcher processorSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject obj in processorSearcher.Get())
            {
                return obj["Name"].ToString();
            }
            return "N/A";
        }

        private uint GetProcessorSpeed()
        {
            ManagementObjectSearcher processorSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject obj in processorSearcher.Get())
            {
                return Convert.ToUInt32(obj["MaxClockSpeed"]);
            }
            return 0;
        }

        private ulong GetTotalMemory()
        {
            ManagementObjectSearcher memorySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject obj in memorySearcher.Get())
            {
                return Convert.ToUInt64(obj["TotalPhysicalMemory"]);
            }
            return 0;
        }

        private string GetOSName()
        {
            ManagementObjectSearcher osSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject obj in osSearcher.Get())
            {
                return obj["Caption"].ToString();
            }
            return "N/A";
        }

        private string GetOSVersion()
        {
            ManagementObjectSearcher osSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject obj in osSearcher.Get())
            {
                return obj["Version"].ToString();
            }
            return "N/A";
        }
    }
}
