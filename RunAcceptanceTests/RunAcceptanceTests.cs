using System;
using System.IO;
using com.adaptionsoft.games.trivia;

namespace RunAcceptanceTests
{
	class RunAcceptanceTests
	{
		private static bool notAWinner = false;
		
		public static void Main (string[] args)
		{
			var realStandardOut = Console.Out;
			
			var testRunDirectoryName = string.Format("acceptance/{0:yyyyMMddHHmmssffff}", DateTime.Now);
			Directory.CreateDirectory(testRunDirectoryName);
				
			try {
				for (int i = 0; i < 10000; i++) 
				{
					var writeToFile = new StreamWriter(string.Format("{1}/{0:0000}.txt", i, testRunDirectoryName));
					Console.SetOut(writeToFile);
					
					Game aGame = new Game();
					aGame.Add("Chet");
					aGame.Add("Pat");
					aGame.Add("Sue");
					
					Random rand = new Random(12374191 * i + 37831);
				
					do {
						
						aGame.Roll(rand.Next(5) + 1);
						
						if (rand.Next(9) == 7) {
							notAWinner = aGame.WrongAnswer();
						} else {
							notAWinner = aGame.WasCorrectlyAnswered();
						}
						
						
						
					} while (notAWinner);
					writeToFile.Close();
				}
			}
			finally {
				Console.SetOut(realStandardOut);
			}
			Console.WriteLine("Done.");
		}
	}
}
