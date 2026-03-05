namespace cards;

class Program
{
    static void Main(string[] args)
    {
        string[] deck = Console.ReadLine().Split(", ");
        string[] cards = new[]
        {
            "A",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "J",
            "Q",
            "K",
        };
        string[] suits = new string[]
        {
            "S",
            "H",
            "D",
            "C"
            //'B',
        };
        List<Card> cardDeck = new List<Card>();
        foreach (var card in deck)
        {
            string[] cardTokens = card.Split(" ");
            string face = cardTokens[0];
            string suit = (cardTokens[1]);//[0];
            try
            {
                if (!cards.Contains(face) || !suits.Contains(suit))
                {
                    throw new Exception("Invalid card");
                }

                switch (suit)
                {
                    case "S":
                        suit = "\u2660";
                        break;
                    case "H":
                        suit ="\u2665";
                        break;
                    case "D":
                        suit ="\u2666";
                        break;
                    case "C":
                        suit = "\u2663";
                        break;
                }
                Card newCard = new Card(face, char.Parse(suit));
                cardDeck.Add(newCard);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
        }
        //Console.WriteLine(string.Join(" ", cardDeck));
        string output = "";
        foreach (var card in cardDeck)
        {
            output += $"{card.ToString()} ";
        }
        output = output.TrimEnd();
        Console.WriteLine(output);
        //cardDeck.ForEach(card => Console.Write($"{card.ToString()} "));
    }
}

public class Card
{
    public Card(string face, char suit)
    {
        this.Face = face;
        this.Suit = suit;
    }
    public string Face { get; private set; }
    public char Suit { get; private set; }

    public override string ToString()
    {
        return @$"[{this.Face}{this.Suit}]";
    }
}