namespace SingleResponsibility.Model
{
    class InvulnerableDefaultChecker : IInvulnerable
    {
        public bool IsInvulnerable(Monster monster)
        {
            return monster.MonsterType == MonsterType.Undead;
        }
    }
}
