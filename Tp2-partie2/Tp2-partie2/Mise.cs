using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitaires;


namespace SimulationLoterie
{
    class Mise
    {
        private int[] m_iLesNombres;

        public Mise()
        {
            m_iLesNombres = new int[7];

            int nombreGenerer = 0;
            bool contientNombreGenerer;
            int j = 0;
            for (int i = 0; i < m_iLesNombres.Length; i++)
            {
                contientNombreGenerer = false;
                nombreGenerer = Aleatoire.GenererNombre(48) + 1;
                j = 0;
                while (j <= i)
                {
                    if (nombreGenerer == m_iLesNombres[j])
                    {
                        nombreGenerer = Aleatoire.GenererNombre(48) + 1;
                        j = 0;
                    }
                    else j++;
                }
                m_iLesNombres[i] = nombreGenerer;
            }

            Array.Sort(m_iLesNombres);
        }

        public int GetNombre(int indice)
        {
            if (indice < 0 || indice > 6)
                return -1;
            else return m_iLesNombres[indice];
        }
    }
}
