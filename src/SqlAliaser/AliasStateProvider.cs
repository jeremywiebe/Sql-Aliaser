using Microsoft.Win32;

namespace SqlAliaser
{
    public interface IAliasStateProvider
    {
        bool HasAlias { get; }
        void AliasUsingNamedPipes();
        void RemoveAlias();
    }

    public class AliasStateProvider : IAliasStateProvider
    {
        private const string SqlAliasKey32 = @"SOFTWARE\Microsoft\MSSQLServer\Client\ConnectTo";
        private const string SqlAliasKey64 = @"SOFTWARE\Wow6432Node\Microsoft\MSSQLServer\Client\ConnectTo";
        private const string NamedPipeAlias = @"DBNMPNTW,\\localhost\PIPE\sql\query";

        private readonly string _serverName;

        private RegistryKey _key32;
        private RegistryKey _key64;

        public AliasStateProvider(string serverName)
        {
            this._serverName = serverName;

            this._key32 = Registry.LocalMachine.OpenSubKey(SqlAliasKey32, true);
            this._key64 = Registry.LocalMachine.OpenSubKey(SqlAliasKey64, true);
        }

        public bool HasAlias
        {
            get
            {
                var value = this._key64.GetValue(this._serverName);
                if (value != null) return true;

                value = this._key32.GetValue(this._serverName);
                if (value != null) return true;

                return false;
            }
        }

        public void AliasUsingNamedPipes()
        {
            this._key32.SetValue(this._serverName, NamedPipeAlias);
            this._key64.SetValue(this._serverName, NamedPipeAlias);
        }

        public void RemoveAlias()
        {
            this._key32.DeleteValue(this._serverName);
            this._key64.DeleteValue(this._serverName);
        }
    }
}