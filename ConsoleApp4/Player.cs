using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace rpg
{
    internal abstract class Player : IBattle, IStats
    {
        public string Name { get; set; }
        public double Hp { get; set; }
        public double Mp { get; set; }
        public double Agl { get; set; }
        public double Atk { get; set; }
        public double Def { get; set; }
        public double BaseDef { get; set; }
        public int BattleReady { get; set; }
        public int Carregamento { get; set; }
        public System.Timers.Timer BattleCounter { get; set; }
        public virtual void Attack(Player player, Enemy enemy)
        {
            enemy.Hp = enemy.Hp - player.Damage(player, enemy);
            Console.WriteLine("You dealt " + player.Damage(player, enemy) + " damage");
            Console.WriteLine("The enemy has " + enemy.Hp + " Hp left");
            player.Carregamento = 0;
        }
        public virtual double Damage(Player player, Enemy enemy)
        {
            double dano = player.Atk - Math.Round(enemy.Def / 2);
            if (dano < 0)
            {
                dano = 1;
            }
            return dano;
        }
        public virtual void MagicAttack(Enemy enemy, Beater player)
        {
            enemy.Hp = enemy.Hp - player.MagicDamage(player, enemy);
            Console.WriteLine("You dealt " + player.MagicDamage(player, enemy) + " damage");
            Console.WriteLine("Enemy has " + enemy.Hp + " Hp left");
            player.Carregamento = 0;

        }
        public virtual double MagicDamage(Player player, Enemy enemy)
        {
            double dano = player.Atk + 5;
            if (player.Mp >= 3)
            {

                return dano;

            }
            else
            {
                return 0;
            }

        }
        public virtual void SetTimer()
        {
            BattleCounter = new System.Timers.Timer(100000 / 4 / Agl);
            BattleCounter.Enabled = true;
            BattleCounter.AutoReset = true;
            BattleCounter.Elapsed += Ready;
        }
        public virtual void Ready(Object source, System.Timers.ElapsedEventArgs e)
        {

            Carregamento++;

            switch (Carregamento)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("____________");
                    Console.WriteLine($"|          | You:{Hp}");
                    Console.WriteLine($"|__________| Mp:{Mp}");
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("____________");
                    Console.WriteLine($"||||       | You:{Hp}");
                    Console.WriteLine($"|__________| Mp:{Mp}");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("____________");
                    Console.WriteLine($"|||||||    | You:{Hp}");
                    Console.WriteLine($"|__________| Mp:{Mp}");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("____________");
                    Console.WriteLine($"|||||||||| | You:{Hp}");
                    Console.WriteLine($"|__________| Mp:{Mp}");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("____________");
                    Console.WriteLine($"|||||||||||| You:{Hp}");
                    Console.WriteLine($"|__________| Mp:{Mp}");
                    break;
            }
            if (Carregamento == 4)
            {
                BattleReady = 1;
                Console.WriteLine("Choose a number to decide your action");
                Console.WriteLine("1:Normal Attack");
                Console.WriteLine("2:Magic Attack");
                Console.WriteLine("3:Defence");
            }

        }

    }

    internal class Beater : Player
    {

        public void CreateBeater()
        {
            Random rand = new Random();
            Console.WriteLine("Insert your name");
            Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Press Enter to roll your Hp");
            Console.ReadLine();
            Console.Clear();
            Hp = rand.Next(1, 20) + 5;
            Console.WriteLine($"Your Hp is {Hp}");
            Console.WriteLine("Press Enter to roll your Mp");
            Console.ReadLine();
            Console.Clear();
            Mp = rand.Next(1, 20) + 4;
            Console.WriteLine($"Your Mp is {Mp}");
            Console.WriteLine("Press Enter to roll your Agility");
            Console.ReadLine();
            Agl = rand.Next(1, 20);
            Console.Clear();
            Console.WriteLine($"Your Agility is {Agl}");
            Console.WriteLine("Press Enter to roll your Attack");
            Console.ReadLine();
            Atk = rand.Next(1, 20) + 5;
            Console.Clear();
            Console.WriteLine($"Your Attack is {Atk}");
            Console.WriteLine("Press Enter to roll your Defence");
            Console.ReadLine();
            Def = rand.Next(1, 20);
            Console.Clear();
            Console.WriteLine($"Your Defence is {Def}");
            Console.WriteLine("Press Enter to fight");
            Console.ReadLine();
            BaseDef = Def;
        }

    }

    internal class Rogue : Player
    {

        public void CreateRogue()
        {
            Random rand = new Random();

            Name = Console.ReadLine();
            Console.WriteLine("Press Enter to roll your Hp");
            Console.ReadLine();
            Hp = rand.Next(1, 20);
            Console.Clear();
            Console.WriteLine($"Your Hp is {Hp}");
            Console.WriteLine("Press Enter to roll your Mp");
            Console.ReadLine();
            Mp = rand.Next(1, 20) + 7;
            Console.Clear();
            Console.WriteLine($"Your Mp is {Mp}");
            Console.WriteLine("Press Enter to roll your Agility");
            Console.ReadLine();
            Agl = rand.Next(1, 20) + 8;
            Console.Clear();
            Console.WriteLine($"Your Hp is {Agl}");
            Console.WriteLine("Press Enter to roll your Attack");
            Console.ReadLine();
            Atk = rand.Next(1, 20);
            Console.Clear();
            Console.WriteLine($"Your Hp is {Atk}");
            Console.WriteLine("Press Enter to roll your Defence");
            Console.ReadLine();
            Def = rand.Next(1, 20) + 1;
            Console.Clear();
            Console.WriteLine($"Your Hp is {Atk}");
            Console.WriteLine("Press Enter to fight");
            Console.ReadLine();
        }
    }
}


