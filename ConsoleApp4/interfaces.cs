using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace rpg
{
    internal interface IBattle
    {

        public int BattleReady { get; set; }
        public int Carregamento { get; set; }
        public System.Timers.Timer BattleCounter { get; set; }
        public abstract void SetTimer();
        public void Ready(Object source, ElapsedEventArgs e);

    }

    public interface IStats
    {
        public double Hp { get; set; }
        public double Mp { get; set; }
        public double Agl { get; set; }
        public double Atk { get; set; }
        public double Def { get; set; }
    }


}
