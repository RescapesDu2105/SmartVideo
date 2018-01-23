using DTOLib;
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

            timer.Interval = new DateTime(now.Year, now.Month, now.Day + 1, 0, 0, 0, DateTimeKind.Utc).ToUniversalTime().Subtract(now).TotalMilliseconds;
            timer.Elapsed += new ElapsedEventHandler(timer_Tick);
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, ElapsedEventArgs e)
        {
            ServiceReference.SmartWCFServiceClient Service = new ServiceReference.SmartWCFServiceClient();

            List<HitsDTO> HitsFilms = Service.GetHitsFilms().ToList();
            List<HitsDTO> HitsActeurs = Service.GetHitsActeurs().ToList();
            Dictionary<int, int> dFilms = new Dictionary<int, int>();
            Dictionary<int, int> dActeurs = new Dictionary<int, int>();

            Console.WriteLine(HitsFilms.Count);
            foreach (HitsDTO hits in HitsFilms)
            {
                //Console.WriteLine(hits.IdType);
                if (!dFilms.ContainsKey(hits.IdType))
                    dFilms.Add(hits.IdType, 1);
                else
                    dFilms[hits.IdType] = dFilms[hits.IdType] + 1;
            }
            dFilms = dFilms.OrderByDescending(t => t.Value).Take(3).ToDictionary(pair => pair.Key, pair => pair.Value);


            Console.WriteLine(HitsActeurs.Count);
            foreach (HitsDTO hits in HitsActeurs)
            {
                //Console.WriteLine(hits.IdType);
                if (!dActeurs.ContainsKey(hits.IdType))
                    dActeurs.Add(hits.IdType, 1);
                else
                    dActeurs[hits.IdType] = dActeurs[hits.IdType] + 1;
            }
            dActeurs = dActeurs.OrderByDescending(t => t.Value).Take(3).ToDictionary(pair => pair.Key, pair => pair.Value);

            //Add dans Statistiques
            Service.AddStatistiques(dFilms, dActeurs);

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
