namespace SingleResponsibility.Model
{
    class Monster
    {
        public int Id { get; set; }
        public MonsterType MonsterType { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int MagicDamage { get; set; }
        public int PhysicalDamage { get; set; }

        #region Принцип единственности ответственности 2

        // возможно нарушение единственности ответственности (монстр определяет условие неуязвимости)
        public bool IsInvulnerable()
        {
            return MonsterType == MonsterType.Undead;
        }

        // НАРУШЕНИЕ единственности ответственности (монстр определяет условие неуязвимости в зависимости от внешнего фактора)
        public bool IsInvulnerable(bool isHardLevel)
        {
            return MonsterType == MonsterType.Simple && isHardLevel;
        }

        // РЕШЕНИЕ
        public bool IsInvulnerable(IInvulnerable checker)
        {
            return checker.IsInvulnerable(this);
        }

        #endregion

        public void Attack(Monster target)
        {
            target.SetDamage(this);
        }

        public void SetDamage(Monster attaker)
        {            
            Strength -= attaker.PhysicalDamage;
        }

        #region Принцип единственности ответственности 1

        // НАРУШЕНИЕ единственности ответственности (класс монстра умеет слишком много)
        public void SaveMonster()
        {
            //TODO: Save monster to file
        }

        // РЕШЕНИЕ: создать отдельный класс, отвечающий за сохранение монстра

        #endregion
    }
}
