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
        private string _cardCode;

        public Card(string cardCode) 
		{
            _cardCode = cardCode;
			SuitCode = cardCode.Substring(cardCode.Length - 1);
			SuitName = assignSuitName();
            SuitValue = assignSuiteValue();
            CardValue = cardCode.Substring(0, cardCode.Length - 1);
            Picture = isCardPicture();
            Value = assignCardScore();
            //logValues();
        }

		private string assignSuitName()
        {
            switch (SuitCode)
            {
                case "H": return "Hearts";
                case "D": return "Daimonds";
                case "C": return "Clubs";
                case "S": return "Spades";
                default: throwSuiteCodeError(); return "Unknown";
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
                default: throwSuiteCodeError(); return 0;
                        
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

        private void throwSuiteCodeError()
        {
            throw new Exception($"{SuitCode} is not valid!");
        }

        private void logValues()
        {
            Console.WriteLine($"Dealing Card {_cardCode}");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"----- START CARD {_cardCode}  ------");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("SuitCode: " + SuitCode);
            Console.WriteLine("SuitName: " + SuitName);
            Console.WriteLine("SuitValue: " + SuitValue);
            Console.WriteLine("CardValue: "+ CardValue);
            Console.WriteLine("Value: "+Value);
            if(Picture)
            {
                Console.WriteLine("Picture: " + Picture);
                Console.WriteLine("PictureName: " + PictureName);
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"----- END CARD {_cardCode}  ------");
            Console.WriteLine("-----------------------------------");
        }
    }
}

