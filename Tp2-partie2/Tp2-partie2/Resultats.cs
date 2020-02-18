using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationLoterie
{
    class Resultats
    {
        public enum Indice
        {
            DeuxSurSixPlus,
            TroisSurSix,
            QuatreSurSix,
            CinqSurSix,
            CinqSurSixPlus,
            SixSurSix
        }

        private int[] m_iLesQuantites;

        public Resultats()
        {
            m_iLesQuantites = new int[7];
        }

        public int GetQuantite(Indice indice)
        {
           return m_iLesQuantites[(int) indice];
        }

        public int[] AugmenterQuantite(Indice indice)
        {
            m_iLesQuantites[(int)indice]++;
            return m_iLesQuantites;
        }


    }
}
