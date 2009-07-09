namespace SqlAliaser.UI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.aliasStatusNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aliasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAliasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aliasStatusImageList = new System.Windows.Forms.ImageList(this.components);
            this.serverToAliasLabel = new System.Windows.Forms.Label();
            this.serverToAliasTextBox = new System.Windows.Forms.TextBox();
            this.localCheckBox = new System.Windows.Forms.CheckBox();
            this.remoteCheckBox = new System.Windows.Forms.CheckBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // aliasStatusNotifyIcon
            // 
            this.aliasStatusNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.aliasStatusNotifyIcon.ContextMenuStrip = this.notifyIconContextMenu;
            this.aliasStatusNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("aliasStatusNotifyIcon.Icon")));
            this.aliasStatusNotifyIcon.Text = "SQL Alias Status - Local";
            this.aliasStatusNotifyIcon.Visible = true;
            this.aliasStatusNotifyIcon.DoubleClick += new System.EventHandler(this.aliasStatusNotifyIcon_DoubleClick);
            // 
            // notifyIconContextMenu
            // 
            this.notifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aliasToolStripMenuItem,
            this.removeAliasToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.notifyIconContextMenu.Name = "notifyIconContextMenu";
            this.notifyIconContextMenu.Size = new System.Drawing.Size(146, 76);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aliasToolStripMenuItem
            // 
            this.aliasToolStripMenuItem.Name = "aliasToolStripMenuItem";
            this.aliasToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aliasToolStripMenuItem.Text = "Alias {0}";
            this.aliasToolStripMenuItem.Click += new System.EventHandler(this.aliasToolStripMenuItem_Click);
            // 
            // removeAliasToolStripMenuItem
            // 
            this.removeAliasToolStripMenuItem.Name = "removeAliasToolStripMenuItem";
            this.removeAliasToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeAliasToolStripMenuItem.Text = "Remove Alias";
            this.removeAliasToolStripMenuItem.Click += new System.EventHandler(this.removeAliasToolStripMenuItem_Click);
            // 
            // aliasStatusImageList
            // 
            this.aliasStatusImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("aliasStatusImageList.ImageStream")));
            this.aliasStatusImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.aliasStatusImageList.Images.SetKeyName(0, "Remote");
            this.aliasStatusImageList.Images.SetKeyName(1, "Local");
            // 
            // serverToAliasLabel
            // 
            this.serverToAliasLabel.AutoSize = true;
            this.serverToAliasLabel.Location = new System.Drawing.Point(24, 24);
            this.serverToAliasLabel.Name = "serverToAliasLabel";
            this.serverToAliasLabel.Size = new System.Drawing.Size(77, 13);
            this.serverToAliasLabel.TabIndex = 0;
            this.serverToAliasLabel.Text = "Server to alias:";
            // 
            // serverToAliasTextBox
            // 
            this.serverToAliasTextBox.Location = new System.Drawing.Point(107, 21);
            this.serverToAliasTextBox.Name = "serverToAliasTextBox";
            this.serverToAliasTextBox.Size = new System.Drawing.Size(212, 20);
            this.serverToAliasTextBox.TabIndex = 1;
            this.serverToAliasTextBox.Text = "irc-scpc-sql01";
            this.serverToAliasTextBox.Validated += new System.EventHandler(this.serverToAliasTextBox_Validated);
            // 
            // localCheckBox
            // 
            this.localCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.localCheckBox.Location = new System.Drawing.Point(107, 64);
            this.localCheckBox.Name = "localCheckBox";
            this.localCheckBox.Size = new System.Drawing.Size(98, 28);
            this.localCheckBox.TabIndex = 4;
            this.localCheckBox.Text = "Local";
            this.localCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.localCheckBox.UseVisualStyleBackColor = true;
            this.localCheckBox.CheckedChanged += new System.EventHandler(this.localCheckBox_CheckedChanged);
            // 
            // remoteCheckBox
            // 
            this.remoteCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.remoteCheckBox.Location = new System.Drawing.Point(221, 64);
            this.remoteCheckBox.Name = "remoteCheckBox";
            this.remoteCheckBox.Size = new System.Drawing.Size(98, 28);
            this.remoteCheckBox.TabIndex = 5;
            this.remoteCheckBox.Text = "Remote";
            this.remoteCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.remoteCheckBox.UseVisualStyleBackColor = true;
            this.remoteCheckBox.CheckedChanged += new System.EventHandler(this.remoteCheckBox_CheckedChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 104);
            this.Controls.Add(this.remoteCheckBox);
            this.Controls.Add(this.localCheckBox);
            this.Controls.Add(this.serverToAliasTextBox);
            this.Controls.Add(this.serverToAliasLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SQL Aliaser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.notifyIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon aliasStatusNotifyIcon;
        private System.Windows.Forms.ImageList aliasStatusImageList;
        private System.Windows.Forms.Label serverToAliasLabel;
        private System.Windows.Forms.TextBox serverToAliasTextBox;
        private System.Windows.Forms.CheckBox localCheckBox;
        private System.Windows.Forms.CheckBox remoteCheckBox;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aliasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAliasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}

