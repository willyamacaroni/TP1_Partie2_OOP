using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitaires;

namespace Tp2_partie2
{
    class Mise
    {
        private int[] m_iLesNombres;

        public Mise()
        {
            m_iLesNombres = new int[6];

            int nombreGenerer;
            bool contientNombreGenerer =true;
            int j=0;
            for(int i=0; i < m_iLesNombres.Length;i++)
            {
                do
                {
                    nombreGenerer = Aleatoire.GenererNombre(48) + 1;
                    while(j<i)
                    {
                        if (nombreGenerer == m_iLesNombres[j])
                            contientNombreGenerer = true;
                        else contientNombreGenerer = false;
                        j++;
                    }
                } while (contientNombreGenerer);
                m_iLesNombres[i] = nombreGenerer;
            }


        }
    }
}
