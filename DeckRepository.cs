using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class DeckRepository
    {

        public static List<Card> populatedDeck = new List<Card>();
        public  List<Card> populatedDeck2 = new List<Card>();

        public static void populateRepository()
        {
            int[] valueArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11};
            string[] suitArray = { "hearts", "diamonds", "clubs", "spades" };
            string[] nameArray = { "ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king", "ace" };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    var newCard = new Card();
                    newCard.Suit = suitArray[i];
                    newCard.CardValue = valueArray[j];
                    newCard.Name = nameArray[j];
                    populatedDeck.Add(newCard);
         
                }
            }
        }
    }
}
