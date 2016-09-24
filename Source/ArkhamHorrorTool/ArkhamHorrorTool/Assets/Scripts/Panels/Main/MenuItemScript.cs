using System.Linq;
using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 649

namespace Assets.Scripts.Panels.Main
{
    public class MenuItemScript : MonoBehaviour
    {
        [SerializeField] 
        private MonsterItem _monsterItem;
        
        [SerializeField] 
        private Dropdown _ancientOneDropdown;
        
        [SerializeField] 
        private Sprite _dropDownSprite;

        protected void Start()
        {
            ArkhamHorrorModel.DataLoaded +=
                () =>
                {
                    foreach (var a in ArkhamHorrorModel.AncientOnes)
                    {
                        _ancientOneDropdown.options.Add(new Dropdown.OptionData( a.LocalName, _dropDownSprite));
                    }
                    if (_ancientOneDropdown.options.Count > 0)
                    {
                        _ancientOneDropdown.value = 1;
                    }
                    _ancientOneDropdown.onValueChanged.AddListener(index =>
                    {
                        Debug.Log("Selected: " + index);
                        _ancientOneDropdown.value = index;
                    });
                };

        }

        public void OnMenuItemClick()
        {
            Debug.Log("Menu Item Click!");

            var monsters = ArkhamHorrorModel.Monsters.Where(m => m.MonsterType == MonsterTypes.Simple).ToList();
            var monster = monsters[Random.Range(0, monsters.Count)];
            _monsterItem.UpdateMonster(monster);
        }
    }
}