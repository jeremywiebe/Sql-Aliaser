using System;
using System.ComponentModel;
using System.Windows.Forms;
using SqlAliaser.Properties;

namespace SqlAliaser
{
    public partial class AliasConfigForm : Form
    {
        private Latch _latch = new Latch();
        private bool _shuttingDown = false;
        private AliasStateProvider _stateProvider;
        private AliasStateViewModel _viewModel;
        private AliasStateViewModel _model;
        private Growler _growler;

        public AliasConfigForm()
        {
            InitializeComponent();

            _stateProvider = new AliasStateProvider(serverToAliasTextBox.Text);

            _growler = new Growler();
            _growler.Register();

            _model = _viewModel = new AliasStateViewModel(_stateProvider, Settings.Default.ServerToAlias, _growler);
            _viewModel.PropertyChanged += AliasStateChanged;
            stateBindingSource.DataSource = _viewModel;

            SetUIStateFromProvider();
        }

        private void AliasStateChanged(object sender, PropertyChangedEventArgs e)
        {
            SetUIStateFromProvider();  
        }

        private void SetUIStateFromProvider()
        {
            _latch.RunInsideLatch(() =>
                                       {
                                           // A few things which we can't databind to.
                                           aliasStatusNotifyIcon.Text = this._viewModel.AliasState;
                                           aliasStatusNotifyIcon.BalloonTipText = this.aliasStatusNotifyIcon.Text;
                                           aliasStatusNotifyIcon.ShowBalloonTip(1500);
                                           aliasStatusNotifyIcon.Icon = this._viewModel.WindowIcon;
                                       });
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
                Hide();
                e.Cancel = true;
            }
            else
            {
                _growler.NotifyClosed();
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
            if (_viewModel.HasAlias)
                _viewModel.RemoveAlias();
            else
                _viewModel.AliasUsingNamedPipes();
        }
    }
}