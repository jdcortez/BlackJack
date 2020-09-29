using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Blackjack
{
    class CardGenerator
    {
        public static Card DealCardDealer()
        {
            Thread.Sleep(1);

            //get random card from deck in deckrepository
            Random random = new Random();
            int number = random.Next(0, DeckRepository.populatedDeck.Count);
            var newCard = DeckRepository.populatedDeck[number];

            //delete card
            DeleteCard(newCard);

            return newCard;
        }
        public static Card DealCardPlayer()
        {
            Thread.Sleep(1);
            Thread.Sleep(1);

            //get random card from deck in deckrepository
            Random random = new Random();
            int number = random.Next(0, DeckRepository.populatedDeck.Count);
            var newCard = DeckRepository.populatedDeck[number];
            
            if (newCard.CardValue == 1 || newCard.CardValue == 11)
            {
                Console.WriteLine("You picked an ace, do you want it to be of value 1 or 11?");
                int aceChoice = Convert.ToInt32(Console.ReadLine());
                if (aceChoice == 1)
                {
                    newCard.CardValue = aceChoice;
                }
                else if (aceChoice == 11)
                {
                    newCard.CardValue = aceChoice;
                }
                else
                {
                    Console.WriteLine("Ok sucker, you don't wanna choose correctly, we'll pick 1 for you");
                    newCard.CardValue = 1;
                }

            }

            //delete card
            DeleteCard(newCard);

            return newCard;
        }

        public static void DeleteCard(Card card)
        {
            for(int i =0; i <DeckRepository.populatedDeck.Count; i++)
            {
                if(card.Equals(DeckRepository.populatedDeck[i]))
                {
                    DeckRepository.populatedDeck.Remove(card);
                }
            }
        }



    }
}
