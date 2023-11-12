using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace rpg
{

    abstract class Enemy : IStats, IBattle
    {
        public double Hp { get; set; }
        public double Mp { get; set; }
        public double Agl { get; set; }
        public double Atk { get; set; }
        public double Def { get; set; }
        public int BattleReady { get; set; }
        public int Carregamento { get; set; } = 0;
        public System.Timers.Timer BattleCounter { get; set; }
        public virtual void Attack(Player player, Enemy enemy)
        {
            player.Hp = player.Hp - enemy.Damage(enemy, player);
            Console.WriteLine("Enemy dealt " + enemy.Damage(enemy, player) + " damage");
            Console.WriteLine("You have " + player.Hp + " Hp left");
            enemy.Carregamento = 0;
        }
        public void SetTimer()
        {
            BattleCounter = new System.Timers.Timer(100000 / 4 / Agl);
            BattleCounter.Enabled = true;
            BattleCounter.AutoReset = true;
            BattleCounter.Elapsed += Ready;
        }
        public void Ready(Object source, ElapsedEventArgs e)
        {

            Carregamento++;

            if (Carregamento == 4)
            {
                BattleReady = 1;
            }


        }
        public virtual double Damage(IStats enemy, IStats player)
        {
            double dano = enemy.Atk - Math.Round(player.Def / 2);
            if (dano < 0)
            {
                dano = 1;
            }

            return dano;
        }

    }
    internal class KillerBee : Enemy
    {
        public void CreateEnemy()
        {
            Hp = 50;
            Mp = 5;
            Def = 0;
            Agl = 10;
            Atk = 3;
        }
    }
    internal class Kian : Enemy
    {
        public void CreateKian()
        {
            Hp = 150;
            Mp = 50;
            Def = 5;
            Agl = 15;
            Atk = 20;
        }
    }
}



