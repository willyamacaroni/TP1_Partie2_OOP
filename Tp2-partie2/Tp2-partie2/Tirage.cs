using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationLoterie
{
    class Tirage
    {
        private DateTime m_dtmTirage;
        private int[] m_iLesNombresGagnants;
        private Mise[] m_lesMises;
        private int[] m_lesResultats;

        public Tirage(DateTime laDate)
        {
            m_dtmTirage = laDate;
        }

        public DateTime DtmTirage { get => m_dtmTirage; }
        public int[] LesResultats { get => m_lesResultats; set => m_lesResultats = value; }
        public Mise[] LesMises { get => m_lesMises; set => m_lesMises = value; }
    }
}
