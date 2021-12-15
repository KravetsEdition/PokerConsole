using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerLogic
{
    public class Deck : Card
    {
        private List<Card> Cards { get; } // гетеры наших карт
        public Deck()
        {
            var cards = new List<Card>();
            
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value value in Enum.GetValues(typeof(Value)))
                {
                    cards.Add(new Card {Suit = suit, Value = value}); // проходимся по каждому елементу Enum
                                                                      // и заполняем обьекты карточек типа Card
                }
            }

            Cards = cards;
        }

        public Hand dealStandardHand()
        {
            return new Hand { Cards = Cards.Take(5) }; // Вытягиваем первых 5 карт из колоды
        }

        public void shuffle() // миксируем карты
        {
            var random = new Random(); 
            var n = Cards.Count; // запись количества карт
            while (n > 1)
            {
                n--;
                var k = random.Next(n + 1);
                var value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }
    }
}