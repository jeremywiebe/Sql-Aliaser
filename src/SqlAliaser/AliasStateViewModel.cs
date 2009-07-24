using System.ComponentModel;
using System.Drawing;

namespace SqlAliaser
{
    public class AliasStateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private const string ButtonTextAliased = "Remove Alias!";
        private const string ButtonTextNotAliased = "Alias It!";

        private readonly IAliasStateProvider _provider;

        private string _aliasButtonText;
        private string _aliasState;
        private StateIcons _stateIcons;
        private Icon _windowIcon;

        public AliasStateViewModel(IAliasStateProvider provider, string serverName)
        {
            this._provider = provider;
            this.ServerName = serverName;
            this._stateIcons = new StateIcons();

            OnAliasStateChanged(string.Empty);
        }

        public bool HasAlias
        {
            get { return this._provider.HasAlias; }
        }

        public string ServerName { get; set; }

        public string AliasButtonText
        {
            get { return this._aliasButtonText; }
        }

        public string AliasState
        {
            get { return this._aliasState; }
        }

        public Color ServerTextBoxBackgroundColor { get; set; }

        public Icon WindowIcon
        {
            get { return this._windowIcon;  }
        }

        public bool CanChangeServerName
        {
            get
            {
                return !this.HasAlias;
            }
        }

        public void AliasUsingNamedPipes()
        {
            this._provider.AliasUsingNamedPipes();
            OnAliasStateChanged(string.Empty);
        }

        public void RemoveAlias()
        {
            this._provider.RemoveAlias();
            OnAliasStateChanged(string.Empty);
        }

        protected void OnAliasStateChanged(string propertyName)
        {
            if (this.HasAlias)
            {
                this._aliasButtonText = ButtonTextAliased;
                this.ServerTextBoxBackgroundColor = Color.Gray;
                this._aliasState = "Aliased " + this.ServerName;
                this._windowIcon = this._stateIcons.Aliased;
            }
            else
            {
                this._aliasButtonText = ButtonTextNotAliased;
                this.ServerTextBoxBackgroundColor = SystemColors.Window;
                this._aliasState = "Not Aliased " + this.ServerName;
                this._windowIcon = this._stateIcons.NotAliased;
            }
            
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}