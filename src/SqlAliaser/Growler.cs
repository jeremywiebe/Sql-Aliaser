using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using Growl.Connector;
using Growl.CoreLibrary;

namespace SqlAliaser
{
    public class Growler
    {
        private GrowlConnector _connector;
        private Application _application;
        private NotificationType _aliasedNotification;
        private NotificationType _notAliasedNotification;
        private NotificationType _closedNotification;

        public Growler()
        {
            _connector = new GrowlConnector();
        }

        public void Register()
        {
            var name = "SQL Aliaser";

            var icons = new StateIcons();

            _application = new Application(name) {
                                                     Icon = new BinaryData(GetIconBytes(icons.NotAliased))
                                                 };

            Resource aliasedIcon = new BinaryData(GetIconBytes(icons.Aliased));
            Resource notAliasedIcon = new BinaryData(GetIconBytes(icons.NotAliased));

            _aliasedNotification = new NotificationType("Aliased", "Aliased", aliasedIcon, true);
            _notAliasedNotification = new NotificationType("NotAliased", "Not Aliased", notAliasedIcon, true);
            _closedNotification = new NotificationType("Closed", "Shut Down");
            _connector.Register(_application, new[] { _aliasedNotification, _notAliasedNotification, _closedNotification });
        }

        public void NotifyAliased(string serverThatWasAliased)
        {
            var notification = new Notification(_application.Name, _aliasedNotification.Name, null, "Aliased {0}".FormatWith(serverThatWasAliased), "The remote server {0} is now aliased to your local SQL Server instance.".FormatWith(serverThatWasAliased));
            _connector.Notify(notification);
        }

        public void NotifyNotAliased(string serverThatIsNoLongerAliased)
        {
            var notification = new Notification(_application.Name, _aliasedNotification.Name, null, "Removed alias {0}".FormatWith(serverThatIsNoLongerAliased), "The remote server {0} is no longer aliased.".FormatWith(serverThatIsNoLongerAliased));
            _connector.Notify(notification);
        }

        private byte[] GetIconBytes(Icon icon)
        {
            using (var ms = new MemoryStream())
            {
                icon.Save(ms);
                ms.Flush();
                return ms.GetBuffer();
            }
        }

        public void NotifyClosed()
        {
            var notification = new Notification(_application.Name, _closedNotification.Name, null, "Closed {0}".FormatWith(_application.Name), "{0} has shut down.  Aliases will remain as they were set prior to shutdown".FormatWith(_application.Name));
            _connector.Notify(notification);
        }
    }
}