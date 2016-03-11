using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static Player currentPlayer;
        static Player otherPlayer;
        static Player player01;
        static Player player02;



        static void Main(string[] args)
        {
            player01 = new Player(20, "Player 01");
            player02 = new Player(20, "Player 02");

            //embaralhar os decks
            player01.myDeck.ShufleDeck();
            player02.myDeck.ShufleDeck();


            StartGame(player01, player02);
            StartTurn(currentPlayer, otherPlayer);

        }

        static void StartGame(Player p01, Player p02)
        {
            Console.WriteLine("Press Any key to Start");
            Console.ReadKey();

            //Quem joga primeiro 
            Random rnd = new Random();

            if (rnd.NextDouble() > 0.5f)
            {
                currentPlayer = p01;
                otherPlayer = p02;
            }
            else
            {
                currentPlayer = p02;
                otherPlayer = p01;
            }

            currentPlayer.DrawCard();
            currentPlayer.DrawCard();

            otherPlayer.DrawCard();
            otherPlayer.DrawCard();
            otherPlayer.DrawCard();

        }

        static void StartTurn(Player p, Player op)
        {
            p.NewManaCristal();
            p.DrawCard();

            Console.WriteLine(p.name + " is starting his turn");
            Console.WriteLine("Total mana Crystals: " + p.manaCristalList.Count);
            Console.WriteLine("Current mana " + p.currentMana);
            Console.Write("Cards in hand");
            for (int i = 0; i < p.cardsInHand.Count; i++)
            {
                Console.Write(" " + p.cardsInHand[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();


            //Ordenar as cartas em ordem decrescente - A maior primeiro
            //Verificar se o jogador possui mana para castar a primeira carta. Se sim castar.
            //Verificar a segunda carta, e assim por diante

            //Se voce possui alguma carta na mão
            if (p.cardsInHand != null)
            {
                //tentar castar da carta mais cara para a mais barata
                p.cardsInHand.Sort();
                p.cardsInHand.Reverse();
                for (int i = 0; i < p.cardsInHand.Count; i++)
                {
                    int cardToCast = p.cardsInHand[i];

                    //se o jogador possui mana
                    if (cardToCast <= p.currentMana)
                    {
                        //Remover cristais de mana
                        p.currentMana -= cardToCast;

                        //Causar dano
                        op.health -= p.cardsInHand[i];
                        p.cardsInHand.RemoveAt(i);
                        Console.WriteLine(op.name + " heath is " + op.health);
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                }
            }

            //Checar se o outro jogador morreu neste turno
            op.LoseGame();

            //Alterar currentPlayer e otherPlayer
            if (currentPlayer == player01)
            {
                currentPlayer = player02;
                otherPlayer = player01;
            }
            else
            {
                currentPlayer = player01;
                otherPlayer = player02;
            }


            //Iniciar Proximo turno
            StartTurn(currentPlayer, otherPlayer);

        }
    }
}

