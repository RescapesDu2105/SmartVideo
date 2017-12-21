namespace SmartVideoWindowsService
{
    partial class SmartVideoWindowsServiceInstaller
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.processInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller1
            // 
            this.processInstaller.Password = null;
            this.processInstaller.Username = null;
            this.processInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.ServiceProcessInstaller_AfterInstall);
            // 
            // serviceInstaller1
            // 
            this.serviceInstaller.ServiceName = "SmartVideoWindowsService";
            this.serviceInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.ServiceInstaller_AfterInstall);
            // 
            // SmartVideoWindowsServiceInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.processInstaller,
            this.serviceInstaller});

        }

        #endregion
    }
}