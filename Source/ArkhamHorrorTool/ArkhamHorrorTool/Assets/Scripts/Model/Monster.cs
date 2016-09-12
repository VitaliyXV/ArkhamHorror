﻿using System;
using System.Collections.Generic;

namespace ArkhamHorror.Model
{
    [Serializable]
    public class Monster : ArkhamItem
    {
        public string Description;
        public int GameExtention;
        public int MonsterMoveType;
        public int MonsterType;
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