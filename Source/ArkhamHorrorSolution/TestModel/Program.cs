using ArkhamHorrorLibrary.Model;
using System;

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
                    foreach (var m in db.Monsters)
                    {
                        Console.WriteLine(m.LocalName);
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
