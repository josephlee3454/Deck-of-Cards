using System;
using System.Collections.Generic;

namespace deck_cards
{
   
    class Card
    {
        public string stringVal;

        public string suit;

        public int val;


        public Card(string cardVal, string newSuit, int newVal)
        {
            stringVal = cardVal;
            suit = newSuit;
            val = newVal;

        }
    }


    class Deck
    {
        public List<Card> cards;

        public Card deal(){
            System.Console.WriteLine(cards.Count);
            Card curCard = cards[cards.Count-1];
            cards.Remove(curCard);
            System.Console.WriteLine("the first card" + curCard.stringVal + " of " + curCard.suit);
            return curCard;


        }
        public Deck(){
            reset();
        }


        public void shuff(){
            Random rand = new Random();

            for(int i = cards.Count; i > 0; i--){
                int randCard = rand.Next(cards.Count);
                cards.Add(cards[randCard]);
                cards.Remove(cards[randCard]);
            }
            
            foreach(var card in cards){
                System.Console.WriteLine("the card" + card.stringVal + " of suit " + card.suit);
            }

        }

        public void reset()
        {

            cards = new List<Card>();

            string[] suits = {"spades","clubs","hearts","diamonds"};
            string[] strVals = {"ace","two","three", "four", "five", "six", "seven", "eight", "nine","ten","jax","queen","king"};


            foreach(string suit in suits)
            {

                for(int i = 0; i < strVals.Length; i++)
                {
                     Card nextCard = new Card(strVals[i], suit, i+1);
                    cards.Add(nextCard);
                }
                foreach(var card in cards){
                    System.Console.WriteLine("your "+card.stringVal + " of suit " + card.suit);
                }



            }



        }





    }

    class Player
    {
        public String Name;
        public List<Card> hand;

        public Player(String name){
            Name = name;
            hand = new List<Card>();
        }

        public Card draw(Deck deck)
        {
            Card myCard = deck.deal();
            hand.Add(myCard);
            System.Console.WriteLine("the person drew "+ myCard.stringVal + " of suit"+ myCard.suit);
            return myCard;

        }

        public Card discard(int cardNum){
            if(cardNum >=0 && cardNum < hand.Count){
                Card removed_card = hand[cardNum];
                hand.RemoveAt(cardNum);
                System.Console.WriteLine("this card was removed"+ removed_card.stringVal + " of suit"+ removed_card.suit + " was removed");
                return removed_card;
            }
            else{
                System.Console.WriteLine("it is not here its null");
                return null;
            }


            }




    class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                Deck newCardDeck = new Deck();
                // newCardDeck.reset();
                newCardDeck.shuff();
            // newDeck.deal();
            // newDeck.deal();
             Player bruce = new Player("Bruce lei");
                bruce.draw(newCardDeck);
                bruce.draw(newCardDeck);
                bruce.draw(newCardDeck);

                bruce.discard(2);
            }
        }
        
        
        }
}
