using System.Linq;
using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

#pragma warning disable 649

namespace Assets.Scripts.Panels.Main
{
    public class MenuItemScript : MonoBehaviour
    {
        [SerializeField] 
        private MonsterItem _monsterItem;

        [SerializeField]
        private Text _ancientOneText;

        [SerializeField]
        private List<Toggle> _expansionToggles;

        private List<Monster> _monsterList;


        protected void Start()
        {
            ArkhamHorrorModel.DataLoaded += () =>
            {
                UpdateMonsterList(ArkhamHorrorModel.AncientOnes[0]);
            };
        }

        public void RandomExpansions()
        {
            foreach (var t in _expansionToggles)
            {
                t.isOn = false;
            }

            var count = Random.Range(0, _expansionToggles.Count + 1);

            while (count > 0)
            {
                var index = Random.Range(0, _expansionToggles.Count);
                if (_expansionToggles[index].isOn) continue;
                _expansionToggles[index].isOn = true;
                count--;
            }

            SpawnAncientOne();
        }

        public void SpawnAncientOne()
        {
            var list = ArkhamHorrorModel.AncientOnes.Where(m => _expansionToggles[m.GameExtention-1].isOn).ToList();
            var index = Random.Range(0, list.Count);
            var a = list[index];
            _ancientOneText.text = a.LocalName;
            UpdateMonsterList(a);
        } 

        public void SpawnMonster()
        {           
            _monsterItem.UpdateMonster(_monsterList[Random.Range(0, _monsterList.Count)]);
        }                     

        private void UpdateMonsterList(AncientOne ancientOne)
        {
            _monsterList = ArkhamHorrorModel.Monsters.Where(m => _expansionToggles[m.GameExtention - 1].isOn && (m.MonsterType == MonsterTypes.Simple || (ancientOne.OriginalName == "Nyarlathotep" && m.MonsterType == MonsterTypes.Mask))).ToList();
            _monsterItem.UpdateMonster(null);
        }
    }
}