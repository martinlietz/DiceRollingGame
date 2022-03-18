# Dice Rolling Game
console application in the tested language (C#/C++) that will allow multiple players to take turns rolling a pair of dice, track game progress and display the results of each “roll”.   A designated number of rounds defines the length of the game.  With each round a player takes a turn at rolling the dice and accumulates points toward his total in the amount of the result of the roll(s).  The player with the highest point total at the end of the game is the winner.  In the event of a tie, additional turns will be taken as needed to determine a winner.
Game Parameters

•	Number of players:  2 to 5. Default to 2.
•	Number of rounds for the game:  2 to 10.  Default to 5.

Game start

1.	At game start prompt for the number of players. The user can accept the default value of 2 or enter another value between 3 and 5.
2.	For each player require the user to enter an identifying short name 3 characters or less in length, or accept default names of A, B, [C, D, E].
3.	Prompt for the number of rounds for the game. The user can accept the default value of 5 or enter a value between 2 and 10.

Game play

1.	A roll of the dice comprises the generation of 2 random whole numbers between 1 and 6.  The result of each roll must be displayed for the user along with the player’s running total.
2.	To signal the user of a player’s turn to roll, the user must be prompted with the player name to execute the roll; e.g. “Player xxx now rolling” or something to that effect.
3.	To execute a roll the user must hit <Enter> (or any other key you might want to designate as “roll”).
4.	A turn comprises one or more rolls of the dice for a player.  A turn will involve more than one roll for a player if the result of a roll is a double value, i.e. the same value for each of the dice. The player’s turn is over after rolling a result that is not a double value.  All the results for a player’s turn accrue to the player’s total for the game.
5.	A round comprises a turn for each of the players in the game.


End of the game

1.	The game is over when all the specified rounds have been completed and one player has won by accumulating more points than any other.
2.	If the designated number of rounds has been completed but multiple players are tied in terms of the highest point total, additional rounds must be played involving only the players tied for the lead until a single winner emerges.
3.	At game end the user can choose one of the following options:
a.	Play another game.  With this choice the number of players and the number of rounds defaults to the values in effect for the just completed game. However, the user can change them.
b.	Play back the game just completed.  With this choice each round of the game is re-played for the user in sequence.  To prevent the replay from scrolling past to quickly, require the user to hit <Enter> to see the next replay “section”.  This could follow the model of the actual play requiring action for every roll or after the replay of several rolls.
c.	Quit
