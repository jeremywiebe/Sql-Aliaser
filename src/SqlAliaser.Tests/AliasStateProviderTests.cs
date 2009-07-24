using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using Xunit;

namespace SqlAliaser.Tests
{
    public class AliasStateProviderTests : IDisposable
    {
        protected const string ServerName = "TestServer8FC7A27DC2E9469CA64F30CFF846933D";

        private RegistryKey _key32;
        private RegistryKey _key64;

        public AliasStateProviderTests()
        {
            this._key32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\MSSQLServer\Client\ConnectTo", true);
            this._key64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\MSSQLServer\Client\ConnectTo", true);

            if (_key32.GetValue(ServerName) != null) this._key32.DeleteValue(ServerName);
            if (_key64.GetValue(ServerName) != null) this._key64.DeleteValue(ServerName);
        }

        public void Dispose()
        {
            try { if (_key32 != null) _key32.DeleteValue(ServerName); } catch { }
            try { if (_key64 != null) _key64.DeleteValue(ServerName); } catch { }
        }

        [Fact]
        public void ShouldBeUnaliasedWhenNoRegistryKeyExistsInEitherThe32BitOr64BitPathForTheSpecifiedServerName()
        {
            var aliaser = new AliasStateProvider(ServerName);

            Assert.False(aliaser.HasAlias);
        }

        [Fact]
        public void ShouldBeAliasedWhen32BitValueForSpecifiedServerExists()
        {
            _key32.SetValue(ServerName, "Sample");

            var aliaser = new AliasStateProvider(ServerName);
            Assert.True(aliaser.HasAlias);
        }

        [Fact]
        public void ShouldBeAliasedWhen64BitValueForSpecifiedServerExists()
        {
            _key64.SetValue(ServerName, "Sample");

            var aliaser = new AliasStateProvider(ServerName);
            Assert.True(aliaser.HasAlias);
        }

        [Fact]
        public void ShouldSetRegistryValueIn32BitKeyWhenAliased()
        {
            var aliaser = new AliasStateProvider(ServerName);
            aliaser.AliasUsingNamedPipes();

            Assert.NotNull(_key32.GetValue(ServerName));
        }

        [Fact]
        public void ShouldSetRegistryValueIn64BitKeyWhenAliased()
        {
            var aliaser = new AliasStateProvider(ServerName);
            aliaser.AliasUsingNamedPipes();

            Assert.NotNull(_key64.GetValue(ServerName));
        }

        [Fact]
        public void ShouldRemoveRegistryValueIn32BitKeyWhenAliasRemoved()
        {
            this._key32.SetValue(ServerName, "Sample");
            
            var aliaser = new AliasStateProvider(ServerName);
            aliaser.RemoveAlias();

            Assert.Null(_key32.GetValue(ServerName));
        }

        [Fact]
        public void ShouldRemoveRegistryValueIn64BitKeyWhenAliasRemoved()
        {
            this._key64.SetValue(ServerName, "Sample");

            var aliaser = new AliasStateProvider(ServerName);
            aliaser.RemoveAlias();

            Assert.Null(_key64.GetValue(ServerName));

        }
    }
}
