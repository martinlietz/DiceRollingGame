using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Rolling_Game.Model
{
    public class Player
    {
        public string shortname;
        public int gameScore = 0;
        public Player(string shortname)
        {
            this.shortname = shortname;
        }
    }
}
