using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Rolling_Game.Model
{
    /// <summary>
    /// Class <c>DiceRollingGame</c> models a multiplayer console game.
    /// </summary>
    class DiceRollingGame : Game
    {
        public int running = 0;

        public int numberPlayers = 2;
        public int numberRounds = 5;
        public List<List<string>> lstReplay = new();
        public List<Player> players = new List<Player>();

        private string[] defaultNames = { "A", "B", "C", "D", "E" };
        private Random rnd = new();
        private int noDefaultPlayers = 2;
        private int noDefaultRounds = 5;
        // Create a class constructor for the DiceRollingGame class
        public DiceRollingGame()
        {
            

        }
        /// <summary>
        /// This method starts the game and define the players and rounds
        /// 
        /// </summary>
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

                    players.Add(new Player(strNome.Left(3)));
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
        /// <summary>
        /// This method init the game
        /// 
        /// </summary>
        public override void play()
        {
            try
            {
                int n = numberRounds;
                for(int i = 0;i < n;i++)
                {
                    List<string> strReplayRound = new();
                    foreach (Player player in players)
                    {
                        strReplayRound.Add(String.Format("Round {0}", (i + 1)));
                        Console.WriteLine(String.Format("Round {0}", (i + 1)));
                        strReplayRound.Add(String.Format("Player {0} now rolling", player.shortname));
                        Console.WriteLine(String.Format("Player {0} now rolling", player.shortname));
                        int rnd1 = 0;
                        int rnd2 = 0;
                        while(rnd1 == rnd2)
                        {
                            strReplayRound.Add("Roll?");
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

                            string strTemp = String.Format("Player {0} your dices are {1} and {2} your running total is {3}", player.shortname, rnd1, rnd2, player.gameScore);
                            strReplayRound.Add(strTemp);
                            Console.WriteLine(strTemp);
                                if (rnd1 == rnd2)
                                {
                                    Console.WriteLine("Double! you can roll again!");
                                    strReplayRound.Add("Double! you can roll again!");
                                }
                            }
                        
                        if(i==(numberRounds-1) & player == players[players.Count-1])
                        {
                            Player winner = checkWinner();
                            if (winner == null)
                            {
                                //Still no winner lets do one more run.
                                strReplayRound.Add("Still no winner lets do one more run.");
                                Console.WriteLine("Still no winner lets do one more run.");
                                n += 1;
                            }
                            else
                            {
                                strReplayRound.Add(new string('-', 30));
                                Console.WriteLine(new string('-', 30));
                                strReplayRound.Add("And the winner is:");
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
                                Console.Write("\r ");
                                strReplayRound.Add(String.Format("\nPlayer {0} with running total {3}", winner.shortname, rnd1, rnd2, winner.gameScore));
                                Console.WriteLine(String.Format("\nPlayer {0} with running total {3}", winner.shortname, rnd1, rnd2, winner.gameScore));
                                Console.WriteLine(new string('-', 30));
                                strReplayRound.Add(new string('-', 30));
                                lstReplay.Add(strReplayRound);
                                stop();
                            }
                        }
                        
                        
                    }
                    lstReplay.Add(strReplayRound);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// This method stops the game and define what to do next
        /// 
        /// </summary>
        public override void stop()
        {
            try
            {
                Console.WriteLine("End of the game!");
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("a. Play another game.");
                Console.WriteLine("b. Play back the game just completed.");
                Console.WriteLine("c. Quit the game.");
                string strChoose = Console.ReadLine();
                Boolean valid = false;
                while(!valid)
                { 
                    switch (strChoose.ToLower().Trim())
                    {
                        case "a":
                            playagain();
                            valid=true;
                            break;
                        case "b":
                            replay();
                            Console.WriteLine("Choose one of the following options:");
                            Console.WriteLine("a. Play another game.");
                            Console.WriteLine("b. Play back the game just completed.");
                            Console.WriteLine("c. Quit the game.");
                            strChoose = Console.ReadLine();
                            break;
                        case "c":
                            Console.WriteLine("Was nice to play with you, bye!");
                            running = 0;
                            valid = true;
                            break;
                        default:
                            Console.WriteLine("Not a valid choice, try again!");
                            Console.WriteLine("Choose one of the following options:");
                            Console.WriteLine("a. Play another game.");
                            Console.WriteLine("b. Play back the game just completed.");
                            Console.WriteLine("c. Quit the game.");
                            strChoose = Console.ReadLine();
                            break;
                    }
                }



            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// This method checks who is the winner, if two have the same score we return null 
        /// and we add another round
        /// 
        /// </summary>
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
        /// <summary>
        /// This method starts the game over 
        /// but replaces the defaults by the previous game
        /// 
        /// </summary>
        public void playagain()
        {
            //setDefaults to old values
            noDefaultRounds = players.Count();
            noDefaultRounds = numberRounds;
            //and play again
            start();
        }
        /// <summary>
        /// This method replay the last game
        /// 
        /// </summary>
        public void replay()
        {
            int i = 0;
            foreach( List<string> strLst in lstReplay)
            {
                foreach (string str in strLst)
                {
                    i++;
                    Console.WriteLine(str);
                    if (str == "Roll?")
                    {
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
                    }
                    if (i > 10)
                    {
                        Console.WriteLine("Next section click a key");
                        
                        string strNextSection = Console.ReadLine();
                        i = 0;
                    }
                }
            }
            stop(); 
        }
       
    }
}
