using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTClient;
using System.Diagnostics;
using M2Mqtt;


namespace CPUUsage
{


    public class CPUUsageExample 
    {
        public static Process targetProcess;
        public static PerformanceCounter cpuCounter;

        //public static void Main()
        //{
        //    // 创建 PerformanceCounter 对象并设置相关参数
        //    cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        //    // 获取当前进程的 CPU 使用率
        //    float cpuUsage = GetCPUUsage();

        //    Console.WriteLine($"CPU Usage: {cpuUsage}%");
        //    Console.ReadLine();
        //}

        public static float GetProcessCPUUsage()
        {
            // 通过 PerformanceCounter 获取 CPU 使用率百分比
            float cpuUsage = cpuCounter.NextValue();

            // 等待一段时间，以便下一次获取 CPU 使用率时能够获得正确的值
            System.Threading.Thread.Sleep(1000);

            // 再次获取 CPU 使用率
            cpuUsage = cpuCounter.NextValue();

            return cpuUsage;
        }




    }

}
