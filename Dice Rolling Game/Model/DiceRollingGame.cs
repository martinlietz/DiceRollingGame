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
                //Define the number of players of the game , between 2 and 5 default 2
                Console.WriteLine("How many players we have?(2-5) default is " + noDefaultPlayers);
                string strPlayers = Console.ReadLine();
                int errCnt = 0;
                bool isOk = int.TryParse(strPlayers, out numberPlayers);
                while (!(isOk) | (!(numberPlayers > 1 & numberPlayers <= 5)))
                {
                    errCnt += 1;
                    if (errCnt > 8)
                    {
                        throw new Exception("You can do better!");
                    }
                    Console.WriteLine("How many players we have?(2-5) default is " + noDefaultPlayers);
                    strPlayers = Console.ReadLine();
                    isOk = int.TryParse(strPlayers, out numberPlayers);
                    if (String.IsNullOrEmpty(strPlayers))
                    {
                        numberPlayers = noDefaultPlayers;
                        isOk = true;
                    }
                }
                
                for (int i = 0; i < numberPlayers; i++)
                {

                    Console.WriteLine("Player " + (i+1) + " , what is your short name(max. 3 chars only) default " + defaultNames[i] + "?");
                    string strNome = Console.ReadLine();
                    
                    if (String.IsNullOrEmpty(strNome))
                        strNome = defaultNames[i];

                    players.Add(new Player(strNome.Left(3)));
                }
                //Define the number of rounds we play , between 2 and 10 default 5
                Console.WriteLine("How many rounds we play?(2-10) default is " + noDefaultRounds);
                string strRounds = Console.ReadLine();
                //check if we got something empty
                if (String.IsNullOrEmpty(strRounds.Trim()))
                    numberRounds = noDefaultRounds;
                else
                {
                    isOk = int.TryParse(strRounds, out numberRounds);
                    errCnt = 0;
                    while (!(isOk) | (!(numberRounds > 1 & numberRounds <= 10)))
                    {
                        errCnt += 1;
                        // after 8 times wrong I give up.
                        if (errCnt > 8) 
                        {
                            throw new Exception("You can do better!");
                        }
                        Console.WriteLine("How many rounds we play?(2-10) default is " + noDefaultRounds);
                        strRounds = Console.ReadLine();
                        isOk = int.TryParse(strRounds, out numberRounds);
                        if (String.IsNullOrEmpty(strRounds))
                        {
                            numberRounds = noDefaultRounds;
                            isOk = true;
                        }
                    }
                }
                running = 1;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
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
                        //in case we got no winner only the two winners compete,the rest will be inactive
                        if(player.active == true)
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
                                Console.WriteLine("Roll? (Press ENTER)");
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
                        
                            if(i==(n-1) & player == players[players.Count-1])
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
                string strChoose = Console.ReadKey().KeyChar.ToString();
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
                            //in case os some ENTER ignore and read again without print the message again
                            if(strChoose == "\r")
                            {
                                strChoose = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Not a valid choice, try again!");
                                Console.WriteLine("Choose one of the following options:");
                                Console.WriteLine("a. Play another game.");
                                Console.WriteLine("b. Play back the game just completed.");
                                Console.WriteLine("c. Quit the game.");
                                strChoose = Console.ReadLine();
                            }

                            
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
            {
                players.FindAll(x => x.gameScore != maxValue).FindAll(x => x.active = false);
                return null;
            }
        }
        /// <summary>
        /// This method starts the game over 
        /// but replaces the defaults by the previous game
        /// 
        /// </summary>
        public void playagain()
        {
            //Reactivate all players
            players.FindAll(x => x.active = true);
            //setDefaults to previous game values
            noDefaultPlayers = players.Count();
            noDefaultRounds = numberRounds;
            players = new List<Player>();
            lstReplay = new();
            //and play again
            start();
            while (running == 1)
            {
                play();
            }
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
                        Console.WriteLine("Next section click ENTER");
                        string strNextSection = Console.ReadLine();
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
                    
                    //if (i > 10)
                    //{
                    //    Console.WriteLine("Next section click a key");

                    //    string strNextSection = Console.ReadLine();
                    //    i = 0;
                    //}
                }
            }
            stop(); 
        }
       
    }
}
