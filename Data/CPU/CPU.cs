

using System.Management;

namespace Data.CPU
{
    public  class CPU
    {
        static public string GetCPU() 
        {
            string cpuID = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (cpuID == "")
                {
                    //Remark gets only the first CPU ID
                    cpuID = mo.Properties["processorID"].Value.ToString();
                }
            }
            return cpuID;
        }
    }
}
