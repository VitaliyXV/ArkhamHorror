using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Tools
{
    public static class ImageManager
    {
        private static readonly Dictionary<string, Sprite> Sprites = new Dictionary<string, Sprite>();

        public static Sprite GetMonsterSprite(string monsterName)
        {
            return GetSprite("Monsters/" + monsterName);
        }

        public static Sprite GetSprite(string name)
        {
            if (!Sprites.ContainsKey(name))
            {
                Sprites.Add(name, Resources.Load<Sprite>(name));
            }

            return Sprites[name];
        }
    }
}