using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SqlAliaser.UI
{
    public partial class Form1 : Form
    {
        private Latch _latch = new Latch();
        private string NotifyIconTextFormat = "SQL Alias for '{0}' - {1}";
        private bool _shuttingDown = false;

        public Form1()
        {
            InitializeComponent();

            SetUIStateFromRegistry();
        }

        private void SetUIStateFromRegistry()
        {
            this._latch.RunInsideLatch(() =>
                                 {
                                     var server = serverToAliasTextBox.Text;

                                     var state = GetAliasState(server);
                                     aliasToolStripMenuItem.Text = string.Format("Alias {0}", server);

                                     if (state == AliasState.NotAliased)
                                     {
                                         remoteCheckBox.Checked = true;
                                         localCheckBox.Checked = false;
                                         aliasToolStripMenuItem.Visible = true;
                                         removeAliasToolStripMenuItem.Visible = false;
                                         aliasStatusNotifyIcon.Icon = Icon.FromHandle(((Bitmap)aliasStatusImageList.Images["Remote"]).GetHicon()); ;
                                         aliasStatusNotifyIcon.Text = string.Format(NotifyIconTextFormat, server, "Not Aliased");
                                     }
                                     else
                                     {
                                         remoteCheckBox.Checked = false;
                                         localCheckBox.Checked = true;
                                         aliasToolStripMenuItem.Visible = false;
                                         removeAliasToolStripMenuItem.Visible = true;
                                         aliasStatusNotifyIcon.Icon = Icon.FromHandle(((Bitmap)aliasStatusImageList.Images["Local"]).GetHicon()); ;
                                         aliasStatusNotifyIcon.Text = string.Format(NotifyIconTextFormat, server, "Aliased!");
                                     }

                                     aliasStatusNotifyIcon.BalloonTipText = aliasStatusNotifyIcon.Text;
                                     aliasStatusNotifyIcon.ShowBalloonTip(1500);
                                     Icon = aliasStatusNotifyIcon.Icon;
                                 });
        }

        private AliasState GetAliasState(string remoteServer)
        {
            RegistryKey key = GetAliasKey32();
            if (key != null)
            {
                var serverAlias = key.GetValue(remoteServer);
                if (serverAlias == null) return AliasState.NotAliased;

                if (serverAlias.ToString() == string.Format("{0}_disabled", remoteServer))
                    return AliasState.NotAliased;

                return AliasState.Local;
            }

            return AliasState.NotAliased;
        }

        private void DisableAlias(string remoteServer)
        {
            UnsetAlias(GetAliasKey32, remoteServer);
            UnsetAlias(GetAliasKey64, remoteServer);

            SetUIStateFromRegistry();
        }

        private void EnableAlias(string remoteServer)
        {
            SetAlias(GetAliasKey32, remoteServer);
            SetAlias(GetAliasKey64, remoteServer);

            SetUIStateFromRegistry();
        }

        private void UnsetAlias(Func<RegistryKey> getKeyFunc, string remoteServer)
        {
            var key = getKeyFunc();
            if (key.GetValue(remoteServer) != null) key.DeleteValue(remoteServer);
        }

        private void SetAlias(Func<RegistryKey> getKeyFunc, string remoteServer)
        {
            var key = getKeyFunc();
            key.SetValue(remoteServer, @"DBNMPNTW,\\localhost\PIPE\sql\query");
        }

        private RegistryKey GetAliasKey32()
        {
            return OpenWritableLocalMachineKey(@"SOFTWARE\Microsoft\MSSQLServer\Client\ConnectTo");
        }

        private RegistryKey GetAliasKey64()
        {
            return OpenWritableLocalMachineKey(@"SOFTWARE\Wow6432Node\Microsoft\MSSQLServer\Client\ConnectTo");
        }

        private RegistryKey OpenWritableLocalMachineKey(string key)
        {
            return Registry.LocalMachine.OpenSubKey(key, true);
        }

        private void localCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _latch.RunIfNotLatched(() => EnableAlias(serverToAliasTextBox.Text));
        }

        private void remoteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _latch.RunIfNotLatched(() => DisableAlias(this.serverToAliasTextBox.Text));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shuttingDown = true;
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_shuttingDown)
            {
                ShowInTaskbar = false;
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void aliasStatusNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void removeAliasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableAlias(serverToAliasTextBox.Text);
        }

        private void aliasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableAlias(serverToAliasTextBox.Text);
        }

        private void serverToAliasTextBox_Validated(object sender, EventArgs e)
        {
            SetUIStateFromRegistry();
        }
    }
}
