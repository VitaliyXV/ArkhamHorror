namespace SingleResponsibility.Model
{
    interface IMonsterList
    {
        Monster SpawnMonster();
        Monster GetMonsterById(int id);
        
    }
}
