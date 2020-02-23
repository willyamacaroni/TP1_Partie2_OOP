﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationLoterie
{
    class GestionnaireTirages
    {
        public const int NB_TIRAGE = 104;

        private Tirage[] m_lesTirages;

        public GestionnaireTirages()
        {
            DateTime ajd = DateTime.Today;
            DateTime dateTirage = DateTime.Today;
            if (ajd.DayOfWeek != DayOfWeek.Wednesday &&
                ajd.DayOfWeek != DayOfWeek.Saturday)
            {
                dateTirage = ajd;
                while (dateTirage.DayOfWeek != DayOfWeek.Wednesday &&
                    dateTirage.DayOfWeek != DayOfWeek.Saturday)
                { dateTirage = dateTirage.AddDays(1); }
            }
            m_lesTirages = new Tirage[NB_TIRAGE];
            for (int i = 0; i < NB_TIRAGE; i++)
            {
                m_lesTirages[i] = new Tirage(dateTirage);
                if (dateTirage.DayOfWeek == DayOfWeek.Wednesday)
                    dateTirage = dateTirage.AddDays(3);
                else dateTirage = dateTirage.AddDays(4);
            }
        }

        public Tirage GetTirage(int indice)
        {
            if (indice >= 0 && indice < NB_TIRAGE)
            {
                return m_lesTirages[indice];
            }
            return null;

        }


    }
}
