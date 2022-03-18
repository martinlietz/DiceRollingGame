using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Rolling_Game.Model
{
    abstract class Game:IGame
    {
        public abstract void start();

        public abstract void play();
        public abstract void stop();
    }
}
