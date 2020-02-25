/******************************************************************************
 * Classe:      Mise
 * 
 * Fichier:     Mise.cs
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
    class Mise
    {
        private int[] m_iLesNombres;

        public Mise()
        {
            m_iLesNombres = new int[6];

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

        /// <summary>
        /// permet de retourner le nombre à l'indice reçu en paramètre
        /// et à partir de l'attribut si cet indice est valide
        /// </summary>
        /// <param name="indice">indice du nombre que l'ont veut accéder.</param>
        /// <returns></returns>
        public int GetNombre(int indice)
        {
            if (indice < 0 || indice > 6)
                return -1;
            else return m_iLesNombres[indice];
        }
    }
}
