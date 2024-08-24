using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using rpg_tabel.Logic.namegenerator.npcs;
using rpg_tabel.Logic.NpcGenerator.npcs;

namespace rpg_tabel.Logic.NpcGenerator.Leveling
{
    [Serializable]
    public class BarbarianFeatures
    {
        public BarbarianFeatures()
        {
            WeaponProficiencies = new List<WeaponProficiency>();
            ArmorProficiencies = new List<ArmorProficiency>();
            Spells = new List<Spell>(); // Initialize the list
        }

        public int HitDie { get; set; }

        [XmlArray("WeaponProficiencies")]
        [XmlArrayItem("WeaponProficiency")]
        public List<WeaponProficiency> WeaponProficiencies { get; set; }

        [XmlArray("ArmorProficiencies")]
        [XmlArrayItem("ArmorProficiency")]
        public List<ArmorProficiency> ArmorProficiencies { get; set; }

        [XmlArray("Spells")]
        [XmlArrayItem("Spell")]
        public List<Spell> Spells { get; set; }
    }

    [Serializable]
    public class WeaponProficiency
    {
        public WeaponProficiency() { } // Parameterless constructor
        public Weapon Weapon { get; set; }
        public int Proficiency { get; set; }
    }

    [Serializable]
    public class ArmorProficiency
    {
        public ArmorProficiency() { } // Parameterless constructor
        public Armor Armor { get; set; }
        public int Proficiency { get; set; }
    }
}
