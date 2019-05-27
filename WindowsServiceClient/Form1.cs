using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
namespace WindowsServiceClient
{
    public partial class Form1 : Form
    {
        private readonly string _serviceFilePath = $"{Application.StartupPath}\\MyWindowsService.exe";
        private readonly string _serviceName = "MyService";
        private readonly WindowServiceHelper windowServiceHelper = new WindowServiceHelper();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 安装服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InstallService_Click(object sender, EventArgs e)
        {
            //如果存在 先卸载 再安装
            if (windowServiceHelper.IsServiceExisted(_serviceName))
                windowServiceHelper.UninstallService(_serviceFilePath);
            windowServiceHelper.InstallService(_serviceFilePath);
            MessageBox.Show("安装成功");
        }
        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartService_Click(object sender, EventArgs e)
        {
            if (windowServiceHelper.IsServiceExisted(_serviceName))
                windowServiceHelper.ServiceStart(_serviceName);
            MessageBox.Show("启动成功");
        }
        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopService_Click(object sender, EventArgs e)
        {
            if (windowServiceHelper.IsServiceExisted(_serviceName))
            {
                windowServiceHelper.ServiceStop(_serviceName);
            }
            MessageBox.Show("停止成功");
        }
        /// <summary>
        /// 卸载服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnInstallService_Click(object sender, EventArgs e)
        {
            if (windowServiceHelper.IsServiceExisted(_serviceName))
            {
                windowServiceHelper.ServiceStop(_serviceName);
                windowServiceHelper.UninstallService(_serviceFilePath);
            }
            MessageBox.Show("卸载成功");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
