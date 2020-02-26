/******************************************************************************
 * Classe:      Program
 * 
 * Fichier:     Program.cs
 * 
 * Auteur:      Willyam Arcand
 * 
 * But:         Sert a générer le menu et rouler le program
 * 
 * ***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationLoterie;
using Utilitaires;

namespace Tp1_partie2
{
    class Program
    {
        static void Main(string[] args)
        {
            GestionnaireTirages gestionnaireTirages = null;
            int nbMises;
            string choixMenu;
            bool misesValidee = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu Principal");
                Console.WriteLine("");
                Console.WriteLine("[1]\tGénération de données");
                Console.WriteLine("[2]\tRésultats des tirages");
                Console.WriteLine("[3]\tSommaire des résultats");
                Console.WriteLine("[4]\tAuteur");
                Console.WriteLine("[5]\tQuitter");
                Console.WriteLine();
                Console.Write("Votre choix:\t");
                choixMenu = Console.ReadLine();

                switch (choixMenu)
                {
                    case "1":
                        Console.Clear();
                        gestionnaireTirages = new GestionnaireTirages();
                        for (int i = 0; i < GestionnaireTirages.NB_TIRAGE; i++)
                        {
                            DateTime date =
                                gestionnaireTirages.GetTirage(i).DtmTirage;
                            string dateAffichage = string.Format("{0}",
                              Convert.ToDateTime(date).ToString("yyyy-MM-dd"));
                            Console.WriteLine("Génération du tirage du " + 
                                dateAffichage + "...");

                            nbMises = Aleatoire.GenererNombre(200000) + 100000;
                            gestionnaireTirages.
                                GetTirage(i).InscrireMises(nbMises);
                            gestionnaireTirages.GetTirage(i).Effectuer();

                        }
                        misesValidee = false;
                        Console.WriteLine("");
                        Console.WriteLine("Appuyer sur <Entrée>" +
                            " pour retourner au menu principal");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        if (gestionnaireTirages != null)
                        {
                            for (int i = 0; i <
                                GestionnaireTirages.NB_TIRAGE; i++)
                            {
                                gestionnaireTirages.GetTirage(i).ValiderMises();
                                Console.WriteLine(gestionnaireTirages.
                                    GetTirage(i).ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Vous devez avoir généré des" +
                                " données pour voir les résultats des tirages.");
                            Console.WriteLine("");
                            Console.WriteLine("Appuyer sur <Entrée> pour " +
                                "retourner au menu principal");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Appuyer sur <Entrée> pour" +
                            " retourner au menu principal");
                        Console.ReadLine();
                        misesValidee = true;
                        break;
                    case "3":
                        Console.Clear();
                        int[] tableauResultatsTotal = new int[7]
                        { 0, 0, 0, 0, 0,0,0 };
                        if (gestionnaireTirages != null && misesValidee)
                        {
                            for (int i = 0; i < GestionnaireTirages.NB_TIRAGE;
                                i++)
                            {
                                tableauResultatsTotal[0] +=
                                    gestionnaireTirages.GetTirage(i).
                                    LesResultats.
                                    GetQuantite(Resultats.Indice.DeuxSurSixPlus);
                                tableauResultatsTotal[1] +=
                                    gestionnaireTirages.GetTirage(i).
                                    LesResultats.
                                    GetQuantite(Resultats.Indice.TroisSurSix);
                                tableauResultatsTotal[2] +=
                                    gestionnaireTirages.GetTirage(i).
                                    LesResultats.
                                    GetQuantite(Resultats.Indice.QuatreSurSix);
                                tableauResultatsTotal[3] +=
                                    gestionnaireTirages.GetTirage(i).
                                    LesResultats.
                                    GetQuantite(Resultats.Indice.CinqSurSix);
                                tableauResultatsTotal[4] +=
                                    gestionnaireTirages.GetTirage(i).
                                    LesResultats.
                                    GetQuantite(Resultats.Indice.CinqSurSixPlus);
                                tableauResultatsTotal[5] +=
                                    gestionnaireTirages.GetTirage(i).
                                    LesResultats.
                                    GetQuantite(Resultats.Indice.SixSurSix);
                                tableauResultatsTotal[6] +=
                                    gestionnaireTirages.GetTirage(i).
                                    LesMises.Length;
                            }
                            string affichage = string.Format
                                ("Sommaire des résultats{0}\n" +
                                "{1,-24}{2}\n{3,-24}{4}\n" +
                                "{5,-24}{6}\n{7,-24}{8}\n" +
                                "{9,-24}{10}\n{11,-24}{12}\n" +
                                "{13,-24}{14}\n",
                            "\n", "Nombre total de mises:",
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
                            Console.WriteLine("");
                            Console.WriteLine("Appuyer sur <Entrée>" +
                                " pour retourner au menu principal");
                            Console.ReadLine();
                        }
                        else
                        {
                            if (gestionnaireTirages == null)
                            {
                                Console.WriteLine("Le gestionnaire de tirage" +
                                    " n'a pas encore été créer.");
                                Console.WriteLine("");
                                Console.WriteLine("Appuyer sur <Entrée> pour" +
                                    " retourner au menu principal");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Les mises n'ont pas" +
                                    " encore été validées");
                                Console.WriteLine("");
                                Console.WriteLine("Appuyer sur <Entrée>" +
                                    " pour retourner au menu principal");
                                Console.ReadLine();
                            }
                            
                        }

                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Travail 1 réalisé par " +
                            ": Willyam Arcand (1938912)");
                        Console.WriteLine("");
                        Console.WriteLine("Appuyer sur <Entrée>" +
                            " pour retourner au menu principal...");
                        Console.ReadLine();
                        break;
                    case "5":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("!Choix Invalide!");
                        Console.WriteLine("");
                        Console.WriteLine("Appuyer sur <Entrée>" +
                            " pour retourner au menu principal...");
                        Console.ReadLine();
                        break;
                }
            } while (choixMenu != "5");
        }

    }
}
