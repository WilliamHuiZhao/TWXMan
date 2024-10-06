using System;
using System.Collections.Generic;
using System.Management;
using System.Net;


namespace TWXMan
{
    class Computer
    {
        internal static class MacLocation
        {
            /// <summary>
            ///  通过WMI读取系统信息里的网卡MAC
            /// </summary>
            /// <returns></returns>
            public static List<string> GetMacByWMI()
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

            /// <summary>
            ///  获取网卡硬件地址
            /// </summary>
            /// <returns></returns>
            public static string GetComputerUserName()
            {
                try
                {
                    string st = "";
                    ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        st = mo["UserName"].ToString();
                    }
                    moc = null;
                    mc = null;
                    return st;
                }
                catch
                {
                    return "unknow";
                }
                finally
                {
                }
            }

            /// <summary>
            /// 获得客户端外网IP地址
            /// </summary>
            /// <returns>IP地址</returns>
            public static string getClientInternetIPAddress()
            {
                string internetAddress = "";
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        internetAddress = webClient.DownloadString("http://www.coridc.com/ip");//从外部网页获得IP地址
                                                                                               //判断IP是否合法
                        if (!System.Text.RegularExpressions.Regex.IsMatch(internetAddress, "[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}"))
                        {
                            internetAddress = webClient.DownloadString("http://fw.qq.com/ipaddress");//从腾讯提供的API中获得IP地址
                        }
                    }
                    return "外网IP地址：" + internetAddress;
                }
                catch
                {
                    return "外网IP地址：unknown";
                }
                finally
                {
                }
            }

            /// <summary>
            /// //获取硬盘ID
            /// </summary>
            /// <returns></returns>
            public static string GetDiskID()
            {
                try
                {
                    String HDid = "";
                    ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        //HDid =(string)mo.Properties["Model"].ToString();
                        HDid = (String)mo.Properties["Model"].Value.ToString();
                    }
                    moc = null;
                    mc = null;
                    return HDid;
                }
                catch
                {
                    return "unknow";
                }
                finally
                {
                }
            }

            /// <summary>
            /// 获取CPUid
            /// </summary>
            /// <returns></returns>
            public static string GetCpuID()

            {
                try
                {
                    //获取CPU序列号代码
                    string cpuInfo = "";//cpu序列号
                    ManagementClass mc = new ManagementClass("Win32_Processor");
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                    }

                    moc = null;
                    mc = null;
                    return cpuInfo;
                }
                catch
                {
                    return "unknow";
                }
                finally
                {
                }

            }


            /// <summary>
            /// 系统名称
            /// </summary>
            /// <returns></returns>
            public static string GetSystemType()
            {
                try
                {
                    string st = "";
                    ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        st = mo["SystemType"].ToString();
                    }

                    moc = null;
                    mc = null;
                    return st;

                }
                catch
                {
                    return "unknow";
                }
                finally
                {
                }
            }
        }
    }
}
