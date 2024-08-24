using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_tabel.Logic.NpcGenerator.Leveling
{
    public static class LevelingUtils
    {
        public static int GetModifier(int score)
        {
            return (score - 10) / 2;
        }

        public static int CalculateHitPoints(int level, int constitutionModifier, int hitDie)
        {
            return hitDie + (constitutionModifier * level) + (level - 1) * (hitDie / 2 + 1);
        }

        public static int CalculateProficiencyBonus(int level)
        {
            return (level - 1) / 4 + 2;
        }
    }

}
