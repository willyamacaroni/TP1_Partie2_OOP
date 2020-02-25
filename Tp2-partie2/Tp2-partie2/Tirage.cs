/******************************************************************************
 * Classe:      Tirage
 * 
 * Fichier:     Tirage.cs
 * 
 * Auteur:      Willyam Arcand
 * 
 * But:         
 * 
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
            if (m_lesResultats == null)
                return "";
            else
            {
                return string.Format("Résultat du tirage du {0}\n{1,-24}{2}" +
                    "\n{3,-24}{4}\n{5,-24}{6}\n{7,-24}{8}\n{9,-24}{10}\n" +
                    "{11,-24}{12}\n{13,-24}{14}\n",
                m_dtmTirage, "Nombre de mises:", m_lesMises.Length,
                "Gagnants du 2 sur 6+:",
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
            int nombreGenerer = 0;
            bool contientNombreGenerer;
            int j = 0;
            for (int i = 0; i < m_iLesNombresGagnants.Length; i++)
            {
                contientNombreGenerer = false;
                nombreGenerer = Aleatoire.GenererNombre(48) + 1;
                j = 0;
                while (j <= i)
                {
                    if (nombreGenerer == m_iLesNombresGagnants[j])
                    {
                        nombreGenerer = Aleatoire.GenererNombre(48) + 1;
                        j = 0;
                    }
                    else j++;
                }
                m_iLesNombresGagnants[i] = nombreGenerer;
            }

            Array.Sort(m_iLesNombresGagnants, 0, 5);

            return true;
        }

        public bool ValiderMises()
        {
            m_lesResultats = new Resultats();
            bool trouvee = false;
            int k;
            int nbChiffreCommun = 0;
            int nbMisesGagnantes = 0;
            int l = 0;
            bool bonusTrouvee = false;
            if (m_lesMises.Length != 0 && m_iLesNombresGagnants != null)
            {
                for (int i = 0; i < m_lesMises.Length; i++)
                {
                    for (int j = 0; j < m_iLesNombresGagnants.Length - 1; j++)
                    {
                        k = 0;
                        trouvee = false;
                        while (!trouvee && k < 6)
                        {
                            if (m_iLesNombresGagnants[j] ==
                                m_lesMises[i].GetNombre(k))
                            {
                                nbChiffreCommun++;
                                trouvee = true;
                            }
                            else k++;
                        }
                    }


                    switch (nbChiffreCommun)
                    {
                        case 2:
                            l = 0;
                            bonusTrouvee = false;
                            while (l<6 && !bonusTrouvee)
                            {
                                if (m_iLesNombresGagnants[6] ==
                                    m_lesMises[i].GetNombre(l))
                                {
                                    m_lesResultats.AugmenterQuantite
                                        (Resultats.Indice.DeuxSurSixPlus);
                                    nbMisesGagnantes++;
                                    bonusTrouvee = true;
                                }
                                else
                                    l++;
                            }
                            break;
                        case 3:
                            m_lesResultats.AugmenterQuantite
                                (Resultats.Indice.TroisSurSix);
                            nbMisesGagnantes++;
                            break;
                        case 4:
                            m_lesResultats.AugmenterQuantite
                                (Resultats.Indice.QuatreSurSix);
                            nbMisesGagnantes++;
                            break;
                        case 5:
                            l = 0;
                            bonusTrouvee = false;
                            while (l < 6 && !bonusTrouvee)
                            {
                                if (m_iLesNombresGagnants[6] == 
                                    m_lesMises[i].GetNombre(l))
                                {
                                    m_lesResultats.AugmenterQuantite
                                        (Resultats.Indice.CinqSurSixPlus);
                                    bonusTrouvee = true;
                                }
                                else l++;
                            }
                            if (!bonusTrouvee)
                                m_lesResultats.AugmenterQuantite
                                    (Resultats.Indice.CinqSurSix);
                            nbMisesGagnantes++;
                            break;
                        case 6:
                            nbMisesGagnantes++;
                            m_lesResultats.AugmenterQuantite
                                (Resultats.Indice.SixSurSix);
                            break;
                    }
                    nbChiffreCommun = 0;
                }
                if (nbMisesGagnantes > 0)
                    return true;
                else return false;
            }
            else return false;
        }
    }
}
