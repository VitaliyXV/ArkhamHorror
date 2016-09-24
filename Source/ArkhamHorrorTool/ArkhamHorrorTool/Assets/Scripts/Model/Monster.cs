using System;
using System.Collections.Generic;

namespace Assets.Scripts.Model
{
    public enum MonsterTypes
    {
        Simple = 1,
        Mask,
        Spawn
    }

    [Serializable]
    public class Monster : ArkhamItem
    {
        public string Description;
        public int GameExtention;
        public int MonsterMoveType;
        public MonsterTypes MonsterType;
        public int Dimension;
        public int Toughness;
        public int Awareness;
        public int HorrorRating;
        public int HorrorDamage;
        public int CombatRating;
        public int CombatDamage;

        public List<ModelRelationData> MonstersAbilities;
        public List<ModelRelationData> MonstersAmounts;
    }
}