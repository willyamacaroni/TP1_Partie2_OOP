/******************************************************************************
 * Classe:      Tirage
 * 
 * Fichier:     Tirage.cs
 * 
 * Auteur:      Willyam Arcand
 * 
 * But:         
 * 
 * Remarque:   
 * ***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitaires;

namespace SimulationLoterie
{
    class Tirage
    {
        public const int NB_MISES_MIN = 100000;
        public const int NB_MISES_MAX = 300000;

        private DateTime m_dtmTirage;
        private int[] m_iLesNombresGagnants;
        private Mise[] m_lesMises;
        private Resultats m_lesResultats;

        public Tirage(DateTime laDate)
        {
            m_dtmTirage = laDate;
        }

        public DateTime DtmTirage { get => m_dtmTirage; }
        public Resultats LesResultats { get => m_lesResultats; }
        public Mise[] LesMises { get => m_lesMises; }

        //TO DO finir l'affichage
        public override string ToString()
        {
            if (m_lesResultats != null)
                return "bing bong bing";
            else return string.Format("Résultat du tirage du {0}\n" +
                "{1,-24}{2,8}\n" +
                "{3,-24}{4,8}\n" +
                "{4,-24}{5,8}\n" +
                "{6,-24}{7,8}\n" +
                "{7,-24}{8,8}\n", m_dtmTirage.ToString(), "Nombre de mises:",
                m_lesMises.Length.ToString(), "Gagnants du 2 sur 6+:",
                m_lesResultats.GetQuantite(Resultats.Indice.DeuxSurSixPlus),
                "Gagnants du 3 sur 6:",
                m_lesResultats.GetQuantite(Resultats.Indice.TroisSurSix),
                "Gagnants du 4 sur 6:",
                m_lesResultats.GetQuantite(Resultats.Indice.QuatreSurSix),
                "Gagnats du 5 sur 6:",
                m_lesResultats.GetQuantite(Resultats.Indice.CinqSurSix),
                "Gagnants du 5 sur 6+:",
                m_lesResultats.GetQuantite(Resultats.Indice.CinqSurSixPlus),
                "Gagnants du 6 sur 6:",
                m_lesResultats.GetQuantite(Resultats.Indice.SixSurSix));

        }

        public Mise[] InscrireMises(int nbMises)
        {
            if (nbMises < NB_MISES_MIN || nbMises > NB_MISES_MAX)
                nbMises = ((NB_MISES_MIN + NB_MISES_MAX) / 2);

            m_lesMises = new Mise[nbMises];

            for (int i = 0; i < nbMises; i++)
                m_lesMises[i] = new Mise();

            return m_lesMises;
        }

        //TO DO retourner vrai ou faux selon mises
        public bool Effectuer()
        {
            m_iLesNombresGagnants = new int[7];
            int nombreGenerer;
            bool contientNombreGenerer = true;
            int j = 0;
            for (int i = 0; i < m_iLesNombresGagnants.Length; i++)
            {
                do
                {
                    nombreGenerer = Aleatoire.GenererNombre(48) + 1;

                    //Vérifie si le nombre généré est unique dans le tableau.
                    while (j <= i)
                    {
                        if (nombreGenerer == m_iLesNombresGagnants[j])
                            contientNombreGenerer = true;
                        else contientNombreGenerer = false;
                        j++;
                    }
                } while (contientNombreGenerer);
                m_iLesNombresGagnants[i] = nombreGenerer;
            }

            Array.Sort(m_iLesNombresGagnants,0,6);

            return true;
        }

        public bool ValiderMises()
        {
            bool trouvee = false;
            int k;
            int nbChiffreCommun = 0;
            bool chiffreBonus;
            if (m_lesMises.Length != 0 && m_iLesNombresGagnants != null)
            {
                for (int i = 0; i < m_lesMises.Length; i++)
                {
                    for (int j = 0; j <= 6; j++)
                    {
                        k = 0;
                        while (!trouvee && k <= 6)
                        {
                            if (m_iLesNombresGagnants[j] == m_lesMises[i].GetNombre(k))
                            {
                                nbChiffreCommun++;
                                trouvee = true;
                            }
                            else k++;
                        }
                    }
                    if (m_iLesNombresGagnants[7] == m_lesMises[i].GetNombre(7))
                        chiffreBonus = true;

                    switch (nbChiffreCommun)
                    {
                        case 2:
                            if (chiffreBonus = true)
                                m_lesResultats.AugmenterQuantite(Resultats.Indice.DeuxSurSixPlus);
                            break;
                        case 3:
                            m_lesResultats.AugmenterQuantite(Resultats.Indice.TroisSurSix);
                            break;
                        case 4:
                            m_lesResultats.AugmenterQuantite(Resultats.Indice.QuatreSurSix);
                            break;
                        case 5:
                            if (chiffreBonus = true)
                                m_lesResultats.AugmenterQuantite(Resultats.Indice.CinqSurSixPlus);
                            else m_lesResultats.AugmenterQuantite(Resultats.Indice.CinqSurSix);
                            break;
                        case 6:
                            m_lesResultats.AugmenterQuantite(Resultats.Indice.SixSurSix);
                            break;
                    }
                }
                return true;
            }
            else return false;
        }
    }
}
