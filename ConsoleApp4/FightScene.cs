using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    internal class FightScene
    {
        public bool Running = true;
        public void Fight(Beater player, Enemy enemy)
        {

            player.SetTimer();
            enemy.SetTimer();
            Running = true;
            while (Running == true)
            {
                if (player.BattleReady == 1)
                {
                    enemy.BattleCounter.Stop();
                    player.Def = player.BaseDef;
                    switch (Console.ReadLine())
                    {

                        case "1":

                            if (enemy.Hp > 0)
                            {
                                player.Attack(player, enemy);

                                enemy.BattleCounter.Start();
                            }
                            if (enemy.Hp <= 0)
                            {
                                Console.WriteLine("Enemy defeated");
                                Running = false;
                            }

                            player.BattleReady = 0;

                            enemy.BattleCounter.Start();

                            break;

                        case "2":
                            if (player.BattleReady == 1)
                            {
                                if (enemy.Hp > 0)
                                {
                                    if (player.MagicDamage(player, enemy) != 0)
                                    {
                                        player.MagicAttack(enemy, player);
                                        player.Mp = player.Mp - 3;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not enough Mp");
                                        break;
                                    }
                                }
                                else if (enemy.Hp <= 0)
                                {
                                    Console.WriteLine("Enemy defeated");
                                    Running = false;
                                }
                            }
                            player.BattleReady = 0;

                            enemy.BattleCounter.Start();

                            break;

                        case "3":
                            player.Def = player.Def * 2;
                            player.Carregamento = 0;

                            player.BattleReady = 0;
                            enemy.BattleCounter.Start();

                            break;

                    }
                }

                if (enemy.BattleReady == 1)
                {
                    if (player.Hp > 0)
                    {
                        enemy.Attack(player, enemy);
                    }
                    if (player.Hp <= 0)
                    {
                        Console.WriteLine("You died");
                        Running = false;
                    }
                    enemy.BattleReady = 0;
                }
            }
        }
    }
}
