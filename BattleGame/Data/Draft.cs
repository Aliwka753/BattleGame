using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Data
{
    //класс шаблон гнома
    internal class Draft : Warrior
    {
        public Draft(string name, int healthPoint, int minHit, int maxHit, string weapon) : base(name, healthPoint, minHit, maxHit, weapon)
        {
        }

    }
}
