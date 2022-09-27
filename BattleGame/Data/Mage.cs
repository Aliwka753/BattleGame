using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Data
{
    //класс шаблон мага
    internal class Mage : Warrior
    {
        public Mage(string name, int healthPoint, int minHit, int maxHit, string weapon) : base(name, healthPoint, minHit, maxHit, weapon)
        {
        }


    }
}
