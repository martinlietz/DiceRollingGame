using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Rolling_Game.Model
{
    class DiceRollingGame:Game
    {
        public string model;  // Create a field
        // Create a class constructor for the Car class
        public void Car()
        {
            Console.WriteLine("Let's play!");
            model = "Mustang"; // Set the initial value for model
            
        }
        public override void start()
        {
            throw new NotImplementedException();
        }
        public override void play()
        {
            throw new NotImplementedException();
        }
        public override void stop()
        {
            throw new NotImplementedException();
        }
        public void rollDice()
        {
            throw new NotImplementedException();
        }
    }
}
