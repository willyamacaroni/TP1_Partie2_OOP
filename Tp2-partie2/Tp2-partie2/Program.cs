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
            GestionnaireTirages GestionnaireTirages = null;
            int[] tableauResultatsTotal = null;
            int nbMises;
            string choixMenu;
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
                            Console.WriteLine("Génération du tirage du {0}...", GestionnaireTirages.GetTirage(i).DtmTirage);
                            nbMises = Aleatoire.GenererNombre(200000) + 100000;
                            GestionnaireTirages.GetTirage(i).Effectuer();
                            GestionnaireTirages.GetTirage(i).InscrireMises(nbMises);
                        }
                        break;
                    case '2':
                        Console.Clear();
                        if (GestionnaireTirages != null)
                        {
                            for (int i = 0; i < GestionnaireTirages.NB_TIRAGE; i++)
                            {
                                GestionnaireTirages.GetTirage(i).ValiderMises();
                                Console.WriteLine(GestionnaireTirages.GetTirage(i).ToString());
                            }
                        }
                        else Console.WriteLine("Vous devez avoir généré des données pour voir les résultats des tirages.");
                        Console.ReadLine();
                        break;
                    case '3':
                        Console.Clear();
                        if (GestionnaireTirages != null)
                        {
                            tableauResultatsTotal = new int[7] { 0, 0, 0, 0, 0, 0,0 };
                            for (int i = 0; i < GestionnaireTirages.NB_TIRAGE; i++)
                            {

                                tableauResultatsTotal[0] += GestionnaireTirages.GetTirage(i).LesResultats.GetQuantite(Resultats.Indice.DeuxSurSixPlus);
                                tableauResultatsTotal[1] += GestionnaireTirages.GetTirage(i).LesResultats.GetQuantite(Resultats.Indice.TroisSurSix);
                                tableauResultatsTotal[2] += GestionnaireTirages.GetTirage(i).LesResultats.GetQuantite(Resultats.Indice.QuatreSurSix);
                                tableauResultatsTotal[3] += GestionnaireTirages.GetTirage(i).LesResultats.GetQuantite(Resultats.Indice.CinqSurSix);
                                tableauResultatsTotal[4] += GestionnaireTirages.GetTirage(i).LesResultats.GetQuantite(Resultats.Indice.CinqSurSixPlus);
                                tableauResultatsTotal[5] += GestionnaireTirages.GetTirage(i).LesResultats.GetQuantite(Resultats.Indice.SixSurSix);
                                tableauResultatsTotal[6] += GestionnaireTirages.GetTirage(i).LesMises.Length;
                            }
                        }

                        string affichage = string.Format("Résultat du tirage du {0}\n{1,-24}{2}\n{3,-24}{4}\n{5,-24}{6}\n{7,-24}{8}\n{9,-24}{10}\n{11,-24}{12}\n{13,-24}{14}\n",
                        "", "Nombre total de mises:",
                        tableauResultatsTotal[6],
                        "Gagnants du 2 sur 6+:",
                        tableauResultatsTotal[0],
                        "Gagnants du 3 sur 6:",
                        tableauResultatsTotal[1],
                        "Gagnants du 4 sur 6:",
                        tableauResultatsTotal[2],
                        "Gagnats du 5 sur 6:",
                        tableauResultatsTotal[3],
                        "Gagnants du 5 sur 6+:",
                        tableauResultatsTotal[4],
                        "Gagnants du 6 sur 6:",
                        tableauResultatsTotal[5]);
                        
                        Console.WriteLine(affichage);
                        Console.ReadLine();
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
