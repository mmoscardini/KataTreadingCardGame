using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Deck
    {
        public List<int> listOfCards = new List<int>();

        public Deck()
        {
            listOfCards.Add(0);
            listOfCards.Add(0);
            listOfCards.Add(1);
            listOfCards.Add(1);
            listOfCards.Add(2);
            listOfCards.Add(2);
            listOfCards.Add(2);
            listOfCards.Add(3);
            listOfCards.Add(3);
            listOfCards.Add(3);
            listOfCards.Add(3);
            listOfCards.Add(4);
            listOfCards.Add(4);
            listOfCards.Add(4);
            listOfCards.Add(4);
            listOfCards.Add(5);
            listOfCards.Add(5);
            listOfCards.Add(6);
            listOfCards.Add(6);
            listOfCards.Add(7);
            listOfCards.Add(8);
        }

        public void ShufleDeck()
        {
            int n = listOfCards.Count;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = rnd.Next(0, n) % n;
                n--;
                int value = listOfCards[k];
                listOfCards[k] = listOfCards[n];
                listOfCards[n] = value;

            }
        }

    }
}