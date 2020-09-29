using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {

            DeckRepository.populateRepository();

            int playerHand = 0;
            int dealerHand = 0;
            int playerStack = 0;

            Console.WriteLine("How much money would you like to deposit?");
            int stack = Convert.ToInt32(Console.ReadLine());
            playerStack += stack;


            void AddCardToPlayer()
            {
                var newCard = CardGenerator.DealCardPlayer();
                playerHand += newCard.CardValue;
                Console.WriteLine("You've been dealt {0} of {1}" , newCard.Name, newCard.Suit);
                Console.WriteLine("The player's hand is now: " + playerHand);
                Console.WriteLine("______________");
            }

            Card AddCardToDealer()
            {
                var newCard = CardGenerator.DealCardDealer();
                dealerHand += newCard.CardValue;
                Console.WriteLine("______________");
                return newCard;
            }

            //KeepPlaying.cs
            bool keepPlaying = true;
            while (keepPlaying)
            {
                bool playerBusted = false;
                bool dealerBusted = false;
                int playerWager = 0;
                bool wagerMoreThanStack = true;
                playerHand = 0;
                dealerHand = 0;


                while (wagerMoreThanStack)
                {
                    Console.WriteLine("How much money would you like to bet?");
                    int wager = Convert.ToInt32(Console.ReadLine());
                    if (wager <= playerStack)
                    {
                        playerWager += wager;
                        wagerMoreThanStack = false;
                    }
                    else
                    {
                        Console.WriteLine("Your wager is more than your stack, please enter a number less than or equal to " + playerStack);
                    }
                }

                //deal first two cards
                var dealerFirstCard = AddCardToDealer();
                Console.WriteLine("The dealer's card is a {0} of {1}" , dealerFirstCard.Name, dealerFirstCard.Suit);
                Console.WriteLine("The value of the dealer's upcard is : {0}", dealerHand);
                AddCardToPlayer();
                AddCardToDealer();
                AddCardToPlayer();

                bool playerKeepGoing = true;
                while (playerHand <= 21)
                {

                    while (playerKeepGoing)
                    {
                        Console.WriteLine("Do you wish to stand or hit?");
                        Console.WriteLine("Please press 's' for stand or 'h' for hit");
                        string input = Console.ReadLine();

                        if (input == "h")
                        {
                            AddCardToPlayer();

                            //see if he busted
                            if (playerHand >= 22)
                            {
                                Console.WriteLine("player busted");
                                playerBusted = true;
                                playerKeepGoing = false;
                            }
                        }
                        else if (input == "s")
                        {
                            Console.WriteLine("player stayed at " + playerHand);
                            playerKeepGoing = false;

                        }
                        else
                        {
                            Console.WriteLine("You entered an invalid key, please try again");
                        }
                    }
                    break;
                }

                Console.WriteLine("Dealer's turn..");

                //beginnning of dealer logic
                while (dealerHand < 17)
                {
                    AddCardToDealer();
                }

                //check if dealer busted 
                if (dealerHand > 21)
                {
                    dealerBusted = true;
                }

                //
                if (playerBusted)
                {
                    Console.WriteLine("Dealer wins because playerbusted");
                    playerStack -= playerWager;
                    Console.WriteLine("Your new available stack is : " + playerStack);
                }
                else if (dealerBusted)
                {
                    Console.WriteLine("Player wins because dealer busted");
                    playerStack += playerWager;
                    Console.WriteLine("Your new available stack is : " + playerStack);
                }
                else
                {
                    //evaluate two hands 

                    if (dealerHand >= playerHand)
                    {
                        Console.WriteLine("The dealer's hand is " + dealerHand);
                        Console.WriteLine("Dealer wins hand greater!");
                        playerStack -= playerWager;
                        Console.WriteLine("Your new available stack is : " + playerStack);
                    }
                    else
                    {
                        Console.WriteLine("Player wins hand greater!");
                        playerStack += playerWager;
                        Console.WriteLine("Your new available stack is : " + playerStack);
                    }
                }

                Console.WriteLine("Do you wish to continue playing? Press 'y' for yes or 'n' for no");
                string inputContinue = Console.ReadLine();

                if (inputContinue == "y")
                {
                    keepPlaying = true;
                    playerHand = 0;
                    dealerHand = 0;
                }
                else if(inputContinue == "n")
                {
                    Console.WriteLine("Thank you for playing...");
                    keepPlaying = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid key, and sober up");
                    Console.ReadLine();
                    keepPlaying = false;
                    break;
                }

                if (playerStack <= 0)
                {
                    Console.WriteLine("Sorry, you're out of money");
                    Console.WriteLine("Would you like to deposit more money? Please press 'y' for yes and 'n' for no");
                    string depositMoreResponse = Console.ReadLine();

                    if (depositMoreResponse == "y")
                    {
                        Console.WriteLine("How much would you like to deposit?");
                        int depositMoreAmount = Convert.ToInt32(Console.ReadLine());
                        playerStack += depositMoreAmount;
                    }
                    else if (depositMoreResponse == "n")
                    {
                        Console.WriteLine("Thank you for playing...");
                        keepPlaying = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid key, and sober up");
                        Console.ReadLine();
                        keepPlaying = false;
                        break;
                    }
                }
            }
            Console.ReadLine();
        }//end main
    }
}
