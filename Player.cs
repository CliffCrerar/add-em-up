using System;
namespace addmup
{
	public class Player
	{
		public static int number = 0;
		public string Name { get; }
		private string[] _rawCards { get; }
		public IList<Card> Cards { get; }
		public Player(string playerNameAndScore)
		{
			Player.number += 1;
			Name = setPlayerName(playerNameAndScore);
            _rawCards = setPlayerCards(playerNameAndScore);
			Cards = new List<Card>();
			setCards();
		}

		private string setPlayerName(string playerNameAndScore)
		{
			return playerNameAndScore.Split(":")[0];
		}
		private string[] setPlayerCards(string playerNameAndScore)
		{
			return playerNameAndScore.Split(":")[1].Replace(" ","").Split(",");
		}
		private void setCards()
		{
			foreach(var code in _rawCards)
			{
				Cards.Add(new Card(code));
			}
		}
	}
}