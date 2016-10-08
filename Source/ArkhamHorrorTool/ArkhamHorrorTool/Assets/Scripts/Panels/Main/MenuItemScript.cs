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
        
        [SerializeField]
        private Text _heraldText;

        [SerializeField]
        private Text _instituteText;

        [SerializeField]
        private InvestigatorItem _ivestigators;

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

            _ivestigators.ExpansionToggles = _expansionToggles;
            SpawnAncientOne();
        }

        public void SpawnAncientOne()
        {
            var list = ArkhamHorrorModel.AncientOnes.Where(m => m.GameExtention == 1 || _expansionToggles[m.GameExtention-2].isOn).ToList();
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
            _monsterList = ArkhamHorrorModel.Monsters.Where(m => (m.GameExtention == 1 || _expansionToggles[m.GameExtention - 2].isOn) && (m.MonsterType == MonsterTypes.Simple || (ancientOne.OriginalName == "Nyarlathotep" && m.MonsterType == MonsterTypes.Mask))).ToList();
            _monsterItem.UpdateMonster(null);
        }

        public void RandomInstitute()
        {
            var i = Random.Range(0, 4);
            switch (i)
            {
                case 0: _instituteText.text = "Отсутствует"; break;
                case 1: _instituteText.text = "Бюро Расследований"; break;
                case 2: _instituteText.text = "Мискатониский Университет"; break;
                case 3: _instituteText.text = "Организованная Преступность"; break;
            }
        }

        public void SpawnHerald()
        {
            var heralds = ArkhamHorrorModel.Heralds.Where((h => h.GameExtention == 1 || _expansionToggles[h.GameExtention - 2].isOn)).ToList();
            var i = Random.Range(0, heralds.Count + 1);
            _heraldText.text = i == heralds.Count ? "Отсутствует" : heralds[i].LocalName;
        }
    }
}