/******************************************************************************
 * Classe:      Résultats
 * 
 * Fichier:     Resultats.cs
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

namespace SimulationLoterie
{
    class Resultats
    {
        public enum Indice
        {
            DeuxSurSixPlus = 0,
            TroisSurSix,
            QuatreSurSix,
            CinqSurSix,
            CinqSurSixPlus,
            SixSurSix
        }

        private int[] m_iLesQuantites;

        /// <summary>
        /// Constructeur qui permet de créer le tableau de quantités.
        /// </summary>
        public Resultats()
        {
            m_iLesQuantites = new int[7];
        }

        /// <summary>
        /// Retourne la quantité à l'indice reçu en paramètre et à
        /// partir de l'attribut.
        /// </summary>
        /// <param name="indice">Indice de la quantité
        /// voulant être retourné.</param>
        /// <returns></returns>
        public int GetQuantite(Indice indice)
        {
           return m_iLesQuantites[(int) indice];
        }

        /// <summary>
        /// Permet d'augmenter d'un la quantité de l'attribut
        /// en fonction de l'indice reçu en paramètre
        /// </summary>
        /// <param name="indice">Indice de la quantité voulant
        /// être augmenté.</param>
        /// <returns></returns>
        public int[] AugmenterQuantite(Indice indice)
        {
            m_iLesQuantites[(int)indice]++;
            return m_iLesQuantites;
        }


    }
}
