using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace SmartVideoWindowsService
{
    [RunInstaller(true)]
    public partial class SmartVideoWindowsServiceInstaller : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller processInstaller;
        private ServiceInstaller serviceInstaller;

        public SmartVideoWindowsServiceInstaller()
        {
            //InitializeComponent();
            
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = "SmartVideoWindowsService";
            //serviceInstaller.DisplayName = "SmartVideoWindowsService";
            //serviceInstaller.Description = "WCF SmartVideo Service Hosted by Windows NT Service";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }

        private void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {

        }

        private void ServiceProcessInstaller_AfterInstall(object sender, InstallEventArgs e)
        {

        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);

            EventLog.WriteEntry("SmartVideoWindowsService", "Installation du service SmartVideo", EventLogEntryType.Information);
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);
            EventLog.WriteEntry("SmartVideoWindowsService", "Désinstallation du service SmartVideo", EventLogEntryType.Information);
        }

    }
}
