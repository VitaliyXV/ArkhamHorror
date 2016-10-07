using ArkhamHorrorLibrary.Model;
using System;
using System.Linq;

namespace TestModel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var db = new ArkhamHorrorModel())
                {
                    foreach (var m in db.AncientOnes.OrderBy(a => a.GameExtention).ThenBy(a=>a.LocalName))
                    {
                        Console.WriteLine(m.LocalName + ": " + m.GameExtention1.LocalName);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
    }
}
