using ConsoleApp.SmartWCFServiceReference;
using DTOLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartWCFServiceClient Service = new SmartWCFServiceClient();

            DateTime Date = DateTime.Now.AddDays(-1.0);

            Console.WriteLine(Date.Day);
            Console.WriteLine(Date.Month);
            Console.WriteLine(Date.Year);

            /*List<HitsDTO> HitsFilms = Service.GetHitsFilms().ToList();
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
            Service.AddStatistiques(dFilms, dActeurs);*/

            Console.ReadKey();
        }
    }
}
