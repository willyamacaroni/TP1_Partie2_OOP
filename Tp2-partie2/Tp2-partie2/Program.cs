using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationLoterie;
using Utilitaires;

namespace Tp2_partie2
{
    class Program
    {
        static void Main(string[] args)
        {
            GestionnaireTirages GestionnaireTirages = new GestionnaireTirages();
            int nbMises;
            string choixMenu;
            bool GestionnaireTiragesExiste = false;
            do
            {
                Console.Clear();
                Console.WriteLine("[1]\tGénération de données");
                Console.WriteLine("[2]\tRésultats des tirages");
                Console.WriteLine("[3]\tSommaire des résultats");
                Console.WriteLine("[4]\tAuteur");
                Console.WriteLine("[5]\tQuitter");
                Console.WriteLine();
                Console.Write("Votre choix:\t");

                choixMenu = Console.ReadLine();

                switch (choixMenu[0])
                {
                    case '1':
                        Console.Clear();
                        GestionnaireTirages = new GestionnaireTirages();
                        for (int i = 0; i < GestionnaireTirages.NB_TIRAGE; i++)
                        {
                            Console.WriteLine("Génération du tirage du {0}...",GestionnaireTirages.GetTirage(i).DtmTirage);
                            nbMises = Aleatoire.GenererNombre(200000)+100000;
                            GestionnaireTirages.GetTirage(i).InscrireMises(nbMises);
                        }
                        GestionnaireTiragesExiste = true;
                        break;
                    case '2':
                        Console.Clear();
                        if (GestionnaireTiragesExiste)
                        {
                            for (int i = 0; i < GestionnaireTirages.NB_TIRAGE; i++)
                            {
                                GestionnaireTirages.GetTirage(i).ValiderMises();
                                Console.WriteLine(GestionnaireTirages.GetTirage(i).ToString());
                            }
                        }
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        break;
                }
            } while (choixMenu[0] != '5');
        }
    }
}
