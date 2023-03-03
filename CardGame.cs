using System;
using System.Text.Json;
using System.Linq;
namespace addmup
{
	public class CardGame
	{
		
		private readonly string[] _fileContent;

		private readonly FileHandle _fileHandle;

		public IList<Player> Players { get; }

		public Winner[]? Winners { get; set; }

		public CardGame(string[] args) 
		{
			Players = new List<Player>();
			_fileHandle = new(args);
			// _fileHandle.ShowArguments();
			_fileContent = _fileHandle.ReadInputFile();
		}

		public CardGame AddPlayers()
		{
			foreach(var line in _fileContent)
			{
				Players.Add(new Player(line));   
			}
			//Console.WriteLine("Players Added");
			//logPlayers();
            return this;
		}

		public CardGame DetermineWinners()
		{
			int maxScore = Players.Max(p => p.CardValueScore());
			var winners = Players
				.Where(p => p.CardValueScore() == maxScore)
				.Select(p => new Winner
				{
					Name = p.Name,
					CardScore = p.CardSuitScore(),
					SuitScore = p.CardSuitScore()
				}).ToArray<Winner>();

			if(winners.Length > 1)
			{
				var maxSuiteScore = winners.Max(w => w.SuitScore);
				winners = winners.Where(w => w.SuitScore == maxSuiteScore).ToArray<Winner>();
			}

			Winners = winners;

			return this;
        }

		public void WriteWinnersToFile()
		{
			string toWriteOut = "";
			foreach(var winner in Winners)
			{
				if(toWriteOut.Length == 0)
				{
					toWriteOut += winner.Name;
                }
				else
				{
                    toWriteOut += "," + winner.Name;
                }
			}
			toWriteOut += ":" + (Winners[0].CardScore + Winners[0].SuitScore);
			WriteOutputFile(toWriteOut);
        }

        public void WriteOutputFile(string output)
        {
            _fileHandle.WriteOutFile(output);
        }

        private void logPlayers()
        {
            foreach (var player in Players)
            {
                // var player
                Console.WriteLine(JsonSerializer.Serialize(player));
            }
        }

        public static void Run(string[] args)
		{
			var cardGame = new CardGame(args);
			try
			{
                cardGame
                    .AddPlayers()
					.DetermineWinners()
					.WriteWinnersToFile();
            }
			catch(Exception error)
			{
				cardGame.WriteOutputFile(error.Message);
            }
		}
	}
}

