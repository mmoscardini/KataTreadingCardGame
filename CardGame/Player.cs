using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Player
    {
        private int fatiga = 0;
        public int health { get; set; }
        public string name { get; protected set; }
        public Deck myDeck { get; protected set; }

        public List<int> cardsInHand = new List<int>();
        public List<ManaCristal> manaCristalList = new List<ManaCristal>();
        public int currentMana = 0;


        public Player(int _health, string _name)
        {
            this.health = _health;
            this.name = _name;
            myDeck = new Deck();
        }

        //Jogador compra 1 carta
        public void DrawCard()
        {
            //se o deck estiver vazio o jogador toma 1 de dano cumulativo
            if (myDeck.listOfCards.Count == 0)
            {
                fatiga++;
                health -= fatiga;

            }
            //Se o total na mao do jogador for menor que 5 comprar. Caso contrario destruir a carta que seria comprada.
            if (cardsInHand.Count < 5)
            {
                int proximaCarta = this.myDeck.listOfCards[0];
                this.cardsInHand.Add(proximaCarta);
                this.myDeck.listOfCards.RemoveAt(0);
            }
            else
            {
                this.myDeck.listOfCards.RemoveAt(0);

            }

            return;
        }

        //Jogador Ganha mais 1 cristal de mana
        //Todos os cristais de mana são preenchidos
        public void NewManaCristal()
        {
            if (manaCristalList.Count < 10)
                manaCristalList.Add(new ManaCristal());

            foreach (ManaCristal mc in manaCristalList)
            {
                if (!mc.cheio)
                {
                    mc.cheio = true;
                }
            }
            CurrentManaCalculus();
        }

        //A mana atual é igual a quantiade de cristais cheios
        public int CurrentManaCalculus()
        {
            foreach (ManaCristal mc in manaCristalList)
                if (mc.cheio && currentMana < manaCristalList.Count)
                    currentMana++;

            return currentMana;
        }


        public void LoseGame()
        {
            if (health <= 0)
            {
                Console.WriteLine("Player " + name + " lost the game!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
