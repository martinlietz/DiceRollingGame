using System;
using Dice_Rolling_Game.Model;


namespace Dice_Rolling_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DiceRollingGame game = new DiceRollingGame(); ; // Create a DiceRollingGame object
            game.start();
            while(game.running == 1)
            {
                game.play();
            }
        }
    }
}
