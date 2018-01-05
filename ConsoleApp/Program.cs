using ConsoleApp.ServiceReference;
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
            List<ServiceReference.FilmDTO> ListeTemp = Test();

            Console.WriteLine(ListeTemp.Count);
            Console.ReadKey();
        }

        public static List<ServiceReference.FilmDTO> Test()
        {
            return new SmartWCFServiceClient().GetFilms("Film", "Star Wars", 0).ToList();
        }
    }
}
