﻿namespace SkiaSharpDemo
{
    partial class FrmMain
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
            this.skCtrl = new SkiaSharp.Views.Desktop.SKControl();
            this.bntShowSkGl = new System.Windows.Forms.Button();
            this.btnShowAero = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // skCtrl
            // 
            this.skCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.skCtrl.BackColor = System.Drawing.Color.Black;
            this.skCtrl.Location = new System.Drawing.Point(0, 0);
            this.skCtrl.Margin = new System.Windows.Forms.Padding(0);
            this.skCtrl.Name = "skCtrl";
            this.skCtrl.Size = new System.Drawing.Size(486, 774);
            this.skCtrl.TabIndex = 0;
            this.skCtrl.Text = "skControl1";
            // 
            // bntShowSkGl
            // 
            this.bntShowSkGl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntShowSkGl.Location = new System.Drawing.Point(997, 12);
            this.bntShowSkGl.Name = "bntShowSkGl";
            this.bntShowSkGl.Size = new System.Drawing.Size(203, 74);
            this.bntShowSkGl.TabIndex = 2;
            this.bntShowSkGl.Text = "显示SKGL";
            this.bntShowSkGl.UseVisualStyleBackColor = true;
            this.bntShowSkGl.Click += new System.EventHandler(this.bntShowSkGl_Click);
            // 
            // btnShowAero
            // 
            this.btnShowAero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAero.Location = new System.Drawing.Point(997, 119);
            this.btnShowAero.Name = "btnShowAero";
            this.btnShowAero.Size = new System.Drawing.Size(203, 74);
            this.btnShowAero.TabIndex = 3;
            this.btnShowAero.Text = "显示AeroForm";
            this.btnShowAero.UseVisualStyleBackColor = true;
            this.btnShowAero.Click += new System.EventHandler(this.btnShowAero_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(997, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 74);
            this.button1.TabIndex = 4;
            this.button1.Text = "显示AeroClient";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(997, 333);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 74);
            this.button2.TabIndex = 5;
            this.button2.Text = "显示AeroClient无边框";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // picBox
            // 
            this.picBox.Image = global::SkiaSharpDemo.Properties.Resources.Penguins;
            this.picBox.Location = new System.Drawing.Point(299, 200);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(295, 214);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 774);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnShowAero);
            this.Controls.Add(this.bntShowSkGl);
            this.Controls.Add(this.skCtrl);
            this.Controls.Add(this.picBox);
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aero Demo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SkiaSharp.Views.Desktop.SKControl skCtrl;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button bntShowSkGl;
        private System.Windows.Forms.Button btnShowAero;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

