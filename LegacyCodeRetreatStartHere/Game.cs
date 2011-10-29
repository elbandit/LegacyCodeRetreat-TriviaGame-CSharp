using System;
using System.Collections.Generic;

namespace com.adaptionsoft.games.trivia
{
	public class Game
	{
		List<string> players = new List<string>();
		int[] places = new int[6];
		int[] purses = new int[6];
		bool[] inPenaltyBox = new bool[6];
		
		List<string> popQuestions = new List<string>();
		List<string> scienceQuestions = new List<string>();
		List<string> sportsQuestions = new List<string>();
		List<string> rockQuestions = new List<string>();
		
		int currentPlayer = 0;
		bool isGettingOutOfPenaltyBox;
		
		public Game ()
		{
    	for (int i = 0; i < 50; i++) {
			popQuestions.Add("Pop Question " + i);
			scienceQuestions.Add(("Science Question " + i));
			sportsQuestions.Add(("Sports Question " + i));
			rockQuestions.Add(CreateRockQuestion(i));
    	}
		}
		
		public string CreateRockQuestion(int index)
		{
			return "Rock Question " + index;
		}
		
		public bool IsPlayable() 
		{
			return (HowManyPlayers() >= 2);
		}
		
		public bool Add(String playerName) 
		{
			
			
		    players.Add(playerName);
		    places[HowManyPlayers()] = 0;
		    purses[HowManyPlayers()] = 0;
		    inPenaltyBox[HowManyPlayers()] = false;
		    
		    Console.WriteLine(playerName + " was added");
		    Console.WriteLine("They are player number " + players.Count);
			return true;
		}
		
		public int HowManyPlayers() 
		{
			return players.Count;
		}
		
		public void Roll(int roll) 
		{
			Console.WriteLine(players[currentPlayer] + " is the current player");
			Console.WriteLine("They have rolled a " + roll);
			
			if (inPenaltyBox[currentPlayer]) 
			{
				if (roll % 2 != 0) 
				{
					isGettingOutOfPenaltyBox = true;
					
					Console.WriteLine(players[currentPlayer] + " is getting out of the penalty box");
					places[currentPlayer] = places[currentPlayer] + roll;
					if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;
					
					Console.WriteLine(players[currentPlayer] 
							+ "'s new location is " 
							+ places[currentPlayer]);
					Console.WriteLine("The category is " + CurrentCategory());
					AskQuestion();
				} 
				else 
				{
					Console.WriteLine(players[currentPlayer] + " is not getting out of the penalty box");
					isGettingOutOfPenaltyBox = false;
					}
				
			} 
			else 
			{
			
				places[currentPlayer] = places[currentPlayer] + roll;
				if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;
				
				Console.WriteLine(players[currentPlayer] 
						+ "'s new location is " 
						+ places[currentPlayer]);
				Console.WriteLine("The category is " + CurrentCategory());
				AskQuestion();
			}
		}
		private void AskQuestion() 
		{
			if (CurrentCategory() == "Pop") 
			{
				Console.WriteLine(popQuestions[0]);
				popQuestions.RemoveAt(0);
			}
			if (CurrentCategory() == "Science") 
			{
				Console.WriteLine(scienceQuestions[0]);
				scienceQuestions.RemoveAt(0);
			}
			if (CurrentCategory() == "Sports")
			{
				Console.WriteLine(sportsQuestions[0]);
				sportsQuestions.RemoveAt(0);
			}
			if (CurrentCategory() == "Rock")
			{
				Console.WriteLine(rockQuestions[0]);
				rockQuestions.RemoveAt(0);
			}
		}
		
		private string CurrentCategory() 
		{
			if (places[currentPlayer] == 0) return "Pop";
			if (places[currentPlayer] == 4) return "Pop";
			if (places[currentPlayer] == 8) return "Pop";
			if (places[currentPlayer] == 1) return "Science";
			if (places[currentPlayer] == 5) return "Science";
			if (places[currentPlayer] == 9) return "Science";
			if (places[currentPlayer] == 2) return "Sports";
			if (places[currentPlayer] == 6) return "Sports";
			if (places[currentPlayer] == 10) return "Sports";
			return "Rock";
		}
		
		public bool WasCorrectlyAnswered()
		{
			if (inPenaltyBox[currentPlayer])
			{
				if (isGettingOutOfPenaltyBox) 
				{
					Console.WriteLine("Answer was correct!!!!");
					purses[currentPlayer]++;
					Console.WriteLine(players[currentPlayer] 
							+ " now has "
							+ purses[currentPlayer]
							+ " Gold Coins.");
					
					bool winner = DidPlayerWin();
					currentPlayer++;
					if (currentPlayer == players.Count) currentPlayer = 0;
					
					return winner;
				} 
				else 
				{
					currentPlayer++;
					if (currentPlayer == players.Count) currentPlayer = 0;
					return true;
				}
				
				
				
			} else {
			
				Console.WriteLine("Answer was corrent!!!!");
				purses[currentPlayer]++;
				Console.WriteLine(players[currentPlayer]
						+ " now has "
						+ purses[currentPlayer]
						+ " Gold Coins.");
				
				bool winner = DidPlayerWin();
				currentPlayer++;
				if (currentPlayer == players.Count) currentPlayer = 0;
				
				return winner;
			}
		}
		
		public bool WrongAnswer()
		{
			Console.WriteLine("Question was incorrectly answered");
			Console.WriteLine(players[currentPlayer]+ " was sent to the penalty box");
			inPenaltyBox[currentPlayer] = true;
			
			currentPlayer++;
			if (currentPlayer == players.Count) currentPlayer = 0;
			return true;
		}
		
		private bool DidPlayerWin() 
		{
			return !(purses[currentPlayer] == 6);
		}
	}
}
