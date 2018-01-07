using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SmartStatService
{
    public partial class Service : ServiceBase
    {
        private Timer timer = null;

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();

            DateTime now = DateTime.Now;

            timer.Interval = new DateTime(now.Year, now.Month, now.Day + 1, 0, 0, 0, DateTimeKind.Local).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            timer.Elapsed += new ElapsedEventHandler(timer_Tick);
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, ElapsedEventArgs e)
        {
            ServiceReference.SmartWCFServiceClient Service = new ServiceReference.SmartWCFServiceClient();

            Service.TopThreeFilms();
            Service.TopThreeActors();

            Service = null;

            if(timer.Interval != (1000 * 60 * 60 * 24))
                timer.Interval = (1000 * 60 * 60 * 24); // 1s * 60 = 1m => 1m * 60 = 1h => 1h * 24 = 1j
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("Arrêt de mon service", EventLogEntryType.Information);
        }
    }
}
