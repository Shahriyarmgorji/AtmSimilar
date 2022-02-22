namespace ATM
{
    partial class FrmSplash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSplash));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.LblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBarX1
            // 
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.Location = new System.Drawing.Point(12, 435);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(712, 35);
            this.progressBarX1.TabIndex = 0;
            this.progressBarX1.Text = "progressBarX1";
            // 
            // LblWelcome
            // 
            this.LblWelcome.AutoSize = true;
            this.LblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.LblWelcome.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWelcome.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LblWelcome.Location = new System.Drawing.Point(125, 172);
            this.LblWelcome.Name = "LblWelcome";
            this.LblWelcome.Size = new System.Drawing.Size(335, 25);
            this.LblWelcome.TabIndex = 1;
            this.LblWelcome.Text = "نرم افزار شبیه ساز دستگاه عابر بانک";
            this.LblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ATM.Properties.Resources.SplashImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(736, 492);
            this.Controls.Add(this.LblWelcome);
            this.Controls.Add(this.progressBarX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSplash";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSplash";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private System.Windows.Forms.Label LblWelcome;
    }
}