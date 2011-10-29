using System;

namespace com.adaptionsoft.games.trivia.runner
{
	class GameRunner
	{
		private static bool notAWinner = false;
		
		public static void Main (string[] args)
		{
			Game aGame = new Game();
			
			aGame.Add("Chet");
			aGame.Add("Pat");
			aGame.Add("Sue");
			
			Random rand = new Random();
		
			do {
				
				aGame.Roll(rand.Next(5) + 1);
				
				if (rand.Next(9) == 7) {
					notAWinner = aGame.WrongAnswer();
				} else {
					notAWinner = aGame.WasCorrectlyAnswered();
				}
				
				
				
			} while (notAWinner);
		}
	}
}
