using rpg;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    public class Program
    {
        static void Main(string[] args)
        {
            KillerBee enemy = new KillerBee();
            Beater beater = new Beater();
            FightScene Fight1 = new FightScene();
            beater.CreateBeater();
            enemy.CreateEnemy();
            Fight1.Fight(beater, enemy);


        }
    }

}