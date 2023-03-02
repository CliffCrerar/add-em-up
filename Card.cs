using System;
namespace addmup
{
	public class Card
	{
		public int Value { get; }
		public string CardValue { get; }
		public bool Picture { get; }
		public string SuitName { get; }
		public string SuitCode { get; }
        public int SuitValue { get; }
        public string? PictureName { get; set; }

        public Card(string cardCode) 
		{
			SuitCode = cardCode.Substring(cardCode.Length - 1);

			SuitName = assignSuitName();

            SuitValue = assignSuiteValue();

            CardValue = cardCode.Substring(0, cardCode.Length - 1);

            Picture = isCardPicture();

            Value = assignCardScore();

            Console.WriteLine($"Dealing Card {cardCode}");
			Console.WriteLine(SuitCode);
            Console.WriteLine(SuitName);
            Console.WriteLine(SuitValue);
            Console.WriteLine(CardValue);
            Console.WriteLine(Value);
            Console.WriteLine(Picture);
            Console.WriteLine(PictureName);
        }

		private string assignSuitName()
        {
            switch (SuitCode)
            {
                case "H": return "Hearts";
                case "D": return "Daimonds";
                case "C": return "Clubs";
                case "S": return "Spades";
                default: return "Unknown";
            }
        }

        private int assignSuiteValue()
        {
            switch (SuitCode)
            {
                case "H": return 3;
                case "D": return 2;
                case "C": return 1;
                case "S": return 4;
                default: return 0;
            }
        }

        private bool isCardPicture()
        {
            return new List<string>() { "A", "J", "K", "Q" }.Exists(e => e == CardValue);
        }

		private int assignCardScore()
		{
            switch(CardValue)
            {
                case "A": PictureName = "Ace"; return 11;
                case "J": PictureName = "Jack"; return 11;
                case "Q": PictureName = "Queen"; return 12;
                case "K": PictureName = "King"; return 13;
                default: return int.Parse(CardValue);
            }
		}

    }
}

