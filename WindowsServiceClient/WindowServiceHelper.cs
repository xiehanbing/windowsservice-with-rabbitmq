using System.Collections;
using System.Configuration.Install;
using System.ServiceProcess;

namespace WindowsServiceClient
{
    public class WindowServiceHelper
    {
        /// <summary>
        /// 判断服务是否存在
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <returns></returns>
        public bool IsServiceExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController sc in services)
            {
                if (sc.ServiceName.ToLower() == serviceName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 安装服务
        /// </summary>
        /// <param name="serviceFilePath">服务地址</param>
        public void InstallService(string serviceFilePath)
        {
            using (AssemblyInstaller installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = serviceFilePath;
                IDictionary savedState = new Hashtable();
                installer.Install(savedState);
                installer.Commit(savedState);
            }
        }

        /// <summary>
        /// 卸载服务
        /// </summary>
        /// <param name="serviceFilePath">服务地址</param>
        public void UninstallService(string serviceFilePath)
        {
            using (AssemblyInstaller installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = serviceFilePath;
                installer.Uninstall(null);
            }
        }
        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        public void ServiceStart(string serviceName)
        {
            using (ServiceController control = new ServiceController(serviceName))
            {
                //如果在停止状态 则启动
                if (control.Status == ServiceControllerStatus.Stopped)
                {
                    
                    control.Start();
                }
            }
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        public void ServiceStop(string serviceName)
        {
            using (ServiceController control = new ServiceController(serviceName))
            {
                //如果在运行状态，则停止
                if (control.Status == ServiceControllerStatus.Running)
                {
                    control.Stop();
                }
            }
        }
    }
}