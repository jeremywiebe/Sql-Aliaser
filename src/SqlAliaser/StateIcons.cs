using System.Drawing;
using System.IO;
using System.Reflection;

namespace SqlAliaser
{
    public class StateIcons
    {
        private Icon _aliased;
        private Icon _notAliased;

        public StateIcons()
        {
            _aliased = new Icon(GetIconStreamFromResource("Aliased.ico"));
            _notAliased = new Icon(GetIconStreamFromResource("NotAliased.ico"));
        }

        private Stream GetIconStreamFromResource(string filename)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(GetIconResourceKey(filename));
        }

        private string GetIconResourceKey(string iconFilename)
        {
            return "{0}.Icons.{1}".FormatWith(GetType().Namespace, iconFilename);
        }

        public Icon Aliased
        {
            get { return _aliased; }
        }

        public Icon NotAliased
        {
            get { return _notAliased; }
        }
    }
}