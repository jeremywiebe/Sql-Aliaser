namespace SqlAliaser
{
    partial class AliasConfigForm
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AliasConfigForm));
            this.aliasStatusNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aliasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aliasStatusImageList = new System.Windows.Forms.ImageList(this.components);
            this.serverToAliasLabel = new System.Windows.Forms.Label();
            this.serverToAliasTextBox = new System.Windows.Forms.TextBox();
            this.aliasButton = new System.Windows.Forms.Button();
            this.notifyIconContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).BeginInit();
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
            this.notifyIconContextMenu.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "AliasState", true));
            this.notifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aliasToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.notifyIconContextMenu.Name = "notifyIconContextMenu";
            this.notifyIconContextMenu.Size = new System.Drawing.Size(140, 54);
            // 
            // stateBindingSource
            // 
            this.stateBindingSource.DataSource = typeof(SqlAliaser.AliasStateViewModel);
            // 
            // aliasToolStripMenuItem
            // 
            this.aliasToolStripMenuItem.Name = "aliasToolStripMenuItem";
            this.aliasToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.aliasToolStripMenuItem.Text = "Toggle Alias";
            this.aliasToolStripMenuItem.Click += new System.EventHandler(this.aliasToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            this.serverToAliasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "ServerName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.serverToAliasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.stateBindingSource, "ServerTextBoxBackgroundColor", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.serverToAliasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("ReadOnly", this.stateBindingSource, "HasAlias", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.serverToAliasTextBox.Location = new System.Drawing.Point(107, 21);
            this.serverToAliasTextBox.Name = "serverToAliasTextBox";
            this.serverToAliasTextBox.Size = new System.Drawing.Size(212, 20);
            this.serverToAliasTextBox.TabIndex = 1;
            this.serverToAliasTextBox.Text = "irc-scpc-sql02";
            // 
            // aliasButton
            // 
            this.aliasButton.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "AliasButtonText", true));
            this.aliasButton.Location = new System.Drawing.Point(107, 59);
            this.aliasButton.Name = "aliasButton";
            this.aliasButton.Size = new System.Drawing.Size(212, 33);
            this.aliasButton.TabIndex = 2;
            this.aliasButton.Text = "Alias It!";
            this.aliasButton.UseVisualStyleBackColor = true;
            this.aliasButton.Click += new System.EventHandler(this.aliasButton_Click);
            // 
            // AliasConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 104);
            this.Controls.Add(this.aliasButton);
            this.Controls.Add(this.serverToAliasTextBox);
            this.Controls.Add(this.serverToAliasLabel);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Icon", this.stateBindingSource, "WindowIcon", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AliasConfigForm";
            this.Text = "SQL Aliaser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.notifyIconContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon aliasStatusNotifyIcon;
        private System.Windows.Forms.ImageList aliasStatusImageList;
        private System.Windows.Forms.Label serverToAliasLabel;
        private System.Windows.Forms.TextBox serverToAliasTextBox;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aliasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.BindingSource stateBindingSource;
        private System.Windows.Forms.Button aliasButton;
    }
}