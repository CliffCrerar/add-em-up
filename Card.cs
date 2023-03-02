using System;
namespace addmup
{
	public class Card
	{
		public int Score { get; }
		public string Value { get; }
		public bool Picture { get; }
		public string SuitName { get; }
		public string SuiteCode { get; }
        public string? PictureType { get; }

        public Card(string cardCode) 
		{
			SuiteCode = cardCode.Substring(cardCode.Length - 1);
			SuitName = assignSuitName();

            Value = cardCode.Substring(0, cardCode.Length - 1);

            Picture = false;

            PictureType = null;

            Score = 0;

            Console.WriteLine($"Dealing Card {cardCode}");
			Console.WriteLine(SuiteCode);
            Console.WriteLine(SuitName);
            Console.WriteLine(Value);
        }

		private string assignSuitName()
        {
            switch (SuiteCode)
            {
                case "H": return "Hearts";
                case "D": return "Daimonds";
                case "C": return "Clubs";
                case "S": return "Spades";
                default: return "Unknown";
            }
        }

		private string assignCardScore()
		{

		}

    }
}

