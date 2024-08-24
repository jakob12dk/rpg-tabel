﻿using rpg_tabel.Logic.NpcGenerator.npcs;

namespace rpg_tabel.Logic.NpcGenerator.Leveling
{
    internal class FighterLeveling : ILevelable
    {
        public void ApplyLeveling(NPC npc)
        {
            if (npc == null) throw new ArgumentNullException(nameof(npc));
            if (npc.Level < 1 || npc.Level > 20) throw new ArgumentOutOfRangeException(nameof(npc.Level));

            npc.HitPoints = LevelingUtils.CalculateHitPoints(npc.Level, LevelingUtils.GetModifier(npc.AbilityScores[Ability.Constitution]), 10);
            npc.ProficiencyBonus = LevelingUtils.CalculateProficiencyBonus(npc.Level);

            // Apply specific Fighter features
            // Add Action Surge, Second Wind, and skills if necessary
        }
    }
}
