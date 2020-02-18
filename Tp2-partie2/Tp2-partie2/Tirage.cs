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
            if (false)
            {

            }
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

            Mise[] lesMises = new Mise[nbMises];

            for (int i = 0; i < nbMises; i++)
                lesMises[i] = new Mise();

            return lesMises;
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

            Array.Sort(m_iLesNombresGagnants);

            return true;
        }
    }
}
