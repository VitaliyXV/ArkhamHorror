using System.Linq;
using System.Collections.Generic;

namespace SingleResponsibility.Model
{
    class MonsterList
    {
        public readonly List<Monster> Monsters = new List<Monster>();

        // НАРУШЕНИЕ открытости/закрытости (при изменении логгера прийдется менять код текущего класса(создание конкретного объекта для сохранения))
        private readonly MonsterSaver saver = new MonsterSaver();

        public Monster SpawnMonster()
        {
            var m = new Monster();
            Monsters.Add(m);
            return m;
        }

        public Monster GetMonsterById(int id)
        {
            return Monsters.FirstOrDefault(m => m.Id == id);
        }
        
        public void SaveMonsters()
        {
            foreach (var m in Monsters)
            {
                m.SaveMonster();
            }
        }

        public void SaveMonsters(MonsterSaver saver)
        {
            foreach (var m in Monsters)
            {
                saver.SaveMonster(m);
            }
        }
    }
}
