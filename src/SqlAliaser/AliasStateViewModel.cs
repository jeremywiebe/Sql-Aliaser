using System.ComponentModel;
using System.Drawing;

namespace SqlAliaser
{
    public class AliasStateViewModel : INotifyPropertyChanged
    {
        private const string ButtonTextAliased = "Remove Alias!";
        private const string ButtonTextNotAliased = "Alias It!";

        private readonly Growler _growler;
        private readonly IAliasStateProvider _provider;

        private string _aliasButtonText;
        private string _aliasState;
        private StateIcons _stateIcons;
        private Icon _windowIcon;

        public AliasStateViewModel(IAliasStateProvider provider, string serverName, Growler growler)
        {
            _provider = provider;
            _growler = growler;
            ServerName = serverName;
            _stateIcons = new StateIcons();

            OnAliasStateChanged(string.Empty);
        }

        public bool HasAlias
        {
            get { return _provider.HasAlias; }
        }

        public string ServerName { get; set; }

        public string AliasButtonText
        {
            get { return _aliasButtonText; }
        }

        public string AliasState
        {
            get { return _aliasState; }
        }

        public Color ServerTextBoxBackgroundColor { get; set; }

        public Icon WindowIcon
        {
            get { return _windowIcon; }
        }

        public bool CanChangeServerName
        {
            get { return !HasAlias; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #endregion

        public void AliasUsingNamedPipes()
        {
            _provider.AliasUsingNamedPipes();
            OnAliasStateChanged(string.Empty);
        }

        public void RemoveAlias()
        {
            _provider.RemoveAlias();
            OnAliasStateChanged(string.Empty);
        }

        protected void OnAliasStateChanged(string propertyName)
        {
            if (HasAlias)
            {
                _aliasButtonText = ButtonTextAliased;
                ServerTextBoxBackgroundColor = Color.Gray;
                _aliasState = "Aliased " + ServerName;
                _windowIcon = _stateIcons.Aliased;
                _growler.NotifyAliased(ServerName);
            }
            else
            {
                _aliasButtonText = ButtonTextNotAliased;
                ServerTextBoxBackgroundColor = SystemColors.Window;
                _aliasState = "Not Aliased " + ServerName;
                _windowIcon = _stateIcons.NotAliased;
                _growler.NotifyNotAliased(ServerName);
            }

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}