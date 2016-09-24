namespace SingleResponsibility.Model
{
    class InvulnerableHardGameChecker : IInvulnerable
    {
        public bool IsInvulnerable(Monster monster)
        {
            return monster.MonsterType == MonsterType.Simple;
        }
    }
}
