namespace SingleResponsibility.Model
{
    class MonsterSaver
    {
        public void SaveMonster(Monster m)
        {
            // TODO: сохранить монстра
        }
        
        // нарушение принципа открытости / закрытости (при добавлении нового типа списка монстров, нужно менять код)
        // решение: создание сейверов, для каждой версии списка монстров
        public void SaveMonsterList(IMonsterList list)
        {
            if(list is MonsterList)
            {
                foreach (var m in (list as MonsterList).Monsters)
                {
                    SaveMonster(m);
                }
            }
            else if(list is MonsterDictionary)
            {
                foreach (var m in (list as MonsterDictionary).Monsters.Values)
                {
                    SaveMonster(m);
                }
            }
        }
    }
}
