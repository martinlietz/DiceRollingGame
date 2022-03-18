using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Rolling_Game.Model
{
    interface IGame
    {
        void start();

        void play();
        void stop();
    }
}
