using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SqlAliaser
{
    public partial class AliasConfigForm : Form
    {
        private Latch _latch = new Latch();
        private bool _shuttingDown = false;
        private AliasStateProvider _stateProvider;
        private AliasStateViewModel _viewModel;

        public AliasConfigForm()
        {
            InitializeComponent();

            this._stateProvider = new AliasStateProvider(this.serverToAliasTextBox.Text);
            this._viewModel = new AliasStateViewModel(this._stateProvider, "irc-scpc-sql01");
            this._viewModel.PropertyChanged += AliasStateChanged;
            this.stateBindingSource.DataSource = this._viewModel;

            SetUIStateFromProvider();
        }

        private void AliasStateChanged(object sender, PropertyChangedEventArgs e)
        {
            SetUIStateFromProvider();  
        }

        private void SetUIStateFromProvider()
        {
            this._latch.RunInsideLatch(() =>
                                       {
                                           // A few things which we can't databind to.
                                           this.aliasStatusNotifyIcon.Text = this._viewModel.AliasState;
                                           this.aliasStatusNotifyIcon.BalloonTipText = this.aliasStatusNotifyIcon.Text;
                                           this.aliasStatusNotifyIcon.ShowBalloonTip(1500);
                                           this.aliasStatusNotifyIcon.Icon = this._viewModel.WindowIcon;
                                       });
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._shuttingDown = true;
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this._shuttingDown)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void aliasStatusNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
        }

        private void aliasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleAliasMode();
        }

        private void aliasButton_Click(object sender, EventArgs e)
        {
            ToggleAliasMode();
        }

        private void ToggleAliasMode()
        {
            if (this._viewModel.HasAlias)
                this._viewModel.RemoveAlias();
            else
                this._viewModel.AliasUsingNamedPipes();
        }
    }
}