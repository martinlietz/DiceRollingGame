using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Rolling_Game.Model
{
    class DiceRollingGame : Game
    {
        public string model;  // Create a field
        public int running = 0;
        public int numberPlayers = 2;
        private Random rnd;
        // Create a class constructor for the Car class
        public DiceRollingGame()
        {
            Console.WriteLine("How many players we have?(2-5)");
            string strPlayers = Console.ReadLine();
            int errCnt = 0;
            while (!(int.TryParse(strPlayers, out numberPlayers)) & numberPlayers > 1 & numberPlayers < 6)
            {
                errCnt += 1;
                if (errCnt > 8)
                {
                    throw new Exception("You can do better!");
                }
            }
            running = 1;
            model = "Mustang"; // Set the initial value for model

        }
        public override void start()
        {
            try
            {
                running = 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public override void play()
        {
            try
            {
                Console.WriteLine("Rolll the dice?");
                rnd = new Random();
            }
            catch (Exception)
            {

                throw;
            }
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
