using System;
using SingleResponsibility.Model;

namespace SingleResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Принцип единственности ответственности");

            var monsters = new MonsterList();
            var m = monsters.SpawnMonster();

            Console.WriteLine("Монстр неуязвим: " + m.IsInvulnerable(new InvulnerableDefaultChecker()));
            Console.WriteLine("Монстр неуязвим: " + m.IsInvulnerable(new InvulnerableHardGameChecker()));
        }
    }
}
