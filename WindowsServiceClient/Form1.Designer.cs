namespace WindowsServiceClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.InstallService = new System.Windows.Forms.Button();
            this.StartService = new System.Windows.Forms.Button();
            this.StopService = new System.Windows.Forms.Button();
            this.UnInstallService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InstallService
            // 
            this.InstallService.Location = new System.Drawing.Point(36, 65);
            this.InstallService.Name = "InstallService";
            this.InstallService.Size = new System.Drawing.Size(75, 23);
            this.InstallService.TabIndex = 0;
            this.InstallService.Text = "安装服务";
            this.InstallService.UseVisualStyleBackColor = true;
            this.InstallService.Click += new System.EventHandler(this.InstallService_Click);
            // 
            // StartService
            // 
            this.StartService.Location = new System.Drawing.Point(194, 65);
            this.StartService.Name = "StartService";
            this.StartService.Size = new System.Drawing.Size(75, 23);
            this.StartService.TabIndex = 1;
            this.StartService.Text = "启动服务";
            this.StartService.UseVisualStyleBackColor = true;
            this.StartService.Click += new System.EventHandler(this.StartService_Click);
            // 
            // StopService
            // 
            this.StopService.Location = new System.Drawing.Point(344, 64);
            this.StopService.Name = "StopService";
            this.StopService.Size = new System.Drawing.Size(75, 23);
            this.StopService.TabIndex = 2;
            this.StopService.Text = "停止服务";
            this.StopService.UseVisualStyleBackColor = true;
            this.StopService.Click += new System.EventHandler(this.StopService_Click);
            // 
            // UnInstallService
            // 
            this.UnInstallService.Location = new System.Drawing.Point(485, 64);
            this.UnInstallService.Name = "UnInstallService";
            this.UnInstallService.Size = new System.Drawing.Size(75, 23);
            this.UnInstallService.TabIndex = 3;
            this.UnInstallService.Text = "卸载服务";
            this.UnInstallService.UseVisualStyleBackColor = true;
            this.UnInstallService.Click += new System.EventHandler(this.UnInstallService_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UnInstallService);
            this.Controls.Add(this.StopService);
            this.Controls.Add(this.StartService);
            this.Controls.Add(this.InstallService);
            this.Name = "Form1";
            this.Text = "安装测试服务";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InstallService;
        private System.Windows.Forms.Button StartService;
        private System.Windows.Forms.Button StopService;
        private System.Windows.Forms.Button UnInstallService;
    }
}

