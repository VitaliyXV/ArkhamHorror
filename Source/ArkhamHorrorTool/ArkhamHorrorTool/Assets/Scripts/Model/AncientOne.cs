using System;
using System.Collections.Generic;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class AncientOne : ArkhamItem
    {
        public string Description;
        public int GameExtention;
        public string Worshippers;
        public string AncientPower;
        public string Attack;
        public int CombatRating;
        public int DoomTrack;

        public List<ModelRelationData> AncientOnesAbilities;
    }
}