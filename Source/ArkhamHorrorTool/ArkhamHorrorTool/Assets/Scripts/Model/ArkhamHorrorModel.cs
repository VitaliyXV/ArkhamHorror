using System;
using System.Collections.Generic;

namespace Assets.Scripts.Model
{
    public static class ArkhamHorrorModel
    {
        public static event Action DataLoaded;

        public static List<Ability> Abilities { get; set; }
        public static List<AncientOne> AncientOnes { get; set; }
        public static List<Color> Colors { get; set; }
        public static List<Dimension> Dimensions { get; set; }
        public static List<GameExtention> GameExtentions { get; set; }
        public static List<Herald> Heralds { get; set; }
        public static List<Monster> Monsters { get; set; }
        public static List<MonsterMoveType> MonsterMoveTypes { get; set; }
        public static List<MonsterType> MonsterTypes { get; set; }

        public static void InitializeComplete()
        {
            if (DataLoaded != null)
            {
                DataLoaded();
            }
        }
    }
}