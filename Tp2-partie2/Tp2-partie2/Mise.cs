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
            m_iLesNombres = new int[6];

            int nombreGenerer;
            bool contientNombreGenerer = true;
            int j = 0;
            for (int i = 0; i < m_iLesNombres.Length; i++)
            {
                do
                {
                    nombreGenerer = Aleatoire.GenererNombre(48) + 1;

                    //Vérifie si le nombre généré est unique dans le tableau.
                    while (j <= i)
                    {
                        if (nombreGenerer == m_iLesNombres[j])
                            contientNombreGenerer = true;
                        else contientNombreGenerer = false;
                        j++;
                    }
                } while (contientNombreGenerer);
                m_iLesNombres[i] = nombreGenerer;
            }

            Array.Sort(m_iLesNombres);
        }

        public int GetNombre(int indice)
        {
            if (0 < indice || indice > 5)
                return -1;
            else return m_iLesNombres[indice];
        }
    }
}
