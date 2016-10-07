using Assets.Scripts.Model;
using Assets.Scripts.Tools;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 649

namespace Assets.Scripts.Panels
{
    public class MonsterItem : MonoBehaviour
    {
        [SerializeField]
        private Text _monsterName;

        [SerializeField]
        private Image _monsterImage;

        [SerializeField]
        private Sprite _eldritchSign;


        public void UpdateMonster(Monster monster)
        {
            if(monster == null)
            {
                _monsterName.text = "";
                _monsterImage.sprite = _eldritchSign;
                return;
            }

            _monsterName.color = SetColor(monster.MonsterMoveType);
            _monsterName.text = monster.LocalName;
            _monsterImage.sprite = ImageManager.GetMonsterSprite(monster.OriginalName);
        }

        private UnityEngine.Color SetColor(int color)
        {
            switch (color)
            {
                case 1: return UnityEngine.Color.black;
                case 2: return UnityEngine.Color.yellow;
                case 3: return UnityEngine.Color.red;
                case 4: return UnityEngine.Color.green;
                case 5: return UnityEngine.Color.cyan;
                case 6: return UnityEngine.Color.magenta;
                case 7: return UnityEngine.Color.blue;
            }

            return UnityEngine.Color.red;
        }
    }
}