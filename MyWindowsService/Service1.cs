using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyWindowsService
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer timer; //计时器
        private RabbitMqHelper rabbitMqHelper = new RabbitMqHelper();

        public Service1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 日志文件夹
        /// </summary>
        private string filePath =
            string.Format(ConfigurationManager.AppSettings["logFile"], DateTime.Now.ToString("yyyyMMdd"));

        /// <summary>
        /// 开启
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Append))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine($"{DateTime.Now},服务启动！");
            }

            ConfigurationManager.RefreshSection("appSettings"); // 刷新命名节，在下次检索它时将从磁盘重新读取它。
            var time = Math.Abs(int.Parse(ConfigurationManager.AppSettings["Time"]));
            timer = new Timer();
            timer.Interval = time; //设置计时器事件间隔执行时间  3秒
            timer.Elapsed += new ElapsedEventHandler(timer_Elaspsed);
            timer.AutoReset = true;
            timer.Enabled = true; //开启定时
        }

        /// <summary>
        /// 暂停
        /// </summary>
        protected override void OnStop()
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Append))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine($"{DateTime.Now},服务停止！");
            }
        }

        protected void timer_Elaspsed(object sender, ElapsedEventArgs e)
        {
            //todo 执行定时事件
            //filePath = string.Format(filePath, DateTime.Now.ToString("yyyyMMdd"));
            //using (FileStream stream = new FileStream(filePath, FileMode.Append))
            //using (StreamWriter writer = new StreamWriter(stream))
            //{
               // writer.WriteLine($"{DateTime.Now},正在在执行！");
                rabbitMqHelper.ReviceMessage(ConfigurationManager.AppSettings["QueueName"], MessageHandel);
            //}
        }

        private void MessageHandel(string message)
        {
            filePath = string.Format(filePath, DateTime.Now.ToString("yyyyMMdd"));
            using (FileStream stream = new FileStream(filePath, FileMode.Append))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine($"{DateTime.Now},正在在执行！");
                writer.WriteLine($"{DateTime.Now},{message}");
            }
        }
    }
}
