using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

public class IPHelper
{
    #region IPAddress

    public static List<string> GetIPListByHostAddresses()
    {
        List<string> lstIP = new List<string>();
        string hostName = Dns.GetHostName();//本机名   
        IPAddress[] addressList = Dns.GetHostAddresses(hostName);//会返回所有地址，包括IPv4和IPv6   
        string strIP;
        foreach (IPAddress ip in addressList)
        {
            strIP = IPAddressToString(ip);
            if (string.IsNullOrEmpty(strIP)) continue;
            lstIP.Add(strIP);
        }
        return lstIP;
    }

    public static string GetIPByHostAddresses()
    {
        List<string> lstIP = GetIPListByHostAddresses();

        if (lstIP == null || lstIP.Count <= 0)
        {
            return string.Empty;
        }
        else
        {
            return lstIP[0];
        }
    }

    public static List<string> GetIPListByIPHostEntry()
    {
        List<string> lstIP = new List<string>();
        string hostName = Dns.GetHostName();//本机名   
        IPAddress[] addressList = Dns.GetHostEntry(hostName).AddressList;//会返回所有地址，包括IPv4和IPv6   
        string strIP;
        foreach (IPAddress ip in addressList)
        {
            strIP = IPAddressToString(ip);
            if (string.IsNullOrEmpty(strIP)) continue;
            lstIP.Add(strIP);
        }
        return lstIP;
    }

    public static string GetIPByIPHostEntry()
    {
        List<string> lstIP = GetIPListByIPHostEntry();

        if (lstIP == null || lstIP.Count <= 0)
        {
            return string.Empty;
        }
        else
        {
            return lstIP[0];
        }
    }

    public static string GetIPByIPConfig()
    {
        Process cmd = new Process();
        cmd.StartInfo.FileName = "ipconfig.exe";//设置程序名   
        cmd.StartInfo.Arguments = "/all";  //参数   
        //重定向标准输出   
        cmd.StartInfo.RedirectStandardOutput = true;
        cmd.StartInfo.RedirectStandardInput = true;
        cmd.StartInfo.UseShellExecute = false;
        cmd.StartInfo.CreateNoWindow = true;//不显示窗口（控制台程序是黑屏）   
        cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//暂时不明白什么意思   
        /* 
        hwndWin32Host = Win32Native.FindWindow(null, win32Exinfo.windowsName); 
        Win32Native.ShowWindow(hwndWin32Host, 1);     //先FindWindow找到窗口后再ShowWindow 
        */
        cmd.Start();
        string cmdInfo = cmd.StandardOutput.ReadToEnd();
        cmd.WaitForExit();
        cmd.Close();

        if (string.IsNullOrEmpty(cmdInfo))
        {
            return string.Empty;
        }
        else
        {
            int IP4Index = cmdInfo.IndexOf("IPv4");
            int EndIndex = 0;
            string IP4Line;

            if (IP4Index >= 0)
            {
                EndIndex = cmdInfo.IndexOf("\r", IP4Index);
                if (EndIndex < 0) EndIndex = cmdInfo.IndexOf("\n", IP4Index);
                if (EndIndex < 0) EndIndex = cmdInfo.Length - 1;
                IP4Line = cmdInfo.Substring(IP4Index, EndIndex - IP4Index);
                if (IP4Line.IndexOf(':') >= 0)
                {
                    IP4Line = IP4Line.Substring(IP4Line.IndexOf(':') + 1, IP4Line.Length - IP4Line.IndexOf(':') - 1);
                }
                if (IP4Line.IndexOf('(') >= 0 && IP4Line.IndexOf(')') >= 0)
                {
                    IP4Line = IP4Line.Remove(IP4Line.IndexOf('('), IP4Line.IndexOf(')') - IP4Line.IndexOf('(') + 1);
                }

                return IP4Line.Trim();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public static List<string> GetIPListByIPConfig()
    {
        List<string> macs = new List<string>();
        ProcessStartInfo startInfo = new ProcessStartInfo("ipconfig", "/all");
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardInput = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.CreateNoWindow = true;
        Process p = Process.Start(startInfo);
        //截取输出流
        StreamReader reader = p.StandardOutput;
        string line = reader.ReadLine();

        while (!reader.EndOfStream)
        {
            if (!string.IsNullOrEmpty(line))
            {
                line = line.Trim();

                if (line.IndexOf("IPv4") >= 0)
                {
                    macs.Add(line);
                }
            }

            line = reader.ReadLine();
        }

        //等待程序执行完退出进程
        p.WaitForExit();
        p.Close();
        reader.Close();

        return macs;
    }

    private static string IPAddressToString(IPAddress ip)
    {
        if (ip.AddressFamily == AddressFamily.InterNetwork)
        {
            if (ip.ToString().IndexOf('.') < 0) return string.Empty;
            string[] arrIP = ip.ToString().Split('.');
            long p1 = long.Parse(arrIP[0]);
            long p2 = long.Parse(arrIP[1]);
            long p3 = long.Parse(arrIP[2]);
            long p4 = arrIP.Length >= 4 ? long.Parse(arrIP[3]) : 0;

            return string.Format("{0}.{1}.{2}.{3}", p1, p2, p3, p4);
        }
        else
        {
            return "";
        }
    }

    public static long IPAddressToLong(string ip)
    {
        char[] dot = new char[] { '.' };
        string[] ipArr = ip.Split(dot);
        if (ipArr.Length == 3) ip = ip + ".0";
        ipArr = ip.Split(dot); long ip_Int = 0;
        long p1 = long.Parse(ipArr[0]) * 256 * 256 * 256;
        long p2 = long.Parse(ipArr[1]) * 256 * 256;
        long p3 = long.Parse(ipArr[2]) * 256;
        long p4 = long.Parse(ipArr[3]);
        ip_Int = p1 + p2 + p3 + p4; return ip_Int;
    }
    public static UInt32 IP2Int(string ipStr)
    {
        string[] ip = ipStr.Split('.');
        uint ipCode = 0xFFFFFF00 | byte.Parse(ip[3]);
        ipCode = ipCode & 0xFFFF00FF | (uint.Parse(ip[2]) << 0x8);
        ipCode = ipCode & 0xFF00FFFF | (uint.Parse(ip[1]) << 0xF);
        ipCode = ipCode & 0x00FFFFFF | (uint.Parse(ip[0]) << 0x18);
        return ipCode;
    }

    public static string Int2IP(UInt32 ipCode)
    {
        byte a = (byte)((ipCode & 0xFF000000) >> 0x18);
        byte b = (byte)((ipCode & 0x00FF0000) >> 0xF);
        byte c = (byte)((ipCode & 0x0000FF00) >> 0x8);
        byte d = (byte)(ipCode & 0x000000FF);
        string ipStr = String.Format("{0}.{1}.{2}.{3}", a, b, c, d);
        return ipStr;
    }
    #endregion

    #region MacAddress

    private static string GetMacAddress(string mac)
    {
        string strMac = mac.Replace(":", "-");
        if (!string.IsNullOrEmpty(strMac) && strMac.IndexOf('-') < 0)
        {
            string temp = strMac;
            strMac = "";
            while (temp.Length >= 1)
            {
                if (temp.Length >= 2)
                {
                    strMac += temp.Substring(0, 2) + "-";
                }
                else
                {
                    strMac += temp.PadLeft(2, '0') + '-';
                }
            }
            strMac = strMac.Trim('-');
        }
        return strMac;
    }

    ///<summary>
    /// 根据截取ipconfig /all命令的输出流获取网卡Mac
    ///</summary>
    ///<returns></returns>
    public static List<string> GetMacListByIPConfig()
    {
        List<string> macs = new List<string>();
        ProcessStartInfo startInfo = new ProcessStartInfo("ipconfig", "/all");
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardInput = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.CreateNoWindow = true;
        Process p = Process.Start(startInfo);
        //截取输出流
        StreamReader reader = p.StandardOutput;
        string line = reader.ReadLine();

        while (!reader.EndOfStream)
        {
            if (!string.IsNullOrEmpty(line))
            {
                line = line.Trim();

                if (line.StartsWith("Physical Address") || line.StartsWith("物理地址"))
                {
                    macs.Add(line);
                }
            }

            line = reader.ReadLine();
        }

        //等待程序执行完退出进程
        p.WaitForExit();
        p.Close();
        reader.Close();

        return macs;
    }

    public static string GetMacByIPConfig()
    {
        List<string> macs = GetMacListByIPConfig();

        if (macs == null || macs.Count <= 0)
        {
            return string.Empty;
        }
        else
        {
            return macs[0];
        }
    }

    ///<summary>
    /// 通过WMI读取系统信息里的网卡MAC
    /// 需要添加System.management引用
    ///</summary>
    ///<returns></returns>
    public static List<string> GetMacListByWMI()
    {
        List<string> macs = new List<string>();
        try
        {
            string mac = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"])
                {
                    mac = mo["MacAddress"].ToString();
                    mac = GetMacAddress(mac);
                    macs.Add(mac);
                }
            }
            moc = null;
            mc = null;
        }
        catch
        {
        }

        return macs;
    }

    public static string GetMacByWMI()
    {
        List<string> macs = GetMacListByWMI();

        if (macs == null || macs.Count <= 0)
        {
            return string.Empty;
        }
        else
        {
            return macs[0];
        }
    }

    /// <summary>
    /// 返回描述本地计算机上的网络接口的对象(网络接口也称为网络适配器)。
    /// </summary>
    private static NetworkInterface[] NetCardInfo()
    {
        return NetworkInterface.GetAllNetworkInterfaces();
    }

    ///<summary>
    /// 通过NetworkInterface读取网卡Mac
    ///</summary>
    ///<returns></returns>
    public static List<string> GetMacListByNetworkInterface()
    {
        List<string> macs = new List<string>();
        NetworkInterface[] interfaces = NetCardInfo();
        if (interfaces == null) return macs;

        PhysicalAddress pa;
        string mac;
        foreach (NetworkInterface ni in interfaces)
        {
            pa = ni.GetPhysicalAddress();
            if (string.IsNullOrEmpty(pa.ToString())) continue;

            mac = GetMacAddress(pa.ToString());
            macs.Add(mac);
        }
        return macs;
    }

    public static string GetMacByNetworkInterface()
    {
        List<string> macs = GetMacListByNetworkInterface();

        if (macs == null || macs.Count <= 0)
        {
            return string.Empty;
        }
        else
        {
            return macs[0];
        }
    }


    [DllImport("Iphlpapi.dll")]
    private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
    [DllImport("Ws2_32.dll")]
    private static extern Int32 inet_addr(string ip);
    ///<summary>
    /// 通过SendARP获取网卡Mac
    /// 网络被禁用或未接入网络（如没插网线）时此方法失灵
    ///</summary>
    ///<param name="remoteIP"></param>
    ///<returns></returns>
    public static string GetMacBySendARP(string remoteIP)
    {
        StringBuilder macAddress = new StringBuilder();

        try
        {
            Int32 remote = inet_addr(remoteIP);

            Int64 macInfo = new Int64();
            Int32 length = 6;
            SendARP(remote, 0, ref macInfo, ref length);

            string temp = Convert.ToString(macInfo, 16).PadLeft(12, '0').ToUpper();

            int x = 12;
            for (int i = 0; i < 6; i++)
            {
                if (i == 5)
                {
                    macAddress.Append(temp.Substring(x - 2, 2));
                }
                else
                {
                    macAddress.Append(temp.Substring(x - 2, 2) + "-");
                }
                x -= 2;
            }

            return macAddress.ToString();
        }
        catch
        {
            return macAddress.ToString();
        }
    }

    #endregion

    #region BOARD/CPU/DISK...

    /// <summary>
    /// 获取主板号
    /// </summary>
    /// <returns></returns>
    public static string GetMotherboardNumber()
    {
        string strbNumber = string.Empty;
        ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_baseboard");
        foreach (ManagementObject mo in mos.Get())
        {
            strbNumber = mo["SerialNumber"].ToString();
        }
        if (strbNumber.ToLower() == "none")
        {
            return string.Empty;
        }
        return strbNumber;
    }

    /// <summary>
    /// 获取CPU序列号 
    /// </summary>
    /// <returns></returns>
    public static string GetCpuID()
    {
        try
        {

            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
            }
            moc = null;
            mc = null;
            if (cpuInfo.ToLower() == "none")
            {
                return string.Empty;
            }
            return cpuInfo;
        }
        catch
        {
            return string.Empty;
        }
        finally
        {
        }
    }

    /// <summary>
    /// 获取硬盘ID 
    /// </summary>
    /// <returns></returns>
    public static string GetDiskID()
    {
        try
        {

            string HDid = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                HDid = mo.Properties["Model"].Value.ToString();
            }
            moc = null;
            mc = null;
            if (HDid.ToLower() == "none")
            {
                return string.Empty;
            }
            return HDid;
        }
        catch
        {
            return string.Empty;
        }
        finally
        {
        }

    }

    /// <summary> 
    /// 操作系统的登录用户名 
    /// </summary> 
    /// <returns></returns> 
    public static string GetUserName()
    {
        try
        {
            string st = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                st = mo["UserName"].ToString();
            }
            moc = null;
            mc = null;
            if (st.ToLower() == "none")
            {
                return string.Empty;
            }
            return st;
        }
        catch
        {
            return string.Empty;
        }
        finally
        {
        }

    }


    /// <summary> 
    /// PC类型 
    /// </summary> 
    /// <returns>x64/x86</returns> 
    public static string GetSystemType()
    {
        try
        {
            string st = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                st = mo["SystemType"].ToString();
            }
            moc = null;
            mc = null;
            if (st.ToLower() == "none")
            {
                return string.Empty;
            }
            return st;
        }
        catch
        {
            return string.Empty;
        }
        finally
        {
        }

    }

    /// <summary> 
    /// 物理内存 
    /// </summary> 
    /// <returns></returns> 
    public static string GetTotalPhysicalMemory()
    {
        try
        {
            string st = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                st = mo["TotalPhysicalMemory"].ToString();
            }
            moc = null;
            mc = null;
            if (st.ToLower() == "none")
            {
                return string.Empty;
            }
            return st;
        }
        catch
        {
            return string.Empty;
        }
        finally
        {
        }
    }

    /// <summary> 
    ///  获取电脑名
    /// </summary> 
    /// <returns></returns> 
    public static string GetComputerName()
    {
        try
        {
            return System.Environment.GetEnvironmentVariable("ComputerName");
        }
        catch
        {
            return string.Empty;
        }
        finally
        {
        }
    }
    #endregion

}

