using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Rolling_Game.Model
{
    class DiceRollingGame : Game
    {
        public int running = 0;

        public int numberPlayers = 2;
        public int numberRounds = 5;
        public List<int[]> rounds = new List<int[]>();
        public List<Player> players = new List<Player>();

        private string[] defaultNames = { "A", "B", "C", "D", "E" };
        private Random rnd = new();
        private int noDefaultPlayers = 2;
        private int noDefaultRounds = 5;
        // Create a class constructor for the Car class
        public DiceRollingGame()
        {
            

        }
        public override void start()
        {
            try
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
                if(numberPlayers ==0)
                {
                    numberPlayers = noDefaultPlayers;
                }
                for (int i = 0; i < numberPlayers; i++)
                {

                    Console.WriteLine("Player " + (i+1) + " , what is your short name(max. 3 chars only) default " + defaultNames[i] + "?");
                    string strNome = Console.ReadLine();
                    
                    if (String.IsNullOrEmpty(strNome))
                        strNome = defaultNames[i];

                    players.Add(new Player(strNome));
                }
                Console.WriteLine("How many rounds we play?(2-10) default is 5");
                string strRounds = Console.ReadLine();
                
                if (String.IsNullOrEmpty(strRounds.Trim()))
                    numberRounds = noDefaultRounds;
                else
                {
                    while (!(int.TryParse(strRounds, out numberRounds)) & numberRounds > 1 & numberRounds <= 10)
                    {
                        errCnt += 1;
                        if (errCnt > 8)
                        {
                            throw new Exception("You can do better!");
                        }
                    }
                }
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
                int n = numberRounds;
                
                for(int i = 0;i < n;i++)
                {
                    foreach (Player player in players)
                    {
                        Console.WriteLine(String.Format("Round {0}", (i + 1)));
                        Console.WriteLine(String.Format("Player {0} now rolling", player.shortname));
                        int rnd1 = 0;
                        int rnd2 = 0;
                        while(rnd1 == rnd2)
                        {
                            Console.WriteLine("Roll?");
                            var s = Console.ReadLine();
                            for (int x=0;x<10;x++)
                            {
                                Console.Write("\r|");
                                System.Threading.Thread.Sleep(50);
                                Console.Write("\r/");
                                System.Threading.Thread.Sleep(50);
                                Console.Write("\r-");
                                System.Threading.Thread.Sleep(50);
                                Console.Write("\r\\");
                                System.Threading.Thread.Sleep(50);
                            }
                            rnd1 = rnd.Next(1, 6);
                            rnd2 = rnd.Next(1, 6);
                            player.gameScore += rnd1;
                            player.gameScore += rnd2;
                            Console.WriteLine(String.Format("Player {0} your dices are {1} and {2} your running total is {3}", player.shortname, rnd1, rnd2, player.gameScore));
                                if (rnd1 == rnd2)
                                {
                                Console.WriteLine("Double! you can roll again!");
                                }
                            }
                        
                        if(i==(numberRounds-1) & player == players[players.Count-1])
                        {
                            Player winner = checkWinner();
                            if (winner == null)
                            {
                                //Still no winner lets do one more run.
                                Console.WriteLine("Still no winner lets do one more run.");
                                n += 1;
                            }
                            else
                            {
                                Console.WriteLine("And the winner is:");
                                for (int x = 0; x < 10; x++)
                                {
                                    Console.Write("\r|");
                                    System.Threading.Thread.Sleep(50);
                                    Console.Write("\r/");
                                    System.Threading.Thread.Sleep(50);
                                    Console.Write("\r-");
                                    System.Threading.Thread.Sleep(50);
                                    Console.Write("\r\\");
                                    System.Threading.Thread.Sleep(50);
                                }
                                Console.WriteLine(String.Format("Player {0} with running total {3}", winner.shortname, rnd1, rnd2, winner.gameScore));
                                stop();
                            }
                        }
                        
                        
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public override void stop()
        {
            try
            {
                Console.WriteLine("End of the game!");
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("a. Play another game.");
                Console.WriteLine("b. Play back the game just completed.");
                Console.WriteLine("c. Quit the game.");
                string strAgain = Console.ReadLine();
                switch (strAgain.ToUpper().Trim())
                {
                    case "a":
                        playagain();
                        break;
                    case "b":
                        replay();
                        break;
                    case "c":
                        Console.WriteLine("Was nice to play with you, bye!");
                        running = 0;
                        break;
                    default:
                        Console.WriteLine("Not a valid choice, bye!");
                        break;
                }
                running = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Player checkWinner()
        {
            
            int maxValue = players.Max(x => x.gameScore);
            int nWinners = players.FindAll(x => x.gameScore == maxValue).Count();
            
            if (nWinners == 1)
            {
                return players.FirstOrDefault(x => x.gameScore == maxValue);
            }
            else
                return null;
        }
        public void playagain()
        {
            //setDefaults to old values
            noDefaultRounds = players.Count();
            noDefaultRounds = numberRounds;
            //and play again
            start();
        }
        public void replay()
        {

        }
       
    }
}
