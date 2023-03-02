using System;
namespace addmup
{
	public class CardGame
	{
		
		private readonly string[] _fileContent;

		private readonly FileHandle _fileHandle;

		public IList<Player> Players { get; }

		public CardGame(string[] args) 
		{
			Players = new List<Player>();
			_fileHandle = new(args);
			_fileHandle.ShowArguments();
			_fileContent = _fileHandle.ReadInputFile();
		}

		public CardGame AddPlayers()
		{
			foreach(var line in _fileContent)
			{
				Console.WriteLine(line);
				Players.Add(new Player(line));
			}
			Console.WriteLine("Players Added");
			return this;
		}

		public static void Run(string[] args)
		{
			new CardGame(args)
				.AddPlayers();
			
		}
	}
}

